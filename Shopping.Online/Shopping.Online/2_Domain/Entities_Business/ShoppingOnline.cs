using Shopping.Online._2_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Online._2_Domain.Entities_Business
{
    public class ShoppingOnline : System.Web.UI.Page
    {
        private _3_DataAccess.DAClient DA_Client = new _3_DataAccess.DAClient();
        private _3_DataAccess.DADepartament DA_Departament = new _3_DataAccess.DADepartament();
        private _3_DataAccess.DAFamily DA_Family = new _3_DataAccess.DAFamily();
        private _3_DataAccess.DASale DA_Sale = new _3_DataAccess.DASale();
        private _3_DataAccess.DALineSale DA_LineSale = new _3_DataAccess.DALineSale();
        private _3_DataAccess.DAProduct DA_Product = new _3_DataAccess.DAProduct();
        private _3_DataAccess.DAPayment DA_Payment = new _3_DataAccess.DAPayment();

        #region Client
        public void RegistrerClient(Client client)
        {
            DA_Client.InsertClient(client);
        }
        #endregion

        #region Product
        public void InsertProduct(Product pProduct)
        {
            DA_Product.InsertProduct(pProduct);
        }
        public void UpdateProduct(Product pProduct)
        {
            DA_Product.UpdateProduct(pProduct);
        }
        public void DeleteProduct(int pProductCode)
        {
            DA_Product.DeleteProduct(pProductCode);
        }

        public List<Product> GetProducts()
        {
           return DA_Product.GetProducts();
        }

        #endregion

        #region Departament
        public void InsertDepartament(Departament pDepartament)
        {
            DA_Departament.InsertDepartament(pDepartament);
        }
        public void UpdateDepartament(Departament pDepartament)
        {
            DA_Departament.UpdateDepartament(pDepartament);
        }
        public void DeleteDepartament(int pDepartamentId)
        {
            DA_Departament.DeleteDepartament(pDepartamentId);
        }
        public List<Departament> GetDepartaments(bool isTypeShoes)
        {
            return DA_Departament.GetDepartaments(isTypeShoes);
        }

        #endregion

        #region Family
        public void InsertFamily(Family pFamily)
        {
            DA_Family.InsertFamily(pFamily);
        }
        public void UpdateFamily(Family pFamily)
        {
            DA_Family.UpdateFamily(pFamily);
        }
        public void DeleteFamily(int pFamilyId)
        {
            DA_Family.DeleteFamily(pFamilyId);
        }
        public List<Family> GetFamilies(int departamentId)
        {
            return DA_Family.GetFamilies(departamentId);
        }

        #endregion

        #region Sale
        public int InsertSale(Sale pSale, int pClientId)
        {
            pSale.SaleAmount = GetTotalAmount();
            return DA_Sale.InsertSale(pSale, pClientId);
        }
        #endregion

        #region LineSale

        public bool InsertLineSale(List<LineSale> listLineSale, int pProductId, int pSaleId)
        {
            return DA_LineSale.InsertLineSale(listLineSale, pProductId, pSaleId);
        }
        public bool InsertToKart(LineSale lineSale)
        {
            return true;
            //List<LineSale> listLS = new List<LineSale>();
            //listLS = (List<LineSale>)ViewState["ListLineSale"];
        }
        
        public void DeleteLineSale(int lineId)
        {
            List<LineSale> listLS = new List<LineSale>();
            listLS = (List<LineSale>)ViewState["ListLineSale"];
            foreach (LineSale oneLS in listLS)
            {
                if (oneLS.LineSaleId == lineId)
                {
                    listLS.Remove(oneLS);
                    ViewState["ListLineSale"] = listLS;
                    break;
                }
            }
        }

        #endregion

        #region Payment
        public bool Payment(bool isCard, string namePayment, Sale pSale, int pClientId, List<LineSale> listLineSale, int pProductId, int pSaleId)
        {
            if (isCard)
            {
                if (DA_Payment.PaymentCard(namePayment))
                {
                    return this.InsertLineSale(listLineSale, pProductId, this.InsertSale(pSale, pClientId));
                }
                return false;
            }
            else
            {
                if (DA_Payment.PaymentTransfer(namePayment))
                {
                    return this.InsertLineSale(listLineSale, pProductId, this.InsertSale(pSale, pClientId));
                }
                return false;
            }
        }

        #endregion

        #region Auxiliary Methods
        public decimal GetTotalAmount()
        {
            decimal totalAmount = 0;
            List<LineSale> listLS = new List<LineSale>();
            listLS = (List<LineSale>)ViewState["ListLineSale"];
            foreach (LineSale oneLS in listLS)
            {
                totalAmount = totalAmount + (oneLS.LineSaleProductPrice * oneLS.LineSaleProductQuantity);
            }
            return totalAmount;
        }
        public List<Product> GetProductsLineSale()
        {
            List<LineSale> listLS = new List<LineSale>();
            listLS = (List<LineSale>)ViewState["ListLineSale"];
            if (listLS.Count > 0)
            {
                int count = 0;
                int[] productIds = new int[listLS.Count - 1];
                foreach (LineSale oneLS in listLS)
                {
                    productIds[count] = oneLS.LineSaleProductId;
                    count++;
                }
                string productIdsForSQL = string.Join("'", productIds);

                return DA_Product.GetProductsLineSale(productIdsForSQL);
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}