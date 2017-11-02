using Bytes2you.Validation;
using FoodApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodApp.Web.Infrastructure
{
    public class SaveChangesFilter : IActionFilter
    {
        private readonly IUnitOfWork unitOfWork;

        public SaveChangesFilter(IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(unitOfWork, "Save changes filter unit of work").IsNull().Throw();

            this.unitOfWork = unitOfWork;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this.unitOfWork.Commit();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Need to implement the interface to bind it in Ninject.
        }
    }
}