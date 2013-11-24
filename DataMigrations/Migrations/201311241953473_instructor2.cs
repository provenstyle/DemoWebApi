namespace ProvenStyle.DemoWebApi.DataMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class instructor2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        First = c.String(),
                        Last = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Person", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Instructors");
        }
    }
}
