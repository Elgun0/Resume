using System.Web.Mvc;

namespace Resume.Areas.AdminArea
{
    public class AdminAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminArea_default",
                "AdminArea/{controller}/{action}/{id}",
                new {controller="AHome", action = "Index", id = UrlParameter.Optional },
                new string[] { "Resume.Areas.AdminArea.Controllers" }
            );
        }
    }
}