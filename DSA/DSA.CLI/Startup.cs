using DSA.Algorithms.Graphs;
using DSA.Algorithms.Searching;
using DSA.Algorithms.Sorting;
using DSA.DataStructures.AvlTree;
using DSA.DataStructures.GraphRelated;
using DSA.DataStructures.PriorityQueue;
using DSA.DataStructures.WeightedNode;
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

            //TestPQ();

            //TestDijkstra();

            TestAvlTree();
        }

        private static void TestAvlTree()
        {
            var tree = new AvlTree<int>();
            var rnd = new Random();
            for (int i = 0; i < 128; i++)
            {
                var number = rnd.Next(-100, 100);
                tree.Add(number);
                Console.WriteLine("number: {0}, tree size: {1}, tree height: {2}", number, tree.Count, tree.Height);
            }

            tree.GetOrdered();
        }

        private static void TestDijkstra()
        {
            var node1 = new Node(0);
            var node2 = new Node(1);
            var node3 = new Node(2);
            var node4 = new Node(3);
            var node5 = new Node(4);

            var graph = new List<Edge>[] {
                new List<Edge> {
                new Edge(node2, 2),
                new Edge(node3, 3),
                new Edge(node4, 11)},

                new List<Edge> {
                new Edge(node1, 2),
                new Edge(node3, 3),
                new Edge(node5, 15)},

                new List<Edge> {
                new Edge(node1, 3),
                new Edge(node2, 3),
                new Edge(node4, 2),
                new Edge(node5, 6)},

                new List<Edge> {
                new Edge(node1, 11),
                new Edge(node3, 2),
                new Edge(node5, 3) },

                new List<Edge> {
                new Edge(node2, 15),
                new Edge(node3, 6),
                new Edge(node4, 3) }
};
            Console.WriteLine(graph.DijkstraShortestPath(node1, node5));
        }

        private static void TestPQ()
        {
            var arr = new int[10];
            var rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-100, 100);
            }
            Console.WriteLine(string.Join(", ", arr));

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
