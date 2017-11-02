using FoodApp.Data.Models.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Data.Models
{
    //[DataContract(IsReference = true)]
    public class Category : DataModel
    {
        private ICollection<Food> foods;

        public Category()
        {
            this.foods = new HashSet<Food>();
        }

        [Required]
        [Index(IsUnique = true, IsClustered = false)]
        [StringLength(128, MinimumLength = 1)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(2048, MinimumLength = 128)]
        public string Description { get; set; }

        //[IgnoreDataMember]
        //[JsonIgnore]
        public virtual ICollection<Food> Foods
        {
            get
            {
                return this.foods;
            }

            set
            {
                this.foods = value;
            }
        }
    }
}
