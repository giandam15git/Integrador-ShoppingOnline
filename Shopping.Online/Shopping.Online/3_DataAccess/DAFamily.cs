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
            string strSQL = "SELECT * FROM Family WHERE FamilyIsDeleted = 0 AND DepartamentId = '" + departamentId + "'";
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
                "WHERE DeparamentId = '" + pFamily.DepartamentId + "'";
            ExecuteQuerySQL(strSQL);
        }

        public void DeleteFamily(int pFamilyId)
        {
            string strSQL = "UPDATE Family SET [FamilyIsDeleted] = 1 WHERE FamilyId = '" + pFamilyId + "'";
            ExecuteQuerySQL(strSQL);
        }
    }
}