using System.Linq;
using Highway.Data;
using ProvenStyle.DemoWebApi.Entities;

// ReSharper disable CheckNamespace
namespace ProvenStyle.DemoWebApi.Data
{
    public class PeopleByFirstName : Query<Person>
    {
        public PeopleByFirstName(string firstName)
        {
            ContextQuery = context => context.AsQueryable<Person>()
                .Where(x => x.FirstName == firstName);
        }
    }
}
