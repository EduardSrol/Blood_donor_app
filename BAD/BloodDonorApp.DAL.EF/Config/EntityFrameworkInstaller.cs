using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.DAL.EF.Config
{
    public class EntityFrameworkInstaller
    {/*
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Choose prefered DAL
            new EntityFrameworkInstaller().Install(container, store);
            //new PetaPocoInstaller().Install(container, store);

            container.Register(
                Classes.FromThisAssembly()
                    .BasedOn(typeof(QueryObjectBase<,,,>))
                    .WithServiceBase()
                    .LifestyleTransient(),

                Classes.FromThisAssembly()
                    .BasedOn<ServiceBase>()
                    .WithServiceDefaultInterfaces()
                    .LifestyleTransient(),

                Classes.FromThisAssembly()
                    .BasedOn<IPriceCalculator>()
                    .WithService.FromInterface()
                    .LifestyleSingleton(),

                Classes.FromThisAssembly()
                    .BasedOn<FacadeBase>()
                    .LifestyleTransient(),

                Component.For<IMapper>()
                    .Instance(new Mapper(new MapperConfiguration(MappingConfig.ConfigureMapping)))
                    .LifestyleSingleton()
            );

            // add collection subresolver in order to resolve IEnumerable in Price Calculator Resolver
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
        }
        */
    }
}
