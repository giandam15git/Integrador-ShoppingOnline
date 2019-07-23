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
            (this.Master.FindControl("lblCartNumber") as Label).Text = this.shoppingOnline.GetListLineSale().Count.ToString();
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
            if ((item.FindControl("ddlProductSizeGeneric") as DropDownList).SelectedIndex > 0)
            {
                if (Convert.ToInt32((item.FindControl("txtProductQuantity") as TextBox).Text) > 0 && (item.FindControl("txtProductQuantity") as TextBox).Text != "")
                {
                    int productId = Convert.ToInt32(commandArgs[0]);
                    if (this.ThereIsStock(productId))
                    {
                        bool isTypeShoes = false;
                        decimal productPrice = Convert.ToInt32(commandArgs[1]);
                        int productQuantity = Convert.ToInt32((item.FindControl("txtProductQuantity") as TextBox).Text);
                        int size = (item.FindControl("ddlProductSizeGeneric") as DropDownList).SelectedIndex;

                        if ((item.FindControl("ddlProductSizeGeneric") as DropDownList).SelectedItem.Text.Length > 1)
                        {
                            isTypeShoes = (item.FindControl("ddlProductSizeGeneric") as DropDownList).SelectedItem.Text.Substring(0, 2) == "EU";
                        }                       

                        LineSale oneLS = new LineSale
                        {
                            LineSaleId = -1,
                            LineSaleProductQuantity = productQuantity,
                            LineSaleProductPrice = productPrice,
                            ListLineSale = new List<LineSale>(),
                            LineSaleProductId = productId
                        };

                        if (isTypeShoes)
                        {
                            oneLS.ProductStockSizeShoes = new int[17];
                            oneLS.ProductStockSizeShoes[size] = productQuantity;
                        }
                        else
                        {
                            oneLS.ProductStockSize = new int[8];
                            oneLS.ProductStockSize[size] = productQuantity;
                        }

                        shoppingOnline.InsertToKart(oneLS);
                        (this.Master.FindControl("lblCartNumber") as Label).Text = this.shoppingOnline.GetListLineSale().Count.ToString();
                    }
                    else
                    {
                        (item.FindControl("lblMessageProduct") as Label).Text = "Lo sentimos, no hay stock.";
                    }
                }
                else
                {
                    (item.FindControl("lblMessageProduct") as Label).Text = "Por favor, ingrese una cantidad mayor a cero.";
                }
            }
            else
            {
                (item.FindControl("lblMessageProduct") as Label).Text = "Por favor, seleccione un talle.";
            }
        }

        private bool ThereIsStock(int productId)
        {
            return this.shoppingOnline.ThereIsStock(productId);
        }
    }
}