using System.Web.Http;
using IrisBot.App_Start;

namespace IrisBot
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            DependencyInjectionConfig.Config(config);
            FormattersConfig.Config(config);
            RoutesConfig.Config(config);
        }
    }
}
