namespace ProvenStyle.DemoWebApi.DataMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Email", c => c.String());
            AddColumn("dbo.Person", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Phone");
            DropColumn("dbo.Person", "Email");
        }
    }
}
