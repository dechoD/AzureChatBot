using System.Web.Http;

namespace IrisBot.App_Start
{
    internal class RoutesConfig
    {
        internal static void Config(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}