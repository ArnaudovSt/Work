using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services.Common.TimeProvider
{
    public abstract class TimeProvider
    {
        private static TimeProvider current;

        static TimeProvider()
        {
            TimeProvider.current =
                new DefaultTimeProvider();
        }

        public static TimeProvider Current
        {
            get
            {
                return TimeProvider.current;
            }

            set
            {
                Guard.WhenArgument(value, "Current").IsNull().Throw();

                TimeProvider.current = value;
            }
        }
        public abstract DateTime Now { get; }

        public abstract DateTime Today { get; }

        public static void ResetToDefault()
        {
            TimeProvider.current =
                new DefaultTimeProvider();
        }
    }
}
