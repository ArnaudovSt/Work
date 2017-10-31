namespace Food.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class MigrationsConfiguration : DbMigrationsConfiguration<Food.Data.FoodDbContext>
    {
        public MigrationsConfiguration()
        {
            // TODO: Change to false after db modeling 
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Food.Data.FoodDbContext context)
        {
            if (!context.Foods.Any())
            {
                var test = new Models.Food()
                {
                    Test = "test"
                };

                context.Foods.Add(test);
            }
        }
    }
}
