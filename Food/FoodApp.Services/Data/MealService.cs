using Bytes2you.Validation;
using FoodApp.Data.ContextWrapper;
using FoodApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services.Data
{
    public class MealService : IMealService
    {
        private readonly IContextWrapper<Meal> mealSet;

        public MealService(IContextWrapper<Meal> mealSet)
        {
            Guard.WhenArgument(mealSet, "Meal service meal set").IsNull().Throw();

            this.mealSet = mealSet;
        }

        public IQueryable<Meal> GetAll()
        {
            return this.mealSet.All;
        }
    }
}
