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

        #region Client
        public void RegistrerClient(Client client)
        {
            DA_Client.RegistrerClient(client);
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


        #endregion

        #region LineSale

        public void InsertLineSale(LineSale pLineSale, int pProductId, int pSaleId)
        { }

        #endregion
    }
}