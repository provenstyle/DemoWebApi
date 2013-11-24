using Highway.Data.PrebuiltQueries;

namespace ProvenStyle.DemoWebApi.Entities
{
    public class Person : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Person()
        {
        }
        
        public Person(string first, string last)
        {
            First = first;
            Last = last;
        }
    }
}