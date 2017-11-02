using Bytes2you.Validation;
using FoodApp.Data;
using FoodApp.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodApp.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IFoodService foodService;

        public ValuesController(IFoodService foodService)
        {
            Guard.WhenArgument(foodService, "Food controller food service").IsNull().Throw();
            this.foodService = foodService;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return this.foodService.Test().Select(f => f.Description).ToArray();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
