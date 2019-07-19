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
        ShoppingOnline shopping = new ShoppingOnline();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void linkGoToShop_Click(object sender, EventArgs e)
        {
            shopping.SetClientIdSession(this.txtMailWelcome.Text);
            Response.Redirect("frmProducts.aspx");
        }
    }
}