using Shopping.Online._2_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static Shopping.Online.Resources.Constants;

namespace Shopping.Online._3_DataAccess
{
    public class DAClient : Connection
    {
        public void InsertClient(Client pClient)
        {
            string strSQL = "INSERT INTO dbo.Client([ClientFullName],[ClientEmail],[ClientCI],[ClientPhoneNumber],[ClientDepartament],[ClientCity],[ClientAddressBill],[ClientToHome])" +
                " VALUES('" + pClient.ClientFullName + "','" + pClient.ClientEmail + "','" + pClient.ClientCI + 
                "','" + pClient.ClientPhoneNumber + "','" + pClient.ClientDepartament + "','" + pClient.ClientCity +
                "','" + pClient.ClientAddressBill + "','" + pClient.ClientToHome + "')";
            ExecuteQuerySQL(strSQL);
        }

        public Client GetClient(int clientId)
        {
            string strSQL = "SELECT [ClientId],[ClientFullName],[ClientEmail],[ClientCI],[ClientPhoneNumber],[ClientDepartament],[ClientCity],[ClientAddressBill],[ClientToHome]" +
                "FROM Client WHERE [ClientId] = '" + clientId + "'";
            DataSet data = ExecuteWithResultSQL(strSQL);
            if (data.Tables[0].Rows.Count > 0)
            {
                Client oneCli = new Client()
                {
                    ClientId = Convert.ToInt32(data.Tables[0].Rows[0].ItemArray[0].ToString()),
                    ClientFullName = data.Tables[0].Rows[0].ItemArray[1].ToString(),
                    ClientEmail = data.Tables[0].Rows[0].ItemArray[2].ToString(),
                    ClientCI = data.Tables[0].Rows[0].ItemArray[3].ToString(),
                    ClientPhoneNumber = data.Tables[0].Rows[0].ItemArray[4].ToString(),
                    ClientDepartament = data.Tables[0].Rows[0].ItemArray[5].ToString(),
                    ClientCity = data.Tables[0].Rows[0].ItemArray[6].ToString(),
                    ClientAddressBill = data.Tables[0].Rows[0].ItemArray[7].ToString(),
                    ClientToHome = Convert.ToBoolean(data.Tables[0].Rows[0].ItemArray[8].ToString())
                };
                return oneCli;
            }
            return null;
        }

        public int GetClientId(string clientEmail)
        {
            string strSQL = "SELECT [ClientId] FROM Client WHERE [ClientEmail] = '" + clientEmail + "'";
            DataSet data = ExecuteWithResultSQL(strSQL);
            if (data.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(data.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            return -1; //Si es -1 no se encontró el cliente.
        }
    }
}