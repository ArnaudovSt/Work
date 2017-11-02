using Bytes2you.Validation;
using FoodApp.Data.Models;
using FoodApp.Services.Data;
using FoodApp.Web.ResponseModels.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using FoodApp.Web.ResponseModels.MealResponseModels;

namespace FoodApp.Web.Controllers
{
    public class MealsController : ApiController
    {
        private readonly IMealService mealService;

        public MealsController(IMealService mealService)
        {
            Guard.WhenArgument(mealService, "Meal controller meal service").IsNull().Throw();
            this.mealService = mealService;
        }
        // GET api/values
        public IEnumerable<GetMealResponseModel> Get()
        {
            return this.mealService.GetAll()
                .ProjectTo<GetMealResponseModel>().ToArray();
        }
    }
}
