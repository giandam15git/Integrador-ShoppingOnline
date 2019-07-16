using Shopping.Online._2_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Shopping.Online.Resources.Constants;

namespace Shopping.Online._3_DataAccess
{
    public class DAClient : Connection
    {
        public void InsertClient(Client pClient)
        {
            string strSQL = "INSERT INTO dbo.Client([ClientName],[ClientEmail],[ClientCI],[ClientPhoneNumber],[ClientDepartament],[ClientCity],[ClientAddressBill],[ClientToHome])" +
                " VALUES('" + pClient.ClientFullName + "','" + pClient.ClientEmail + "','" + pClient.ClientCI + 
                "','" + pClient.ClientPhoneNumber + "','" + pClient.ClientDepartament + "','" + pClient.ClientCity +
                "','" + pClient.ClientAddressBill + "','" + pClient.ClientToHome + "')";
            ExecuteQuerySQL(strSQL);
        }
    }
}