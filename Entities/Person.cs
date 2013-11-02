namespace ProvenStyle.DemoWebApi.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person()
        {
        }

        public Person(int id, string firstName, string lastName)
            :this(firstName,lastName)
        {
            Id = id;
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}