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
        public bool RegistrerClient(Client client)
        {
            return true;
        }

        public string CheckClient(string mail)
        {
            return ClientTypes.Admin;
        }
      
    }
}