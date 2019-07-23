using Shopping.Online._2_Domain.Entities;
using Shopping.Online._2_Domain.Entities_Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping.Online._1_Presentation
{
    public partial class frmStatistics : System.Web.UI.Page
    {
        ShoppingOnline shoppingOnline = new ShoppingOnline();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.SetCalendarToday();
                this.LoadProductsSoldIn();
                this.LoadSalesByDate();
            }
            (this.Master.FindControl("lblCartNumber") as Label).Text = this.shoppingOnline.GetListLineSale().Count.ToString();
        }

        #region LoadData
        private void LoadProductsSoldIn()
        {
            string dateFrom = this.calendarFrom.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss");
            string dateTo = this.calendarTo.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss");
            bool soldIn = true;

            List<Product> productsSoldIn = this.shoppingOnline.GetProductsByDate(dateFrom, dateTo, soldIn);
            this.lblMessageGv.Text = "Productos vendidos en el período seleccionado";
            this.LoadGridGeneric(productsSoldIn);
        }
        private void LoadProductsNotSoldIn()
        {
            string dateFrom = this.calendarFrom.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss");
            string dateTo = this.calendarTo.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss");
            bool soldIn = false;

            List<Product> productsNotSoldIn = this.shoppingOnline.GetProductsByDate(dateFrom, dateTo, soldIn);
            this.lblMessageGv.Text = "Productos NO vendidos en el período selecionado";
            this.LoadGridGeneric(productsNotSoldIn);
        }
        private void LoadGridGeneric(List<Product> products)
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
        private void LoadGridSales(List<Sale> listS)
        {
            if (listS.Count > 0)
            {
                this.gvSales.Visible = true;
                this.gvSales.DataSource = listS;
                this.gvSales.DataBind();
                this.lblMessageSales.Text = "Estas son las ventas:";
            }
            else
            {
                this.gvSales.Visible = false;
                this.lblMessageSales.Text = "No hay ventas en la base de datos.";
            }
        }
        private void LoadSalesByDate()
        {
            string dateFrom = this.calendarFrom.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss");
            string dateTo = this.calendarTo.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss");

            List<Sale> listS = this.shoppingOnline.GetListSalesByDate(dateFrom, dateTo);
            this.lblTotalAmountSales.Text = this.GetTotalAmountOfSales(listS).ToString();
            this.LoadGridSales(listS);
        }
        private void LoadGridListSaleDetail(List<LineSale> listLS)
        {
            if (listLS.Count > 0)
            {
                this.gvLineSales.Visible = true;
                this.lblMessageLineSales.Text = "Este es el detalle de la venta seleccionada:";
                this.gvLineSales.DataSource = listLS;
                this.gvLineSales.DataBind();
            }
            else
            {
                this.lblMessageLineSales.Text = "Aqui debajo se mostrará el detalle de la venta.";
               this.gvLineSales.Visible = false;
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

        #region Buttons
        protected void btnProductsSoldIn_Click(object sender, EventArgs e)
        {
            this.LoadProductsSoldIn();
        }
        protected void btnProductsNotSoldIn_Click(object sender, EventArgs e)
        {
            this.LoadProductsNotSoldIn();
        }
        protected void btnSalesInDb_Click(object sender, EventArgs e)
        {
            this.LoadSalesByDate();
        }
        #endregion

        #region SelectedIndexChanged
        protected void gvSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;
            int saleId = Convert.ToInt32(gridView.SelectedRow.Cells[0].Text);

            List<LineSale> listLS = this.GetListLineSaleBySaleId(saleId);
            this.LoadGridListSaleDetail(this.VerifyLengthOfCharacters(listLS));
        }
        #endregion

        private List<LineSale> VerifyLengthOfCharacters(List<LineSale> listLS)
        {
            foreach (LineSale oneLS in listLS)
            {
                if (oneLS.ProductName.Length > 10)
                {
                    string productNameAux = oneLS.ProductName.Remove(7, oneLS.ProductName.Length-7);
                    oneLS.ProductName = productNameAux + "...";
                }
                if (oneLS.ProductDescription.Length > 10)
                {
                    string productDescriptionAux = oneLS.ProductDescription.Remove(7, oneLS.ProductDescription.Length-7);
                    oneLS.ProductDescription = productDescriptionAux + "...";
                }
            }
            return listLS;
        }
        private List<LineSale> GetListLineSaleBySaleId(int saleId)
        {
            return this.shoppingOnline.GetListLineSalesBySaleId(saleId);
        }
        private decimal GetTotalAmountOfSales(List<Sale> listSales)
        {
            decimal totalAmount = 0;
            if (listSales.Count > 0)
            {
                foreach (Sale oneS in listSales)
                {
                    totalAmount += oneS.SaleAmount;
                }
            }
            return totalAmount;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "openPrintProducts()();", true); 
        }

        protected void btnPrintBillSelected_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "openPrintBill()();", true);
        }
    }
}