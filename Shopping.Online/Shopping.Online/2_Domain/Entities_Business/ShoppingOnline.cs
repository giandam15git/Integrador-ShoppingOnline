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
        public void InsertClient(Client pClient)
        {
            DA_Client.InsertClient(pClient);
        }
        public void SetClientIdSession(string clientEmail)
        {
            int clientId = DA_Client.GetClientId(clientEmail);
            if (clientId != -1)
            {
                Session["ClientId"] = clientId;
            }
        }
        public Client GetClient(int clientId)
        {
            return DA_Client.GetClient(clientId);
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
        public int InsertSale(int pClientId)
        {
            decimal saleAmount = GetTotalAmount();
            return DA_Sale.InsertSale(saleAmount, pClientId);
        }
        #endregion

        #region LineSale
        public bool InsertLineSale(List<LineSale> listLineSale, int pSaleId)
        {
            return DA_LineSale.InsertLineSale(listLineSale, pSaleId);
        }
        public void InsertToKart(LineSale lineSale)
        {
            List<LineSale> listLS = new List<LineSale>();
            if (Session["ListLineSale"] != null)
            {
                listLS = (List<LineSale>)Session["ListLineSale"];
            }
            listLS.Add(lineSale);
            Session["ListLineSale"] = listLS;
        }
        public void DeleteLineSale(int productId)
        {
            List<LineSale> listLS = new List<LineSale>();
            listLS = (List<LineSale>)Session["ListLineSale"];
            foreach (LineSale oneLS in listLS)
            {
                if (oneLS.LineSaleProductId == productId)
                {
                    listLS.Remove(oneLS);
                    Session["ListLineSale"] = listLS;
                    break;
                }
            }
        }
        public List<LineSale> GetListLineSale()
        {
            List<LineSale> listLS = new List<LineSale>();
            if (Session["ListLineSale"] != null)
            {
                listLS = (List<LineSale>)Session["ListLineSale"];
            }
            return listLS;
        }
        #endregion

        #region Payment
        public bool Payment(bool isCreditCard, string namePayment, string numberFromPayment, int clientId, List<LineSale> listLineSale)
        {
            if (isCreditCard)
            {
                if (DA_Payment.PaymentCard(namePayment, numberFromPayment))
                {
                    int saleId = this.InsertSale(clientId);
                    return this.InsertLineSale(listLineSale, saleId);
                }
                return false;
            }
            else
            {
                if (DA_Payment.PaymentTransfer(namePayment, numberFromPayment))
                {
                    int saleId = this.InsertSale(clientId);
                    return this.InsertLineSale(listLineSale, saleId);
                }
                return false;
            }
        }
        //Metodo Pago
        public bool Pay(bool isCreditCard, string namePayment, string numberFromPayment)
        {
            int clientId = Convert.ToInt32(Session["ClientId"]);
            bool isSuccess = this.Payment(isCreditCard, namePayment, numberFromPayment, clientId, this.GetListLineSale());
            return isSuccess;
        }
        #endregion


        #region Auxiliary Methods
        public decimal GetTotalAmount()
        {
            decimal totalAmount = 0;
            List<LineSale> listLS = new List<LineSale>();
            listLS = (List<LineSale>)Session["ListLineSale"];
            foreach (LineSale oneLS in listLS)
            {
                totalAmount = totalAmount + (oneLS.LineSaleProductPrice * oneLS.LineSaleProductQuantity);
            }
            return totalAmount;
        }
        public List<Product> GetProductsLineSale()
        {
            if (Session["ListLineSale"] != null)
            {
                List<LineSale> listLS = new List<LineSale>();
                listLS = (List<LineSale>)Session["ListLineSale"];

                if (listLS.Count > 0)
                {
                    int count = 0;
                    int[] productIds = new int[listLS.Count];
                    foreach (LineSale oneLS in listLS)
                    {
                        productIds[count] = oneLS.LineSaleProductId;
                        count++;
                    }
                    string productIdsForSQL = string.Join("','", productIds);

                    return DA_Product.GetProductsLineSale(productIdsForSQL);
                }
                return null;
            }
            return null;
        }

        public List<Family> GetFamilys()
        {
            return DA_Family.GetFamilies();
        }

        public List<Departament> GetDepartaments()
        {
            return DA_Departament.GetDepartaments();
        }
        #endregion
    }
}