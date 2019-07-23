using Shopping.Online._2_Domain.Entities_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping.Online._1_Presentation
{
    public partial class frmWelcome : System.Web.UI.Page
    {
        ShoppingOnline shoppingOnline = new ShoppingOnline();
        protected void Page_Load(object sender, EventArgs e)
        {
            (this.Master.FindControl("lblCartNumber") as Label).Text = this.shoppingOnline.GetListLineSale().Count.ToString();
        }
        protected void linkGoToShop_Click(object sender, EventArgs e)
        {
            shoppingOnline.SetClientIdSession(this.txtEmailWelcome.Text);
            Session["ClientEmail"] = this.txtEmailWelcome.Text;
            Response.Redirect("frmProducts.aspx");
        }
    }
}