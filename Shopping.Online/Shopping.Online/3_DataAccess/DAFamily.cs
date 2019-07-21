using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shopping.Online._2_Domain.Entities;
using System.Data;

namespace Shopping.Online._3_DataAccess
{
    public class DAFamily : Connection
    {
        public List<Family> GetFamilies(int departamentId)
        {
            List<Family> families = new List<Family>();
            string queryByDept = "WHERE F.FamilyIsDeleted = 0 AND F.DepartamentId = '" + departamentId + "'";
            string queryDefault = "INNER JOIN Departament D ON F.DepartamentId = D.DepartamentId WHERE D.DepartamentIsTypeShoes = 0 AND F.FamilyIsDeleted = 0";
            string query = (departamentId == -1) ? queryDefault : queryByDept;
            string strSQL = "SELECT [FamilyId], [FamilyName] FROM Family F " + query;
            DataSet data = ExecuteWithResultSQL(strSQL);
            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Row in data.Tables[0].Rows)
                {
                    Family oneFam = new Family();
                    oneFam.FamilyId = Convert.ToInt32(Row.ItemArray[0].ToString());
                    oneFam.FamilyName = Row.ItemArray[1].ToString();
                    families.Add(oneFam);
                }
            }
            return families;
        }

        public List<Family> GetFamilies()
        {
            List<Family> families = new List<Family>();
            string strSQL = "SELECT [FamilyId], [FamilyName] FROM Family WHERE FamilyIsDeleted = 0" ;
            DataSet data = ExecuteWithResultSQL(strSQL);
            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Row in data.Tables[0].Rows)
                {
                    Family oneFam = new Family();
                    oneFam.FamilyId = Convert.ToInt32(Row.ItemArray[0].ToString());
                    oneFam.FamilyName = Row.ItemArray[1].ToString();
                    families.Add(oneFam);
                }
            }
            return families;
        }

        public void InsertFamily(Family pFamily)
        {
            string strSQL = "INSERT INTO dbo.Family([FamilyName],[FamilyIsDeleted],[DepartamentId])" +
                " VALUES('" + pFamily.FamilyName + "', 0,'" + pFamily.DepartamentId + "')";
            ExecuteQuerySQL(strSQL);
        }

        public void UpdateFamily(Family pFamily)
        {
            string strSQL = "UPDATE Family SET [FamilyName] = '" + pFamily.FamilyName + "',[DepartamentId] = '" + pFamily.DepartamentId + "'" +
                "WHERE FamilyId = '" + pFamily.FamilyId + "'";
            ExecuteQuerySQL(strSQL);
        }

        public void DeleteFamily(int pFamilyId)
        {
            string strSQL = "UPDATE Family SET [FamilyIsDeleted] = 1 WHERE FamilyId = '" + pFamilyId + "'";
            ExecuteQuerySQL(strSQL);
        }
    }
}