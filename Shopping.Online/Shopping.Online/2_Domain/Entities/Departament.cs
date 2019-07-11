using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Online._2_Domain.Entities
{
    public class Departament
    {
        private int departamentId;
        private string departamentName;
        private bool departamentIsTypeShoes;

        public Departament(int departamentId, string departamentName, bool departamentIsTypeShoes)
        {
            this.departamentId = departamentId;
            this.departamentName = departamentName;
            this.departamentIsTypeShoes = departamentIsTypeShoes;
        }

        public int DepartamentId { get => departamentId; set => departamentId = value; }
        public string DepartamentName { get => departamentName; set => departamentName = value; }
        public bool DepartamentIsTypeShoes { get => departamentIsTypeShoes; set => departamentIsTypeShoes = value; }

        public Departament() { }
    }
}