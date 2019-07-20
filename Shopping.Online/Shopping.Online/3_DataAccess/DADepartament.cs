using Shopping.Online._2_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Shopping.Online._3_DataAccess
{
    public class DADepartament : Connection
    {
        public List<Departament> GetDepartaments(bool isTypeShoes)
        {
            List<Departament> departaments = new List<Departament>();
            string strSQL = "SELECT * FROM Departament WHERE DepartamentIsDeleted = 0 AND DepartamentIsTypeShoes = '" + isTypeShoes + "'";
            DataSet data = ExecuteWithResultSQL(strSQL);
            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Row in data.Tables[0].Rows)
                {
                    Departament oneDep = new Departament();
                    oneDep.DepartamentId = Convert.ToInt32(Row.ItemArray[0].ToString());
                    oneDep.DepartamentName = Row.ItemArray[1].ToString();
                    departaments.Add(oneDep);
                }
            }
            return departaments;
        }
        public List<Departament> GetDepartaments()
        {
            List<Departament> departaments = new List<Departament>();
            string strSQL = "SELECT * FROM Departament WHERE DepartamentIsDeleted = 0";
            DataSet data = ExecuteWithResultSQL(strSQL);
            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Row in data.Tables[0].Rows)
                {
                    Departament oneDep = new Departament();
                    oneDep.DepartamentId = Convert.ToInt32(Row.ItemArray[0].ToString());
                    oneDep.DepartamentName = Row.ItemArray[1].ToString();
                    departaments.Add(oneDep);
                }
            }
            return departaments;
        }


        public void InsertDepartament(Departament pDepartament)
        {
            string strSQL = "INSERT INTO dbo.Departament([DepartamentName],[DepartamentIsTypeShoes],[DepartamentIsDeleted])" +
                " VALUES('" + pDepartament.DepartamentName + "','" + pDepartament.DepartamentIsTypeShoes + "', 0)";
            ExecuteQuerySQL(strSQL);
        }

        public void UpdateDepartament(Departament pDepartament)
        {
            string strSQL = "UPDATE Departament SET [DepartamentName] = '" + pDepartament.DepartamentName + "',[DepartamentIsTypeShoes] = '" + pDepartament.DepartamentIsTypeShoes + "'" +
                "WHERE DeparamentId = '" + pDepartament.DepartamentId + "'";
            ExecuteQuerySQL(strSQL);
        }

        public void DeleteDepartament(int pDepartamentId)
        {
            string strSQL = "UPDATE Departament SET [DepartamentIsDeleted] = 1 WHERE DepartamentId = '" + pDepartamentId + "'";
            ExecuteQuerySQL(strSQL);
        }
    }
}