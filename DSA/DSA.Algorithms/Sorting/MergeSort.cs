using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Algorithms.Sorting
{
    public static class MergeSortClass
    {
        public static void MergeSort<T>(this T[] array)
            where T : IComparable<T>
        {
            if (array.Length <= 1)
            {
                return;
            }

            array.MergeSort(0, array.Length);
        }

        private static void MergeSort<T>(this T[] array, int left, int right)
            where T : IComparable<T>
        {
            if (right - left <= 1)
            {
                return;
            }

            int middle = (left + right) / 2;

            array.MergeSort(left, middle);
            array.MergeSort(middle, right);

            array.Merge(left, middle, right);
        }

        private static void Merge<T>(this T[] array, int left, int middle, int right)
            where T : IComparable<T>
        {
            int i = left;
            int j = middle;
            int k = 0;

            var mergeArray = new T[right - left];

            while (k < mergeArray.Length)
            {
                if (i < middle && j < right)
                {
                    if (array[i].CompareTo(array[j]) <= 0)
                    {
                        mergeArray[k] = array[i];
                        ++i;
                    }
                    else
                    {
                        mergeArray[k] = array[j];
                        ++j;
                    }
                }
                else if (i < middle)
                {
                    mergeArray[k] = array[i];
                    ++i;
                }
                else if (j < right)
                {
                    mergeArray[k] = array[j];
                    ++j;
                }

                ++k;
            }

            for (int t = 0; t < mergeArray.Length; ++t)
            {
                array[left + t] = mergeArray[t];
            }
        }
    }
}
