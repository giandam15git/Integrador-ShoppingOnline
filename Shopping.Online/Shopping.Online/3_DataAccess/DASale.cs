using Shopping.Online._2_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Shopping.Online._3_DataAccess
{
    public class DASale : Connection
    {
        public int InsertSale(Sale oneSale)
        {
            int saleId = -1;
            string strSQL = "INSERT INTO [dbo].[Sale] ([SaleAmount],[ClientId]) VALUES('" + oneSale.SaleAmount + 
                "', '" + oneSale.ClientId + "') SELECT SCOPE_IDENTITY()";
            DataSet data = ExecuteWithResultSQL(strSQL);
            if (data.Tables[0].Rows.Count > 0)
            {
                saleId = Convert.ToInt32(data.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            return saleId; //Si es -1 es inválido.
        }
    }
}