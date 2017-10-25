using DSA.Algorithms.Graphs;
using DSA.Algorithms.Searching;
using DSA.Algorithms.Sorting;
using DSA.DataStructures.PriorityQueue;
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
            //TestMergeSortAndBinarySearch();

            //TestGraphTraversal();

            TestPQ();
        }

        private static void TestPQ()
        {
            var arr = new int[10];
            var rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-100,100);
            }
            Console.WriteLine(string.Join(", " , arr));

            var pq = new PriorityQueue<int>((a, b) => a < b);

            foreach (var item in arr)
            {
                pq.Enqueue(item);
                Console.Write(" {0} ", pq.Top);
            }
            Console.WriteLine();
            foreach (var item in arr)
            {
                Console.Write(" {0} ", pq.Dequeue());
            }


        }

        private static void TestGraphTraversal()
        {
            var graph = new List<int>[] {
                new List<int> {3, 6},
                new List<int> {2, 3, 4, 5, 6},
                new List<int> {1, 4, 5},
                new List<int> {0, 1, 5},
                new List<int> {1, 2, 6},
                new List<int> {1, 2, 3},
                new List<int> {0, 1, 4}
};
            var used = new HashSet<int>();
            graph.Bfs(0);
            Console.WriteLine();
            graph.DfsRecursive(0, used);
            Console.WriteLine();
            used.Clear();
            graph.DfsWithStack(0, used);
            Console.WriteLine();
        }

        private static void TestMergeSortAndBinarySearch()
        {
            int[] arr = new int[] { int.MinValue, int.MaxValue, 0, -1, 1, 5, 5, 5, 5, 5, 5 };

            arr.MergeSort();
            Console.WriteLine(string.Join(", ", arr));

            Console.WriteLine(arr.Length);
            Console.WriteLine(arr.MyBinarySearch(int.MaxValue));

            Console.WriteLine(arr.MyLowerBound(5));
            Console.WriteLine(arr.MyUpperBound(5));
        }
    }
}
