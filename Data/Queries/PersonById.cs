using System.Linq;
using Highway.Data;
using ProvenStyle.DemoWebApi.Entities;

namespace ProvenStyle.DemoWebApi.Data
{
    public class PersonById : Scalar<Person>
    {
        public PersonById(int id)
        {
            ContextQuery = c => c.AsQueryable<Person>()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
