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
    public class FoodService : IFoodService
    {
        private readonly IContextWrapper<Food> foodSet;

        public FoodService(IContextWrapper<Food> foodSet)
        {
            Guard.WhenArgument(foodSet, "Food service food set").IsNull().Throw();

            this.foodSet = foodSet;
        }

        public IQueryable<Food> GetAll()
        {
            return this.foodSet.All;
        }
    }
}
