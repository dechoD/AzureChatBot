using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using IrisBot.Constants;

namespace IrisBot.App_Start
{
    internal class DependencyInjectionConfig
    {
        internal static void Config(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            var globalConfig = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(globalConfig);
            builder.RegisterWebApiModelBinderProvider();
            RegisterServices(builder, new[] { Assemblies.Services });

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder builder, IEnumerable<string> assemblyNames)
        {
            foreach (var name in assemblyNames)
            {
                var assembly = Assembly.Load(name);
                var types = assembly.GetTypes().Where(t => t.IsClass);

                foreach (var type in types)
                {
                    var defaultInterface = type.GetInterfaces().FirstOrDefault(i => i.Name == $"I{type.Name}");

                    if (defaultInterface != null)
                    {
                        builder.RegisterType(type).As(defaultInterface);
                    }
                }
            }
        }
    }
}