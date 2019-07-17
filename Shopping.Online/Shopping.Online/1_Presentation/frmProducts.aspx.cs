using Shopping.Online._2_Domain.Entities;
using Shopping.Online._2_Domain.Entities_Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Shopping.Online.Resources.Enumerate;

namespace Shopping.Online._1_Presentation
{
    public partial class frmProducts : System.Web.UI.Page
    {
        ShoppingOnline shoppingOnline = new ShoppingOnline();
        Product product = new Product();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadProducts();
            }
        }

        private void LoadProducts()
        {
            this.rpProducts.DataSource = null;
            this.rpProducts.DataSource = shoppingOnline.GetProducts();
            this.rpProducts.DataBind();
        }
        public bool LoadSizeGeneric(bool isShoes, RepeaterItemEventArgs e)
        {
            if (isShoes)
            {
                this.LoadSizeShoes(e);
                return true;
            }
            else
            {
                this.LoadSize(e);
                return true;
            }
        }
        private void LoadSize(RepeaterItemEventArgs e)
        {
            DropDownList ddlProductSize = e.Item.FindControl("ddlProductSizeGeneric") as DropDownList;
            ddlProductSize.DataSource = Enum.GetValues(typeof(ProductSizes));
            ddlProductSize.DataBind();
        }
        private void LoadSizeShoes(RepeaterItemEventArgs e)
        {
            DropDownList ddlProductSizeShoes = e.Item.FindControl("ddlProductSizeGeneric") as DropDownList;
            ddlProductSizeShoes.DataSource = Enum.GetValues(typeof(ProductSizeShoes));
            ddlProductSizeShoes.DataBind();
        }
        protected void rpProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            bool isShoes = bool.Parse(DataBinder.Eval(e.Item.DataItem, "DepartamentIsTypeShoes").ToString());
            this.LoadSizeGeneric(isShoes, e);
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            Button btnBuy = (Button)sender;
            string[] commandArgs = btnBuy.CommandArgument.ToString().Split(new char[] { ',' });
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

            int productId = Convert.ToInt32(commandArgs[0]);
            decimal productPrice = Convert.ToInt32(commandArgs[1]);
            int productQuantity = Convert.ToInt32((item.FindControl("txtProductQuantity") as TextBox).Text);

            LineSale oneLS = new LineSale
            {
                LineSaleId = -1,
                LineSaleProductQuantity = productQuantity,
                LineSaleProductPrice = productPrice,
                ListLineSale = new List<LineSale>(),
                LineSaleProductId = productId
            };

            shoppingOnline.InsertToKart(oneLS);
        }
    }
}