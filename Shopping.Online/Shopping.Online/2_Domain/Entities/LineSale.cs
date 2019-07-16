using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Online._2_Domain.Entities
{
    public class LineSale
    {
        private int lineSaleId;
        private int lineSaleProductQuantity;
        private decimal lineSaleProductPrice;
        private List<LineSale> listLineSale;
        private int lineSaleProductId;

        public int LineSaleId { get => lineSaleId; set => lineSaleId = value; }
        public int LineSaleProductQuantity { get => lineSaleProductQuantity; set => lineSaleProductQuantity = value; }
        public decimal LineSaleProductPrice { get => lineSaleProductPrice; set => lineSaleProductPrice = value; }
        public List<LineSale> ListLineSale { get => listLineSale; set => listLineSale = value; }
        public int LineSaleProductId { get => lineSaleProductId; set => lineSaleProductId = value; }

        public LineSale(int lineSaleId, int lineSaleProductQuantity, decimal lineSaleProductPrice, List<LineSale> listLineSale, int LineSaleProductId)
        {
            this.LineSaleId = lineSaleId;
            this.LineSaleProductQuantity = lineSaleProductQuantity;
            this.LineSaleProductPrice = lineSaleProductPrice;
            this.ListLineSale = listLineSale;
            this.LineSaleProductId = lineSaleProductId;
        }

        public LineSale()
        {
        }
    }
}