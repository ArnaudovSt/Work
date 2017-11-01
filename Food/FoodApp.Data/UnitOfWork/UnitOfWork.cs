using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoodDbContext dbContext;

        public UnitOfWork(FoodDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "Unit of work dbContext").IsNull().Throw();

            this.dbContext = dbContext;
        }

        public void Commit()
        {
            if (!this.dbContext.ChangeTracker.HasChanges())
            {
                return;
            }

            this.dbContext.SaveChanges();
        }
    }
}
