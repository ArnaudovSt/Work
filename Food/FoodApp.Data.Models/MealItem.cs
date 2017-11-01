using FoodApp.Data.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Data.Models
{
    public class MealItem : DataModel
    {
        [Required]
        [Range(1.0, double.MaxValue)]
        public double WeightInGrams { get; set; }

        public virtual Food Food { get; set; }

        public Guid FoodId { get; set; }
    }
}
