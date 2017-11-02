using FoodApp.Data.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Data.Models
{
    public class Food : DataModel
    {
        private ICollection<Category> categories;

        public Food()
        {
            this.categories = new HashSet<Category>();
        }

        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(2048, MinimumLength = 128)]
        public string Description { get; set; }

        [Required]
        [Range(0.0,128.0)]
        public double CaloriesPerGram { get; set; }

        [Required]
        [Range(0.0, 1.0)]
        public double TotalFatPerGram { get; set; }

        [Required]
        [Range(0.0, 1.0)]
        public double SaturatedFatPerGram { get; set; }

        [Required]
        [Range(0.0, 1.0)]
        public double ProteinPerGram { get; set; }

        [Required]
        [Range(0.0, 1.0)]
        public double CarbohydratesPerGram { get; set; }

        [Required]
        [Range(0.0, 1.0)]
        public double SugarPerGram { get; set; }

        [Range(0.0, 1.0)]
        public double? FiberPerGram { get; set; }

        [Range(0.0, 1.0)]
        public double? SodiumPerGram { get; set; }

        [Range(0.0, 1.0)]
        public double? IronPerGram { get; set; }

        [Range(0.0, 1.0)]
        public double? CholestrolPerGram { get; set; }

        public virtual ICollection<Category> Categories
        {
            get
            {
                return this.categories;
            }

            set
            {
                this.categories = value;
            }
        }
    }
}
