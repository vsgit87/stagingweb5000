using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using mvcapp.Models;
namespace mvcapp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public List<Course> dtset;
        protected void Application_Start()
        {

            dtset = new List<Course>()
            {
                new Course {Id=1,Name="AZ-104", Description="Microsoft Azure Administrator", Rating=4.5},
                new Course {Id=2,Name="AZ-204", Description="Microsoft Azure Developer", Rating=4.6},
                new Course {Id=3,Name="AZ-303", Description="Microsoft Azure Architect", Rating=4.7}
            };
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["dtset"] = dtset;
            System.Web.HttpContext.Current.Application.UnLock();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
