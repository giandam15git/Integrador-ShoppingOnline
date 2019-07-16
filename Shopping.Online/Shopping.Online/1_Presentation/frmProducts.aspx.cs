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
            int productId = Convert.ToInt32(btnBuy.CommandArgument);
            LineSale oneLS = new LineSale
            {
                LineSaleId = -1,
                LineSaleProductQuantity = Convert.ToInt32(this.)
            };
            shoppingOnline.InsertLineSale();
        }
        
    }
}