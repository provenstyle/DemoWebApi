using System.Data.Entity.ModelConfiguration;
using ProvenStyle.DemoWebApi.Entities;

// ReSharper disable CheckNamespace
namespace ProvenStyle.DemoWebApi.Data
{
    public class PersonMapping : EntityTypeConfiguration<Person>
    {
        public PersonMapping()
        {
            ToTable("Person");
            HasKey(x => x.Id);
        }
    }
}