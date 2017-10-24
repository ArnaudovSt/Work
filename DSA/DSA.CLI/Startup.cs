using DSA.Algorithms.Searching;
using DSA.Algorithms.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.CLI
{
    public class Startup
    {
        public static void Main()
        {
            int[] arr = new int[] { int.MinValue, int.MaxValue, 0, -1, 1, 5, 5, 5, 5, 5, 5 };

            arr.MergeSort();
            Console.WriteLine(string.Join(", " , arr));

            Console.WriteLine(arr.Length);
            Console.WriteLine(arr.MyBinarySearch(int.MaxValue));

            Console.WriteLine(arr.MyLowerBound(5));
            Console.WriteLine(arr.MyUpperBound(5));

        }
    }
}
