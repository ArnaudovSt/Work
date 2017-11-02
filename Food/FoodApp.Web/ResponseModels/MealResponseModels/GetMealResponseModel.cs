using FoodApp.Data.Models;
using FoodApp.Web.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace FoodApp.Web.ResponseModels.MealResponseModels
{
    public class GetMealResponseModel : IMapFrom<Meal>, IHaveCustomMappings
    {
        public DateTime Date { get; set; }

        public ICollection<FoodDescriptionResponseModel> FoodDescription { get; set; }

        public double SumOfCaloriesPerGram { get; set; }

        public double SumOfTotalFatPerGram { get; set; }

        public double SumOfSaturatedFatPerGram { get; set; }

        public double SumOfProteinPerGram { get; set; }

        public double SumOfCarbohydratesPerGram { get; set; }

        public double SumOfSugarPerGram { get; set; }

        public double? SumOfFiberPerGram { get; set; }

        public double? SumOfSodiumPerGram { get; set; }

        public double? SumOfIronPerGram { get; set; }

        public double? SumOfCholestrolPerGram { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Meal, GetMealResponseModel>()
                .ForMember(responseModel => responseModel.FoodDescription,
                cfg => cfg.MapFrom(m => m.MealItems.Select(mi => new FoodDescriptionResponseModel()
                {
                    Categories = mi.Food.Categories.Select(f => f.Name),
                    Name = mi.Food.Name,
                    Description = mi.Food.Description
                })));
        }
    }
}