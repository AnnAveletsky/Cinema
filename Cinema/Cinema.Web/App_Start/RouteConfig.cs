using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cinema
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Content/{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();
            routes.MapHttpRoute(
                name: "CinemaApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}