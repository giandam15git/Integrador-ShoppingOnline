using Shopping.Online._2_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using static Shopping.Online.Resources.Enumerate;

namespace Shopping.Online._3_DataAccess
{
    public class DALineSale : Connection
    {
        public List<LineSale> GetDepartaments(bool isTypeShoes)
        {
            List<LineSale> lines = new List<LineSale>();
            string strSQL = "SELECT * FROM LineSale WHERE DepartamentIsDeleted = 0 AND DepartamentIsTypeShoes = '" + isTypeShoes + "'"; //ToDO
            DataSet data = ExecuteWithResultSQL(strSQL);
            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Row in data.Tables[0].Rows)
                {
                    LineSale oneLS = new LineSale();
                    oneLS.LineSaleId = Convert.ToInt32(Row.ItemArray[0].ToString());
                    oneLS.LineSaleProductPrice = Convert.ToDecimal(Row.ItemArray[1].ToString());
                    lines.Add(oneLS);
                }
            }
            return lines;
        }

        public bool InsertLineSale(List<LineSale> listLineSale, int pSaleId)
        {
            foreach (LineSale oneLS in listLineSale)
            {
                int value = 0;
                string size = "";
                if (oneLS.ProductStockSize != null)
                {
                    for (int i = 0; i < oneLS.ProductStockSize.Length; i++)
                    {
                        if (oneLS.ProductStockSize[i] > 0)
                        {
                            value = oneLS.ProductStockSize[i];
                            size = Enum.GetName(typeof(ProductSizes), i);
                        }
                    }
                }
                
                if (size == "")
                {
                    for (int i = 0; i < oneLS.ProductStockSizeShoes.Length; i++)
                    {
                        if (oneLS.ProductStockSizeShoes[i] > 0)
                        {
                            value = oneLS.ProductStockSizeShoes[i];
                            size = Enum.GetName(typeof(ProductSizeShoes), i);
                        }
                    }
                }

                string strSQL = "INSERT INTO [dbo].[LineSale] ([LineSaleProductQuantity],[LineSaleProductPrice],[ProductId],[SaleId]) VALUES('" + oneLS.LineSaleProductQuantity +
                "', '" + oneLS.LineSaleProductPrice + "' , '" + oneLS.LineSaleProductId + "', '" + pSaleId + "') UPDATE StockBySize SET " + size + " = " + size + " - " + value + " " +
                "WHERE StockBySizeId = (SELECT P.StockBySizeId FROM Product P WHERE P.ProductId = '" + oneLS.LineSaleProductId + "')";
                ExecuteQuerySQL(strSQL);
            }
            return true;
        }
    }
}