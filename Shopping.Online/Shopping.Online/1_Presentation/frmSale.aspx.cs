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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblTotalAmount.Text = "Precio Total: UYU " + shoppingOnline.GetTotalAmount().ToString();
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            int LineId = Convert.ToInt32(btnDelete.CommandArgument);
            shoppingOnline.DeleteLineSale(LineId);
        }

        protected void rpProductsSale_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            bool isShoes = bool.Parse(DataBinder.Eval(e.Item.DataItem, "DepartamentIsTypeShoes").ToString());
        }
    }
}