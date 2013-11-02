using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Highway.Data;
using Highway.Data.EventManagement;

namespace ProvenStyle.DemoWebApi.Data
{
    public class WebDataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var manager = new DatabaseManager("DataLayer");

            container.Register(
                Component.For<IMappingConfiguration>().ImplementedBy<DataMappingConfiguration>().LifeStyle.Singleton,
                Component.For<IDataContext>().ImplementedBy<DataContext>().DependsOn(new { connectionString = manager.ConnectionString }).LifeStyle.PerWebRequest,
                Component.For<IRepository>().ImplementedBy<Repository>().LifeStyle.PerWebRequest,
                Component.For<IRepositoryFactory>().ImplementedBy<RepositoryFactory>(),
                Component.For<IEventManager>().ImplementedBy<EventManager>().LifestyleSingleton()
            );
        }

    }
}
