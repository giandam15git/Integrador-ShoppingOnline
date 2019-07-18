using Shopping.Online._2_Domain.Entities;
using Shopping.Online._2_Domain.Entities_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Shopping.Online.Resources.Constants;

namespace Shopping.Online._1_Presentation
{
    public partial class frmSale : System.Web.UI.Page
    {
        ShoppingOnline shoppingOnline = new ShoppingOnline();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ListLineSale"] != null)
                {
                    this.LoadProductsLineSale();
                    this.LoadTypePayments();
                    this.LoadPayments(true);
                    //this.ClientExist();
                    this.lblTotalAmount.Text = "Precio Total: UYU " + shoppingOnline.GetTotalAmount().ToString();
                }
                else
                {
                    this.divNotProductsInKart.Visible = true;
                    this.divHasError.Visible = false;
                    this.divSuccess.Visible = false;
                    this.divConfirmSale.Visible = false;
                    this.rpProductsSale.Visible = false;
                }
            }
        }

        #region LoadData
        private void LoadTypePayments()
        {
            string[] typesPayments = { TypesPayments.TC, TypesPayments.TX };
            this.ddlSelectTypePayment.DataSource = null;
            this.ddlSelectTypePayment.DataSource = typesPayments;
            this.ddlSelectTypePayment.DataBind();
        }
        private void LoadPayments(bool isCreditCard)
        {
            string[] cardsCompanies = { CardsCompanies.AmericanExpress, CardsCompanies.MasterCard, CardsCompanies.Visa };
            string[] transfers = { Transfers.BBVA, Transfers.BROU, Transfers.ITAU, Transfers.Santander };
            this.ddlSelectPayment.DataSource = null;
            this.ddlSelectPayment.DataSource = isCreditCard ? cardsCompanies : transfers;
            this.ddlSelectPayment.DataBind();
        }
        private void LoadProductsLineSale()
        {
            this.rpProductsSale.DataSource = null;
            this.rpProductsSale.DataSource = shoppingOnline.GetProductsLineSale();
            this.rpProductsSale.DataBind();
        }
        #endregion

        #region Client
        private void InsertClient()
        {
            Client oneCli = new Client()
            {
                ClientId = -1,
                ClientFullName = this.txtClientFullName.Text,
                ClientEmail = this.txtClientEmail.Text,
                ClientCI = this.txtClientCI.Text,
                ClientPhoneNumber = this.txtClientPhoneNumber.Text,
                ClientDepartament = this.txtClientDepartament.Text,
                ClientCity = this.txtClientCity.Text,
                ClientAddressBill = this.txtClientAddressBill.Text,
                ClientToHome = Convert.ToBoolean(this.rdbClientToHomeY.Checked)
            };
            this.shoppingOnline.InsertClient(oneCli);
        }
        #endregion

        #region Buttons
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            int ProductId = Convert.ToInt32(btnDelete.CommandArgument);
            shoppingOnline.DeleteLineSale(ProductId);
        }
        protected void btnPay_Click(object sender, EventArgs e)
        {
            //Validar que haya compras desde FrontEnd
            bool isCreditCard = ddlSelectTypePayment.SelectedItem.Text == TypesPayments.TC;
            string namePayment = ddlSelectPayment.SelectedItem.Text;
            string numberFromPayment = txtNumberFromPayment.Text; 

            if (Session["ClientId"] == null)
            {
                this.InsertClient();
            }

            this.transactionHasError(this.shoppingOnline.Pay(isCreditCard, namePayment, numberFromPayment));

        }
        #endregion

        #region Auxiliary Methods
        private void transactionHasError(bool hasError)
        {
            if (hasError)
            {
                this.divHasError.Visible = true;
                this.divSuccess.Visible = false;
            }
            else
            {
                this.divHasError.Visible = false;
                this.divSuccess.Visible = true;
            }
        }
        #endregion
        protected void rdbClientToHome_CheckedChanged(object sender, EventArgs e)
        {
            //nothing
        }
        protected void rpProductsSale_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            bool isShoes = bool.Parse(DataBinder.Eval(e.Item.DataItem, "DepartamentIsTypeShoes").ToString());
        }
        protected void ddlSelectTypePayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlSelectTypePayment.SelectedItem.Text == TypesPayments.TC)
            {
                this.LoadPayments(true);
            }
            else
            {
                this.LoadPayments(false);
            }
        }
    }
}