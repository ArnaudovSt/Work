using System.Linq;
using FoodApp.Data.Models;

namespace FoodApp.Services.Data
{
    public interface IFoodService
    {
        IQueryable<Food> Test();
    }
}