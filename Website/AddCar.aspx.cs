﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class AddCar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void addCarBtn_Click(object sender, EventArgs e)
        {
            var city = inputCity.Text;
            var company = inputCompany.Text;
            var color = inputColor.Text;
            var arrivalTime = inputArrival.Text;
            var positionID = Convert.ToInt32(inputPosition.Text);
            System.Diagnostics.Debug.WriteLine(city + " " + company + " " + color + " " + arrivalTime+ " " + positionID);
            var customerName = inputCustomer.Text;
            var isRegistered = chkRegistered.Checked; ;

            var result = Global.DataSource.AddCar(city, company, color, arrivalTime, arrivalTime,positionID,customerName, isRegistered);

            if (result.ID != null)
            {
                Response.Redirect("Default.aspx");
            }
            else
                Response.Write(Global.msg("asdasd"));

        }

    }
}