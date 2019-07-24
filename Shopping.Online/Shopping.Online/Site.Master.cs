using Shopping.Online._2_Domain.Entities;
using Shopping.Online._2_Domain.Entities_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping.Online
{
    public partial class SiteMaster : MasterPage
    {
        ShoppingOnline shoppingOnline = new ShoppingOnline();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["ClientId"] != null)
            {
                this.linkProducts.Visible = true;
            }
            else
            {
                this.linkProducts.Visible = false;
            }
        }

        protected void IsformFamilies_ServerClick(object sender, EventArgs e)
        {
            Session.Remove("IsformProducts");
            Session["IsformFamilies"] = true;
            Response.Redirect("/1_Presentation/frmGenericABM");
        }
        protected void IsformDepartaments_ServerClick(object sender, EventArgs e)
        {
            Session.Remove("IsformProducts");
            Session["IsformFamilies"] = false;
            Response.Redirect("/1_Presentation/frmGenericABM");
        }

        protected void IsformProducts_ServerClick(object sender, EventArgs e)
        {
            Session["IsformProducts"] = true;
            Response.Redirect("/1_Presentation/frmGenericABM");
        }

        protected void IsStatistics_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("/1_Presentation/frmStatistics");
        }

        protected void linkProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("/1_Presentation/frmProducts");
        }

        protected void lblCartNumber_Init(object sender, EventArgs e)
        {
            this.lblCartNumber.Text = this.shoppingOnline.GetListLineSale().Count.ToString();
        }

        protected void linkCart_ServerClick(object sender, EventArgs e)
        {
            if (Session["ClientId"] != null)
            {
                Response.Redirect("/1_Presentation/frmSale");
            }
            else
            {
                Response.Redirect("/1_Presentation/frmWelcome");
            }
        }
    }
}