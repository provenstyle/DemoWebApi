using ProvenStyle.DemoWebApi.Entities;
using System.Data.Entity.Migrations;

namespace ProvenStyle.DemoWebApi.DataMigrations.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MigrationsDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MigrationsDataContext context)
        {
            //SeedPersonData(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private static void SeedPersonData(MigrationsDataContext context)
        {
            context.Commit();
        }
    }
}
