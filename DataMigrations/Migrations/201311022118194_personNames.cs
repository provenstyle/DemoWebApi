namespace ProvenStyle.DemoWebApi.DataMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "First", c => c.String());
            AddColumn("dbo.Person", "Last", c => c.String());
            DropColumn("dbo.Person", "FirstName");
            DropColumn("dbo.Person", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "LastName", c => c.String());
            AddColumn("dbo.Person", "FirstName", c => c.String());
            DropColumn("dbo.Person", "Last");
            DropColumn("dbo.Person", "First");
        }
    }
}
