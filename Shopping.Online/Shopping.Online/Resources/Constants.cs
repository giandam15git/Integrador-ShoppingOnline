using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Online.Resources
{
    public static class Constants
    {
        public class TypesPayments
        {
            public const string TC = "Tarjeta de Crédito";
            public const string TX = "Transferencia Bancaria";
        }
        public class CardsCompanies
        {
            public const string Visa = "Visa";
            public const string MasterCard = "MasterCard";
            public const string AmericanExpress = "AmericanExpress";
        }
        public class Transfers
        {
            public const string Santander = "Santander";
            public const string BBVA = "BBVA";
            public const string ITAU = "ITAU";
            public const string BROU = "BROU";
        }
    }
}