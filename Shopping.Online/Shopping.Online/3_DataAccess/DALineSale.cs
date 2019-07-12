using Shopping.Online._2_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;

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

        public bool InsertLineSale(List<LineSale> listLineSale, int pProductId, int pSaleId)
        {
            foreach (LineSale oneLS in listLineSale)
            {
                string strSQL = "INSERT INTO [dbo].[LineSale] ([LineSaleProductQuantity],[LineSaleProductPrice],[ProductId],[SaleId]) VALUES('" + oneLS.LineSaleProductQuantity +
                "', '" + oneLS.LineSaleProductPrice + "' , '" + pProductId + "', '" + pSaleId + "')";
                ExecuteQuerySQL(strSQL);
            }
            return true;
        }
    }
}