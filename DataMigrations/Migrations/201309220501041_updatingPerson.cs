using System.Data.Entity.Migrations;

namespace ProvenStyle.DemoWebApi.DataMigrations.Migrations
{
    public partial class updatingPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Title");
        }
    }
}
