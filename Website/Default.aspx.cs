using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class _Default : Page
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
            var leavingTime = inputLeaving.Text;
            System.Diagnostics.Debug.WriteLine(city + " " + company + " " + color + " " + arrivalTime + " " +
                                               leavingTime);
            Global.DataSource.AddCar(city, company, color, arrivalTime, leavingTime,1);

//            Response.Redirect("Defausdslt.aspx");
        }
    }
}