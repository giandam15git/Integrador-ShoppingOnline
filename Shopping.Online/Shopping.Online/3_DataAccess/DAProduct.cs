using Shopping.Online._2_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Shopping.Online._3_DataAccess
{
    public class DAProduct : Connection
    {
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            string strSQL = "SELECT [ProductId],[ProductCode],[ProductName],[ProductDescription],[ProductImage],[ProductGenre],[ProductColor],[ProductPrice],P.[FamilyId]," +
                "[XS],[S],[M],[L],[XL],[XXL],[XXXL],[EU34],[EU35],[EU36],[EU37],[EU38],[EU39],[EU40],[EU41],[EU42],[EU43],[EU44],[EU45],[EU46],[EU47],[EU48],[EU49],[FamilyName],F.[DepartamentId],[DepartamentName],[DepartamentIsTypeShoes]" +
                "FROM Product P INNER JOIN StockBySize SBS ON P.StockBySizeId = SBS.StockBySizeId INNER JOIN Family F ON P.FamilyId = F.FamilyId INNER JOIN Departament D ON F.DepartamentId = D.DepartamentId";
            DataSet data = ExecuteWithResultSQL(strSQL);
            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Row in data.Tables[0].Rows)
                {
                    Product oneProd = new Product();
                    oneProd.ProductStockSize = new int[8];
                    oneProd.ProductStockSizeShoes = new int[17];
                    oneProd.ProductId = Convert.ToInt32(Row.ItemArray[0].ToString());
                    oneProd.ProductCode = Row.ItemArray[1].ToString();
                    oneProd.ProductName = Row.ItemArray[2].ToString();
                    oneProd.ProductDescription = Row.ItemArray[3].ToString();
                    oneProd.ProductImage = Row.ItemArray[4].ToString();
                    oneProd.ProductGenre = Row.ItemArray[5].ToString();
                    oneProd.ProductColor = Row.ItemArray[6].ToString();
                    oneProd.ProductPrice = Convert.ToDecimal(Row.ItemArray[7].ToString());
                    oneProd.FamilyId = Convert.ToInt32(Row.ItemArray[8].ToString());
                    oneProd.ProductStockSize[1] = Convert.ToInt32(Row.ItemArray[9].ToString());
                    oneProd.ProductStockSize[2] = Convert.ToInt32(Row.ItemArray[10].ToString());
                    oneProd.ProductStockSize[3] = Convert.ToInt32(Row.ItemArray[11].ToString());
                    oneProd.ProductStockSize[4] = Convert.ToInt32(Row.ItemArray[12].ToString());
                    oneProd.ProductStockSize[5] = Convert.ToInt32(Row.ItemArray[13].ToString());
                    oneProd.ProductStockSize[6] = Convert.ToInt32(Row.ItemArray[14].ToString());
                    oneProd.ProductStockSize[7] = Convert.ToInt32(Row.ItemArray[15].ToString());
                    oneProd.ProductStockSizeShoes[1] = Convert.ToInt32(Row.ItemArray[16].ToString());
                    oneProd.ProductStockSizeShoes[2] = Convert.ToInt32(Row.ItemArray[17].ToString());
                    oneProd.ProductStockSizeShoes[3] = Convert.ToInt32(Row.ItemArray[18].ToString());
                    oneProd.ProductStockSizeShoes[4] = Convert.ToInt32(Row.ItemArray[19].ToString());
                    oneProd.ProductStockSizeShoes[5] = Convert.ToInt32(Row.ItemArray[20].ToString());
                    oneProd.ProductStockSizeShoes[6] = Convert.ToInt32(Row.ItemArray[21].ToString());
                    oneProd.ProductStockSizeShoes[7] = Convert.ToInt32(Row.ItemArray[22].ToString());
                    oneProd.ProductStockSizeShoes[8] = Convert.ToInt32(Row.ItemArray[23].ToString());
                    oneProd.ProductStockSizeShoes[9] = Convert.ToInt32(Row.ItemArray[24].ToString());
                    oneProd.ProductStockSizeShoes[10] = Convert.ToInt32(Row.ItemArray[25].ToString());
                    oneProd.ProductStockSizeShoes[11] = Convert.ToInt32(Row.ItemArray[26].ToString());
                    oneProd.ProductStockSizeShoes[12] = Convert.ToInt32(Row.ItemArray[27].ToString());
                    oneProd.ProductStockSizeShoes[13] = Convert.ToInt32(Row.ItemArray[28].ToString());
                    oneProd.ProductStockSizeShoes[14] = Convert.ToInt32(Row.ItemArray[29].ToString());
                    oneProd.ProductStockSizeShoes[15] = Convert.ToInt32(Row.ItemArray[30].ToString());
                    oneProd.ProductStockSizeShoes[16] = Convert.ToInt32(Row.ItemArray[31].ToString());
                    oneProd.FamilyName = Row.ItemArray[32].ToString();
                    oneProd.DepartamentId = Convert.ToInt32(Row.ItemArray[33].ToString());
                    oneProd.DepartamentName = Row.ItemArray[34].ToString();
                    oneProd.DepartamentIsTypeShoes = Convert.ToBoolean(Row.ItemArray[35].ToString());
                    products.Add(oneProd);
                }
            }
            return products;
        }
        public List<Product> GetProductsLineSale(string productIdsForSQL)
        {
            List<Product> products = new List<Product>();
            string strSQL = "SELECT [ProductId],[ProductCode],[ProductName],[ProductDescription],[ProductImage],[ProductGenre],[ProductColor],[ProductPrice],P.[FamilyId]," +
                "[XS],[S],[M],[L],[XL],[XXL],[XXXL],[EU34],[EU35],[EU36],[EU37],[EU38],[EU39],[EU40],[EU41],[EU42],[EU43],[EU44],[EU45],[EU46],[EU47],[EU48],[EU49],[FamilyName],F.[DepartamentId],[DepartamentName],[DepartamentIsTypeShoes]" +
                "FROM Product P INNER JOIN StockBySize SBS ON P.StockBySizeId = SBS.StockBySizeId INNER JOIN Family F ON P.FamilyId = F.FamilyId INNER JOIN Departament D ON F.DepartamentId = D.DepartamentId WHERE ProductId IN '" + "('"+ productIdsForSQL + "')" + "'";
            DataSet data = ExecuteWithResultSQL(strSQL);
            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Row in data.Tables[0].Rows)
                {
                    Product oneProd = new Product();
                    oneProd.ProductStockSize = new int[8];
                    oneProd.ProductStockSizeShoes = new int[17];
                    oneProd.ProductId = Convert.ToInt32(Row.ItemArray[0].ToString());
                    oneProd.ProductCode = Row.ItemArray[1].ToString();
                    oneProd.ProductName = Row.ItemArray[2].ToString();
                    oneProd.ProductDescription = Row.ItemArray[3].ToString();
                    oneProd.ProductImage = Row.ItemArray[4].ToString();
                    oneProd.ProductGenre = Row.ItemArray[5].ToString();
                    oneProd.ProductColor = Row.ItemArray[6].ToString();
                    oneProd.ProductPrice = Convert.ToDecimal(Row.ItemArray[7].ToString());
                    oneProd.FamilyId = Convert.ToInt32(Row.ItemArray[8].ToString());
                    oneProd.ProductStockSize[1] = Convert.ToInt32(Row.ItemArray[9].ToString());
                    oneProd.ProductStockSize[2] = Convert.ToInt32(Row.ItemArray[10].ToString());
                    oneProd.ProductStockSize[3] = Convert.ToInt32(Row.ItemArray[11].ToString());
                    oneProd.ProductStockSize[4] = Convert.ToInt32(Row.ItemArray[12].ToString());
                    oneProd.ProductStockSize[5] = Convert.ToInt32(Row.ItemArray[13].ToString());
                    oneProd.ProductStockSize[6] = Convert.ToInt32(Row.ItemArray[14].ToString());
                    oneProd.ProductStockSize[7] = Convert.ToInt32(Row.ItemArray[15].ToString());
                    oneProd.ProductStockSizeShoes[1] = Convert.ToInt32(Row.ItemArray[16].ToString());
                    oneProd.ProductStockSizeShoes[2] = Convert.ToInt32(Row.ItemArray[17].ToString());
                    oneProd.ProductStockSizeShoes[3] = Convert.ToInt32(Row.ItemArray[18].ToString());
                    oneProd.ProductStockSizeShoes[4] = Convert.ToInt32(Row.ItemArray[19].ToString());
                    oneProd.ProductStockSizeShoes[5] = Convert.ToInt32(Row.ItemArray[20].ToString());
                    oneProd.ProductStockSizeShoes[6] = Convert.ToInt32(Row.ItemArray[21].ToString());
                    oneProd.ProductStockSizeShoes[7] = Convert.ToInt32(Row.ItemArray[22].ToString());
                    oneProd.ProductStockSizeShoes[8] = Convert.ToInt32(Row.ItemArray[23].ToString());
                    oneProd.ProductStockSizeShoes[9] = Convert.ToInt32(Row.ItemArray[24].ToString());
                    oneProd.ProductStockSizeShoes[10] = Convert.ToInt32(Row.ItemArray[25].ToString());
                    oneProd.ProductStockSizeShoes[11] = Convert.ToInt32(Row.ItemArray[26].ToString());
                    oneProd.ProductStockSizeShoes[12] = Convert.ToInt32(Row.ItemArray[27].ToString());
                    oneProd.ProductStockSizeShoes[13] = Convert.ToInt32(Row.ItemArray[28].ToString());
                    oneProd.ProductStockSizeShoes[14] = Convert.ToInt32(Row.ItemArray[29].ToString());
                    oneProd.ProductStockSizeShoes[15] = Convert.ToInt32(Row.ItemArray[30].ToString());
                    oneProd.ProductStockSizeShoes[16] = Convert.ToInt32(Row.ItemArray[31].ToString());
                    oneProd.FamilyName = Row.ItemArray[32].ToString();
                    oneProd.DepartamentId = Convert.ToInt32(Row.ItemArray[33].ToString());
                    oneProd.DepartamentName = Row.ItemArray[34].ToString();
                    oneProd.DepartamentIsTypeShoes = Convert.ToBoolean(Row.ItemArray[35].ToString());
                    products.Add(oneProd);
                }
            }
            return products;
        }
        public void InsertProduct(Product pProduct)
        {
            string strSQL = "DECLARE @StockBySizeId INT " +
                "INSERT INTO dbo.StockBySize([XS],[S],[M],[L],[XL],[XXL],[XXXL],[EU34],[EU35],[EU36],[EU37],[EU38],[EU39],[EU40],[EU41],[EU42],[EU43],[EU44],[EU45],[EU46],[EU47],[EU48],[EU49]) VALUES('" + pProduct.ProductStockSize[1] +
                    "', '" + pProduct.ProductStockSize[2] + "', '" + pProduct.ProductStockSize[3] +
                    "', '" + pProduct.ProductStockSize[4] + "', '" + pProduct.ProductStockSize[5] +
                    "', '" + pProduct.ProductStockSize[6] + "', '" + pProduct.ProductStockSize[7] +
                    "', '" + pProduct.ProductStockSizeShoes[1] + "', '" + pProduct.ProductStockSizeShoes[2] +
                    "', '" + pProduct.ProductStockSizeShoes[3] + "', '" + pProduct.ProductStockSizeShoes[4] +
                    "', '" + pProduct.ProductStockSizeShoes[5] + "', '" + pProduct.ProductStockSizeShoes[6] +
                    "', '" + pProduct.ProductStockSizeShoes[7] + "', '" + pProduct.ProductStockSizeShoes[8] +
                    "', '" + pProduct.ProductStockSizeShoes[9] + "', '" + pProduct.ProductStockSizeShoes[10] +
                    "', '" + pProduct.ProductStockSizeShoes[11] + "', '" + pProduct.ProductStockSizeShoes[12] +
                    "', '" + pProduct.ProductStockSizeShoes[13] + "', '" + pProduct.ProductStockSizeShoes[14] +
                    "', '" + pProduct.ProductStockSizeShoes[15] + "', '" + pProduct.ProductStockSizeShoes[16] +
                "') SELECT @StockBySizeId = SCOPE_IDENTITY() INSERT INTO dbo.Product([ProductCode],[ProductName],[ProductDescription],[ProductImage],[ProductGenre],[ProductColor],[ProductPrice],[ProductIsDeleted],[StockBySizeId],[FamilyId]) VALUES('" + pProduct.ProductCode +
                    "', '" + pProduct.ProductName + "', '" + pProduct.ProductDescription + 
                    "', '" + pProduct.ProductImage + "', '" + pProduct.ProductGenre + 
                    "', '" + pProduct.ProductColor + "', '" + pProduct.ProductPrice + "', 0, @StockBySizeId, '" + pProduct.FamilyId + "')";
            ExecuteQuerySQL(strSQL);
        }
        public void UpdateProduct(Product pProduct)
        {
            string strSQL = "UPDATE Product SET [ProductCode]= '" + pProduct.ProductCode + "',[ProductName] = '" + pProduct.ProductName + 
                                     "',[ProductDescription] = '" + pProduct.ProductDescription + "',[ProductImage] = '" + pProduct.ProductImage + 
                                     "',[ProductGenre] = '" + pProduct.ProductGenre + "',[ProductColor] = '" + pProduct.ProductColor + 
                                     "',[ProductPrice] = '" + pProduct.ProductPrice + "' ,[FamilyId] = '" + pProduct.FamilyId + "'  WHERE ProductId = '" + pProduct.ProductId + "';" +
                            "UPDATE StockBySize SET [XS] = '" + pProduct.ProductStockSize[1] + "',[S] = '" + pProduct.ProductStockSize[2] +
                                    "',[M] = '" + pProduct.ProductStockSize[3] + "',[L] = '" + pProduct.ProductStockSize[4] + "',[XL] = '" + pProduct.ProductStockSize[5] +
                                    "',[XXL] = '" + pProduct.ProductStockSize[6] + "',[XXXL] = '" + pProduct.ProductStockSize[7] + "',[EU34] = '" + pProduct.ProductStockSizeShoes[1] +
                                    "',[EU35] = '" + pProduct.ProductStockSizeShoes[2] + "',[EU36] = '" + pProduct.ProductStockSizeShoes[3] + "',[EU37] = '" + pProduct.ProductStockSizeShoes[4] +
                                    "',[EU38] = '" + pProduct.ProductStockSizeShoes[5] + "',[EU39] = '" + pProduct.ProductStockSizeShoes[6] + "',[EU40] = '" + pProduct.ProductStockSizeShoes[7] + 
                                    "',[EU41] = '" + pProduct.ProductStockSizeShoes[8] + "',[EU42] = '" + pProduct.ProductStockSizeShoes[9] + "',[EU43] = '" + pProduct.ProductStockSizeShoes[10] +
                                    "',[EU44] = '" + pProduct.ProductStockSizeShoes[11] + "',[EU45] = '" + pProduct.ProductStockSizeShoes[12] + "',[EU46] = '" + pProduct.ProductStockSizeShoes[13] +
                                    "',[EU47] = '" + pProduct.ProductStockSizeShoes[14] + "',[EU48] = '" + pProduct.ProductStockSizeShoes[15] + "',[EU49] = '" + pProduct.ProductStockSizeShoes[16] + "' WHERE StockBySizeId = '" + pProduct.ProductId + "'";
            ExecuteQuerySQL(strSQL);
        }
        public void DeleteProduct(int pProductId)
        {
            string strSQL = "UPDATE Product SET ProductIsDeleted = 1 WHERE ProductId = " + pProductId;
            ExecuteQuerySQL(strSQL);
        }

    }
}