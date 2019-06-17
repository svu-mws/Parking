using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(Session["user"] == "")
            // if admin 
            var user = Session["user"];
            if (user != "admin")
            {
                Response.Redirect("login.aspx");
            }


        }
    }
}