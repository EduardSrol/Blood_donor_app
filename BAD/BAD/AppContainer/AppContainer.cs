using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAD.AppContainer
{
    public class AppContainer
    {
        private static IWindsorContainer appContainer;

        public static void InitializeContainer()
        {
            appContainer = new WindsorContainer();

            appContainer.Kernel.Resolver.AddSubResolver(new CollectionResolver(appContainer.Kernel));
            appContainer.Install(FromAssembly.InThisApplication(new WindsorBootstrap()));
        }

        public static T Resolve<T>()
        {
            if (appContainer == null)
            {
                InitializeContainer();
            }
            return appContainer.Resolve<T>();
        }

        public static void DisposeContainer()
        {
            appContainer = null;
        }

        public class WindsorBootstrap : InstallerFactory
        {
            public override IEnumerable<Type> Select(IEnumerable<Type> installerTypes)
            {
                var returnVal = installerTypes.OrderBy(x => this.GetPriority(x));
                return returnVal;
            }

            private int GetPriority(Type type)
            {
                var attribute = type.GetCustomAttributes(typeof(InstallerPriorityAttribute), false).FirstOrDefault() as InstallerPriorityAttribute;
                return attribute != null ? attribute.Priority : InstallerPriorityAttribute.DefaultPriority;
            }
        }

        [AttributeUsage(AttributeTargets.Class)]
        public sealed class InstallerPriorityAttribute : Attribute
        {
            public const int DefaultPriority = 100;
            public int Priority { get; private set; }
            public InstallerPriorityAttribute(int priority)
            {
                this.Priority = priority;
            }
        }
    }
}