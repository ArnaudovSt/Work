using System;

namespace FoodApp.Services.Common.TimeProvider
{
    public class DefaultTimeProvider : TimeProvider
    {
        public override DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        public override DateTime Today
        {
            get
            {
                return DateTime.Today;
            }
        }
    }
}