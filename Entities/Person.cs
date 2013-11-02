namespace ProvenStyle.DemoWebApi.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }

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