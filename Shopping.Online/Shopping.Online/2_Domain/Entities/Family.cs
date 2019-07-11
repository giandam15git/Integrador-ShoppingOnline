using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Online._2_Domain.Entities
{
    public class Family : Departament
    {
        private int familyId;
        private string familyName;

        public Family(int familyId, string familyName, int departamentId, string departamentName, bool departamentIsTypeShoes)
            : base(departamentId, departamentName, departamentIsTypeShoes)
        {
            this.FamilyId = familyId;
            this.FamilyName = familyName;
        }

        public Family() { }

        public int FamilyId { get => familyId; set => familyId = value; }
        public string FamilyName { get => familyName; set => familyName = value; }
    }
}