using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Algorithms.Searching
{
    public static class BinarySearchClass
    {
        public static int MyBinarySearch<T>(this T[] array, T element)
            where T : IComparable<T>
        {
            int left = 0;
            int right = array.Length;

            while (left < right)
            {
                int middle = (left + right) / 2;

                if (array[middle].CompareTo(element) == 0)
                {
                    return middle;
                }

                if (array[middle].CompareTo(element) < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return -1;
        }

        public static int MyLowerBound<T>(this T[] array, T value)
            where T : IComparable<T>
        {
            return array.Bound(mid => mid.CompareTo(value) < 0);
        }

        public static int MyUpperBound<T>(this T[] array, T value)
            where T : IComparable<T>
        {
            return array.Bound(mid => mid.CompareTo(value) <= 0);
        }

        private static int Bound<T>(this T[] array, Func<T, bool> compareFunc)
        {
            int left = 0;
            int right = array.Length;

            while (left < right)
            {
                int middle = (left + right) / 2;

                if (compareFunc(array[middle]))
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return left;
        }

    }
}
