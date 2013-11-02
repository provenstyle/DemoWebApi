using Highway.Data;
using ProvenStyle.DemoWebApi.Entities;


namespace ProvenStyle.DemoWebApi.Data
{
    public class AllPeople : Query<Person>
    {
        public AllPeople()
        {
            ContextQuery = c => c.AsQueryable<Person>();
        }
    }
}
