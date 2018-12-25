namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UCR_ManagementSystem.DatabaseContexts.DatabaseContext.UCRMSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "UCR_ManagementSystem.DatabaseContexts.DatabaseContext.UCRMSystemDbContext";
        }

        protected override void Seed(UCR_ManagementSystem.DatabaseContexts.DatabaseContext.UCRMSystemDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
