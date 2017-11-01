using System.Linq;
using FoodApp.Data.Models.Contracts;

namespace FoodApp.Data.ContextWrapper
{
    public interface IContextWrapper<T> 
        where T : class, IDeletable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}