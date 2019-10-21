using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BloodDonorApp.BL.EF.AppContainer
{
    public class MapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMapper>().ImplementedBy<Mapper>().LifestyleSingleton());
            container.Register(Component.For<IConfigurationProvider>().UsingFactoryMethod<IConfigurationProvider>(MapperConfigurationFactory.GetConfiguration).LifestyleSingleton());
        }
    }
}