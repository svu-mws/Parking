using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void addCarBtn_Click(object sender, EventArgs e)
        {

            var customerName = inputCustomer.Text; ;
            var customerPassword = inputPassword.Text;
            var isVIP = chkVIP.Checked; ;
            System.Diagnostics.Debug.WriteLine(customerName + "  " + isVIP);
            var result = Global.DataSource.AddCustomer(customerName,customerPassword, isVIP);

            if (result != null)
            {
                Response.Redirect("AddCar.aspx");
            }
            else
                Response.Write(Global.msg("asdasd"));

        }

    }
}