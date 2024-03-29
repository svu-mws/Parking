﻿using System;
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
            var user = Session["user"];


            if (user == "admin")
            {
                Response.Redirect("/");
            }
            else if (user != null)
            {
                Response.Redirect("user");
            }
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
            else
            {
                var customer = Global.DataSource.login(username, password);
                if (customer.ID != -1)
                {
                    // Check if user exist from database 
                    Session["user"] = username;
                    Session["userID"] = customer.ID;
                    Session["userName"] = customer.Name;
                    Response.Redirect("user");
                }
                else
                    txtResult.Text = "Invalid UserName Or Password";
            }
        }
    }
}