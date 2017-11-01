using FoodApp.Data.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Data.Models
{
    public class Meal : DataModel
    {
        private ICollection<MealItem> mealItems;
        public Meal()
        {
            this.mealItems = new HashSet<MealItem>();
        }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<MealItem> MealItems
        {
            get
            {
                return this.mealItems;
            }

            set
            {
                this.mealItems = value;
            }
        }

    }
}
