namespace ExperimentMoq.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExperimentMoq.CustomDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExperimentMoq.CustomDbContext context)
        {
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

            context.DbEntities.AddOrUpdate(dbEntity => dbEntity.Name,
                new DbEntity { Name = "Entity 1" },
                new DbEntity { Name = "Entity 2" },
                new DbEntity { Name = "Entity 3" },
                new DbEntity { Name = "Entity 4" },
                new DbEntity { Name = "Entity 5" });
        }
    }
}
