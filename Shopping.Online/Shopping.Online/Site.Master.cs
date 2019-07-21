using Shopping.Online._2_Domain.Entities;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ListLineSale"] != null)
            {
                this.CartNumber.InnerText = ((List<LineSale>)Session["ListLineSale"]).Count.ToString();
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
    }
}