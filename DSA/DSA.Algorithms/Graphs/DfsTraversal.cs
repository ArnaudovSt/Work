using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Algorithms.Graphs
{
    public static class DfsTraversal
    {
        public static void DfsWithStack(this List<int>[] graph, int startingVertex, HashSet<int> used)
        {
            var stack = new Stack<int>();
            stack.Push(startingVertex);

            used.Add(startingVertex);

            while (stack.Count > 0)
            {
                int current = stack.Pop();
                Console.Write(current);

                foreach (var child in graph[current])
                {
                    if (!used.Contains(child))
                    {
                        stack.Push(child);
                        used.Add(child);
                    }
                }
            }
        }


        public static void DfsRecursive(this List<int>[] graph, int vertex, HashSet<int> used)
        {
            used.Add(vertex);

            Console.Write(vertex);

            foreach (var child in graph[vertex])
            {
                if (!used.Contains(child))
                {
                    graph.DfsRecursive(child, used);
                }
            }

        }
    }
}
