using FoodApp.Data.Models;
using FoodApp.Services.Common.TimeProvider;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FoodApp.Data.Migrations
{
    public sealed class MigrationsConfiguration : DbMigrationsConfiguration<FoodApp.Data.FoodDbContext>
    {
        public MigrationsConfiguration()
        {
            // TODO: Change to false after db modeling 
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FoodApp.Data.FoodDbContext context)
        {
            SeedSampleData(context);
        }

        private void SeedSampleData(FoodDbContext context)
        {
            if (!context.Meals.Any())
            {
                var category = new Category()
                {
                    Description = new string('c',128),
                    Name = "Category test",
                };

                var anotherCategory = new Category()
                {
                    Name = "Another Category test",
                };

                var food = new Food()
                {
                    Name = "food",
                    CaloriesPerGram = 1,
                    CarbohydratesPerGram = 1,
                    CholestrolPerGram = 1,
                    Description = new string('f', 128),
                    FiberPerGram = 1,
                    ProteinPerGram = 1,
                    IronPerGram = 1,
                    SaturatedFatPerGram = 1,
                    TotalFatPerGram = 1,
                    SugarPerGram = 1,
                    SodiumPerGram = 1,
                    Categories = new HashSet<Category>()
                    {
                        category,
                        anotherCategory
                    }
                };

                var anotherFood = new Food()
                {
                    Name = "anoherFood",
                    CaloriesPerGram = 0,
                    CarbohydratesPerGram = 0,
                    ProteinPerGram = 0,
                    SaturatedFatPerGram = 0,
                    TotalFatPerGram = 0,
                    SugarPerGram = 0,
                    Categories = new HashSet<Category>()
                    {
                        anotherCategory
                    }
                };

                var yetAnotherFood = new Food()
                {
                    Name = "yetAnotherFood",
                    CaloriesPerGram = 0.5,
                    CarbohydratesPerGram = 0.5,
                    ProteinPerGram = 0.5,
                    SaturatedFatPerGram = 0.5,
                    TotalFatPerGram = 0.5,
                    SugarPerGram = 0.5,
                };

                var mealItem = new MealItem()
                {
                    Food = food,
                    WeightInGrams = 100
                };


                var anotherMealItem = new MealItem()
                {
                    Food = anotherFood,
                    WeightInGrams = 100
                };

                var yetAnotherMealItem = new MealItem()
                {
                    Food = yetAnotherFood,
                    WeightInGrams = 100
                };

                var meal = new Meal()
                {
                    MealItems = new HashSet<MealItem>()
                    {
                        mealItem
                    },
                    Date = TimeProvider.Current.Now
                };

                var anotherMeal = new Meal()
                {
                    MealItems = new HashSet<MealItem>()
                    {
                        anotherMealItem
                    },
                    Date = TimeProvider.Current.Now.Date.AddDays(-1)
                };

                var yetAnotherMeal = new Meal()
                {
                    MealItems = new HashSet<MealItem>()
                    {
                        yetAnotherMealItem
                    },
                    Date = TimeProvider.Current.Now.Date.AddDays(-2)
                };

                context.Meals.Add(meal);
                context.Meals.Add(anotherMeal);
                context.Meals.Add(yetAnotherMeal);
            }
        }
    }
}
