namespace ProvenStyle.DemoWebApi.DataMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class instructor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Discriminator");
        }
    }
}
