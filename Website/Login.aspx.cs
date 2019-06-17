using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            var username = inputUsername.Text;
            var password = inputPassword.Text;


            if (username == "admin" && password == "admin")
            {
                Session["user"] = "admin";
                Response.Redirect("/");

            }
            else if (Global.DataSource.login(username, password))
            {
                // Check if user exist from database 
                Session["user"] = username;
                Response.Redirect("user");


            }
            else
                txtResult.Text = "Invalid UserName Or Password";


        }
    }
}