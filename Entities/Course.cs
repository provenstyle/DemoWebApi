using Highway.Data.PrebuiltQueries;

namespace ProvenStyle.DemoWebApi.Entities
{
    public class Course : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
