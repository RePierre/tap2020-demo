using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Tap2020Demo.Examples;
using Uaic.Tap2020Demo.DataAccess;
using Uaic.Tap2020Demo.DataAccess.Repositories;
using Uaic.Tap2020Demo.DataAccess.SqlServer;
using Uaic.Tap2020Demo.DataAccess.SqlServer.Repositories;

namespace Tap2020Demo.IoC
{
    class AutofacBootstrapper
    {
        public static IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Tap2020DemoContext>().SingleInstance();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>();

            builder.RegisterType<DataRepository>()
                .As<IDataRepository>();

            builder.RegisterType<DependencyInjectionExample>()
                .As<DependencyInjectionExample>();

            return builder.Build();
        }
    }
}
