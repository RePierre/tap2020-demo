using Autofac;
using Autofac.Core;
using System.Linq;
using Tap2020Demo.Examples;
using Tap2020Demo.IoC;
using Uaic.Tap2020Demo.Core;
using Uaic.Tap2020Demo.Core.Accounts;
using Uaic.Tap2020Demo.DataAccess;
using Uaic.Tap2020Demo.DataAccess.Repositories;
using Uaic.Tap2020Demo.DataAccess.SqlServer;
using Uaic.Tap2020Demo.DataAccess.SqlServer.Repositories;

namespace Tap2020Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = AutofacBootstrapper.Bootstrap())
            {
                var example = container.Resolve<DependencyInjectionExample>();
                example.Show();
            }
        }
    }
}
