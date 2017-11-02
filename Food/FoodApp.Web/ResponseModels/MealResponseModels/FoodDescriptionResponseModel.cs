using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodApp.Web.ResponseModels.MealResponseModels
{
    public class FoodDescriptionResponseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}