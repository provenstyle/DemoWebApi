using Highway.Data;

namespace ProvenStyle.DemoWebApi.Data
{
    public interface IRepositoryFactory
    {
        IRepository Create();
        void Release(IRepository repository);
    }
}