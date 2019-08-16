using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaMVC.App_Start
{
    public static class IocConfiguration
    {
        public static Autofac.IContainer Container { get; set; }

        public static T GetInstance<T>()
        {
            return Container.Resolve<T>();
        }

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            RegisterRepositories(builder);
            RegisterServices(builder);
            RegisterControllers(builder);

            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            //builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            //builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
        }

        private static void RegisterControllers(ContainerBuilder builder)
        {
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }
    }
}