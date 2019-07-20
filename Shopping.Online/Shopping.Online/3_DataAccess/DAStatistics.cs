﻿using Shopping.Online._2_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Shopping.Online._3_DataAccess
{
    public class DAStatistics: Connection
    {
        public List<Product> GetProductByDate(string dateFrom, string dateTo, bool soldIn)
        {
            List<Product> products = new List<Product>();
            string strSQL = "";
            if (soldIn)
            {
                strSQL = "SELECT DISTINCT P.[ProductId], P.[ProductCode],P.[ProductName],P.[ProductDescription],P.[ProductPrice],F.FamilyName,D.DepartamentName " +
                "FROM LineSale LS INNER JOIN Sale S ON LS.SaleId = S.SaleId INNER JOIN Product P ON LS.ProductId = P.ProductId INNER JOIN Family F ON P.FamilyId = F.FamilyId " +
                "INNER JOIN Departament D ON F.DepartamentId = D.DepartamentId WHERE CAST(S.SaleDate as DATE) BETWEEN CAST('" + dateFrom + "' as DATE) AND CAST('" + dateTo + "' as DATE)";
            }
            else
            {
                strSQL = "SELECT DISTINCT P.[ProductId], P.[ProductCode],P.[ProductName],P.[ProductDescription],P.[ProductPrice],F.FamilyName,D.DepartamentName " +
                "FROM Product P INNER JOIN Family F ON P.FamilyId = F.FamilyId INNER JOIN Departament D ON F.DepartamentId = D.DepartamentId " +
                "WHERE P.ProductId NOT IN (SELECT DISTINCT P.[ProductId] FROM LineSale LS INNER JOIN Sale S ON LS.SaleId = S.SaleId INNER JOIN Product P ON LS.ProductId = P.ProductId " +
                "WHERE CAST(S.SaleDate as DATE) BETWEEN CAST('" + dateFrom + "' as DATE) AND CAST('" + dateTo + "' as DATE))";
            }
            DataSet data = ExecuteWithResultSQL(strSQL);
            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Row in data.Tables[0].Rows)
                {
                    Product oneProd = new Product();
                    oneProd.ProductId = Convert.ToInt32(Row.ItemArray[0].ToString());
                    oneProd.ProductCode = Row.ItemArray[1].ToString();
                    oneProd.ProductName = Row.ItemArray[2].ToString();
                    oneProd.ProductDescription = Row.ItemArray[3].ToString();
                    oneProd.ProductPrice = Convert.ToDecimal(Row.ItemArray[4].ToString());
                    oneProd.FamilyName = Row.ItemArray[5].ToString();
                    oneProd.DepartamentName = Row.ItemArray[6].ToString();
                    products.Add(oneProd);
                }
            }
            return products;
        }
    }
}