using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Online._2_Domain.Entities
{
    public class Sale : Client
    {
        private int saleId;
        private decimal saleAmount;
        private DateTime saleDate;

        public int SaleId { get => saleId; set => saleId = value; }
        public decimal SaleAmount { get => saleAmount; set => saleAmount = value; }
        public DateTime SaleDate { get => saleDate; set => saleDate = value; }

        public Sale(int saleId, decimal saleAmount, DateTime saleDate, int clientId, string clientEmail)
            :base(clientId, clientEmail)
        {
            this.SaleId = saleId;
            this.SaleAmount = saleAmount;
            this.SaleDate = saleDate;
        }

        public Sale()
        {
        }
    }
}