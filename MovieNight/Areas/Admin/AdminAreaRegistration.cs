using System.Web.Mvc;

namespace MovieNight.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller="Dashboard", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MovieNight.Areas.Admin.Controllers" }  // Admin alanında Movie Cont ve movie contr. karıştığı için ekledik
            );
        }
    }
}