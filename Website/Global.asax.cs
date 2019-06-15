using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.Web.Http;
using WebApplication1;

namespace Website
{
    public class Global : HttpApplication
    {
        public static AdpDataSource DataSource;

        void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register); // <--- this MUST be first 
           
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DataSource = new AdpDataSource();
        }
        public static string msg(string content)
        {
            return "<script>alert(\"" + content + "\");</script>" ;
        }
    }
}