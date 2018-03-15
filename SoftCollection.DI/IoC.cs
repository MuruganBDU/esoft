using Autofac;
using SoftCollection.Repository.Repository;
using SoftCollection.RepositoryInterface.RepositoryInterface;
using SoftCollection.Service;
using SoftCollection.ServiceInterface.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCollection.DI
{
    public class IoC
    {
        private static ContainerBuilder builder;

        public static ContainerBuilder Configure()
        {
            builder = new ContainerBuilder();
            RegisterDependency();
            return builder;
        }
        private static void RegisterDependency()
        {
            builder.RegisterType<LoginService>().As<ILoginService>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<LoginRepository>().As<ILoginRepository>().SingleInstance().PreserveExistingDefaults();
        }
    }
}
