using System;
using Castle.Windsor;
using Highway.Data;

namespace ProvenStyle.DemoWebApi.Data
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IWindsorContainer _container;

        public RepositoryFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public void WithRepository(Action<IRepository> action)
        {
            var repo = Create();
            try
            {
                action.Invoke(repo);
            }
            finally
            {
                Release(repo);
            }
        }

        public IRepository Create()
        {
            return _container.Resolve<IRepository>();            
        }

        public void Release(IRepository repository)
        {
            _container.Release(repository);
        }
    }
}
