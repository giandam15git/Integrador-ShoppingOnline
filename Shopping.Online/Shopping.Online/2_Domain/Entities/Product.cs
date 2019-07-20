using Shopping.Online.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.SessionState;

namespace Shopping.Online._2_Domain.Entities
{
    public class Product : Family
    {
        private int productId;
        private string productCode;
        private string productName;
        private string productDescription;
        private string productImage;
        private string productGenre;
        private string productColor;
        private int[] productStockSize; //está relacionado con enum ProductSizes (dese index 1 - x) 
        private int[] productStockSizeShoes; //está relacionado con enum ProductSizeShoes (dese index 1 - x) 
        private decimal productPrice;
        private List<Product> listProducts;


        #region gets and sets
        public int ProductId { get => productId; set => productId = value; }
        public string ProductCode { get => productCode; set => productCode = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string ProductDescription { get => productDescription; set => productDescription = value; }
        public string ProductImage { get => productImage; set => productImage = value; }
        public string ProductGenre { get => productGenre; set => productGenre = value; }
        public string ProductColor { get => productColor; set => productColor = value; }
        public int[] ProductStockSize { get => productStockSize; set => productStockSize = value; }
        public int[] ProductStockSizeShoes { get => productStockSizeShoes; set => productStockSizeShoes = value; }
        public decimal ProductPrice { get => productPrice; set => productPrice = value; }
        public List<Product> ListProducts { get => listProducts; set => listProducts = value; }
        #endregion

        public Product(int productId, string productCode, string productName, string productDescription, string productImage, string productGenre, string productColor, int[] productStockSize, int[] productStockSizeShoes, decimal productPrice, int familyId, string familyName, int departamentId, string departamentName, bool departamentIsTypeShoes)
            : base(familyId, familyName, departamentId, departamentName, departamentIsTypeShoes)
        {
            this.ProductId = productId;
            this.ProductCode = productCode;
            this.ProductName = productName;
            this.ProductDescription = productDescription;
            this.ProductImage = productImage;
            this.ProductGenre = productGenre;
            this.ProductColor = productColor;
            this.ProductStockSize = productStockSize;
            this.ProductStockSizeShoes = productStockSizeShoes;
            this.ProductPrice = productPrice;
        }

        public Product() { }
    }
}