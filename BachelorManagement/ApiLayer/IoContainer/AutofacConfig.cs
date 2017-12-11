using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using BusinessLayer.Services;
using DataLayer.Repositories;

namespace ApiLayer.IoContainer
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();
                                    
            builder.RegisterRepositories();
            builder.RegisterServices();

            var container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterRepositories(this ContainerBuilder containerBuilder)
        {
            // tell the container to follow this convention for all similar tuples in the same Assembly.
            containerBuilder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest();
        }

        private static void RegisterServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(typeof(AccountService).Assembly)
                .Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
        }
    }
}
