using System;
using Highway.Data;

namespace ProvenStyle.DemoWebApi.Data
{
    public interface IRepositoryFactory
    {
        void WithRepository(Action<IRepository> action);
        IRepository Create();
        void Release(IRepository repository);
    }
}