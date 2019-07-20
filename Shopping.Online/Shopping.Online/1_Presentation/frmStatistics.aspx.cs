using Shopping.Online._2_Domain.Entities;
using Shopping.Online._2_Domain.Entities_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping.Online._1_Presentation
{
    public partial class frmStatistics : System.Web.UI.Page
    {
        ShoppingOnline shopping = new ShoppingOnline();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.SetCalendarToday();
                this.LoadProductsSoldIn();
            }
        }

        #region LoadData
        public void LoadProductsSoldIn()
        {
            string dateFrom = this.calendarFrom.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss");
            string dateTo = this.calendarTo.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss");
            bool soldIn = true;

            List<Product> productsSoldIn = this.shopping.GetProductByDate(dateFrom, dateTo, soldIn);
            this.lblMessageGv.Text = "Productos vendidos en el período selecionado";
            this.LoadGridGeneric(productsSoldIn);
        }
        public void LoadProductsNotSoldIn()
        {
            string dateFrom = this.calendarFrom.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss");
            string dateTo = this.calendarTo.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss");
            bool soldIn = false;

            List<Product> productsNotSoldIn = this.shopping.GetProductByDate(dateFrom, dateTo, soldIn);
            this.lblMessageGv.Text = "Productos NO vendidos en el período selecionado";
            this.LoadGridGeneric(productsNotSoldIn);
        }
        public void LoadGridGeneric(List<Product> products)
        {
            if (products.Count > 0)
            {
                this.gvGenericProducts.Visible = true;
                this.gvGenericProducts.DataSource = products;
                this.gvGenericProducts.DataBind();
            }
            else
            {
                this.gvGenericProducts.Visible = false;
                this.lblMessageGv.Text = "No hay productos en la base de datos.";
            }
        }
        #endregion

        #region Set Data Default
        private void SetCalendarToday()
        {
            this.calendarFrom.SelectedDate = DateTime.Today;
            this.calendarTo.SelectedDate = DateTime.Today;
        }
        #endregion
        protected void gvGenericProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnProductsSoldIn_Click(object sender, EventArgs e)
        {
            this.LoadProductsSoldIn();
        }

        protected void btnProductsNotSoldIn_Click(object sender, EventArgs e)
        {
            this.LoadProductsNotSoldIn();
        }
    }
}