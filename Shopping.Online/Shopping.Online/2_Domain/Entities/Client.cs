using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Online._2_Domain.Entities
{
    public class Client
    {
        private int clientId;
        private string clientFullName;
        private string clientEmail;
        private string clientCI;
        private string clientPhoneNumber;
        private string clientDepartament;
        private string clientCity;
        private string clientAddressBill;
        private bool clientToHome;

        public int ClientId { get => clientId; set => clientId = value; }
        public string ClientFullName { get => clientFullName; set => clientFullName = value; }
        public string ClientEmail { get => clientEmail; set => clientEmail = value; }
        public string ClientCI { get => clientCI; set => clientCI = value; }
        public string ClientPhoneNumber { get => clientPhoneNumber; set => clientPhoneNumber = value; }
        public string ClientDepartament { get => clientDepartament; set => clientDepartament = value; }
        public string ClientCity { get => clientCity; set => clientCity = value; }
        public string ClientAddressBill { get => clientAddressBill; set => clientAddressBill = value; }
        public bool ClientToHome { get => clientToHome; set => clientToHome = value; }

        public Client(int clientId, string clientFullName, string clientEmail, string clientCI, string clientPhoneNumber, string clientDepartament, string clientCity, string clientAddressBill, bool clientToHome)
        {
            this.clientId = clientId;
            this.clientFullName = clientFullName;
            this.clientEmail = clientEmail;
            this.clientCI = clientCI;
            this.clientPhoneNumber = clientPhoneNumber;
            this.clientDepartament = clientDepartament;
            this.clientCity = clientCity;
            this.clientAddressBill = clientAddressBill;
            this.clientToHome = clientToHome;
        }

        public Client()
        {
        }
    }
}