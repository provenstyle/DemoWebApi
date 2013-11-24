namespace ProvenStyle.DemoWebApi.DataMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingPerson : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Person");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        First = c.String(),
                        Last = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
