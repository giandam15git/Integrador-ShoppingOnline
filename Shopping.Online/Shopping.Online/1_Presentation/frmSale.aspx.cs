using Shopping.Online._2_Domain.Entities_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping.Online._1_Presentation
{
    public partial class frmSale : System.Web.UI.Page
    {
        ShoppingOnline shoppingOnline = new ShoppingOnline();
        private string[] typesPayment = { "Tarjeta de Crédito", "Transferencia Bancaria" };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ListLineSale"] != null)
                {
                    this.LoadProductsLineSale();
                    this.LoadTypePayments();
                    //this.ClientExist(); ToDO
                    this.lblTotalAmount.Text = "Precio Total: UYU " + shoppingOnline.GetTotalAmount().ToString();
                }
                else
                {
                    this.divConfirmSale.Visible = false;
                    this.rpProductsSale.Visible = false;
                }
            }
        }
        #region LoadData
        private void LoadTypePayments()
        {
            this.ddlSelectTypePayment.DataSource = null;
            this.ddlSelectTypePayment.DataSource = typesPayment;
            this.ddlSelectTypePayment.DataBind();
        }

        private void LoadProductsLineSale()
        {
            this.rpProductsSale.DataSource = null;
            this.rpProductsSale.DataSource = shoppingOnline.GetProductsLineSale();
            this.rpProductsSale.DataBind();
        }

        #endregion

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            int ProductId = Convert.ToInt32(btnDelete.CommandArgument);
            shoppingOnline.DeleteLineSale(ProductId);
        }
        protected void rdbClientToHome_CheckedChanged(object sender, EventArgs e)
        {
            //nothing
        }
        protected void rpProductsSale_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            bool isShoes = bool.Parse(DataBinder.Eval(e.Item.DataItem, "DepartamentIsTypeShoes").ToString());
        }
    }
}