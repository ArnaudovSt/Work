using FoodApp.Data.Models;
using FoodApp.Web.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace FoodApp.Web.ResponseModels
{
    public class FoodMapperTest : IMapFrom<Food>, IHaveCustomMappings
    {
        public string Description { get; set; }

        public string CustomMapping { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Food, FoodMapperTest>()
                .ForMember(resposeModel => resposeModel.CustomMapping, cfg => cfg.MapFrom(f => f.Categories.FirstOrDefault().Name));
        }
    }
}