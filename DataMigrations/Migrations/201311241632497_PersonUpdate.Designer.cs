// <auto-generated />
namespace ProvenStyle.DemoWebApi.DataMigrations.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    public sealed partial class PersonUpdate : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(PersonUpdate));
        
        string IMigrationMetadata.Id
        {
            get { return "201311241632497_PersonUpdate"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}