using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shopping.Online.Resources;
using static Shopping.Online.Resources.Constants;
using static Shopping.Online.Resources.Constants.TypesPayments;

namespace Shopping.Online._3_DataAccess
{
    public class DAPayment
    {
        public bool PaymentCard(string cardCompany, string numberFromPayment /*Para enviar al supuesto servicio*/)
        {
            Random rand = new Random();
            if (cardCompany == CardsCompanies.AmericanExpress)
            {
                return rand.Next(2) == 0;
            }
            else if (cardCompany == CardsCompanies.MasterCard)
            {
                return rand.Next(2) == 0;
            }
            else if(cardCompany == CardsCompanies.Visa)
            {
                return rand.Next(2) == 0;
            }
            else
            {
                return false;
            }
        }

        public bool PaymentTransfer(string bank, string numberFromPayment)
        {
            Random rand = new Random();
            if (bank == Transfers.Santander)
            {
                return rand.Next(2) == 0;
            }
            else if (bank == Transfers.BROU)
            {
                return rand.Next(2) == 0;
            }
            else if (bank == Transfers.BBVA)
            {
                return rand.Next(2) == 0;
            }
            else if (bank == Transfers.ITAU)
            {
                return rand.Next(2) == 0;
            }
            else
            {
                return false;
            }
        }
    }
}