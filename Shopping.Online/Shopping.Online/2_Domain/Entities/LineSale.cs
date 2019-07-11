using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Online._2_Domain.Entities
{
    public class LineSale
    {
        private int lineSaleId;
        private string lineSaleProductQuantity;
        private decimal lineSaleProductPrice;
        private List<LineSale> listLineSale;

        public int LineSaleId { get => lineSaleId; set => lineSaleId = value; }
        public string LineSaleProductQuantity { get => lineSaleProductQuantity; set => lineSaleProductQuantity = value; }
        public decimal LineSaleProductPrice { get => lineSaleProductPrice; set => lineSaleProductPrice = value; }
        public List<LineSale> ListLineSale { get => listLineSale; set => listLineSale = value; }

        public LineSale(int lineSaleId, string lineSaleProductQuantity, decimal lineSaleProductPrice, List<LineSale> listLineSale)
        {
            this.LineSaleId = lineSaleId;
            this.LineSaleProductQuantity = lineSaleProductQuantity;
            this.LineSaleProductPrice = lineSaleProductPrice;
            this.ListLineSale = listLineSale;
        }

        public LineSale()
        {
        }
    }
}