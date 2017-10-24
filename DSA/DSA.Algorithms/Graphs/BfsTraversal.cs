using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Algorithms.Graphs
{
    public static class BfsTraversal
    {
        public static void Bfs(this List<int>[] graph, int startingVertex)
        {
            var q = new Queue<int>();
            q.Enqueue(startingVertex);

            var used = new HashSet<int>();
            used.Add(startingVertex);

            while (q.Count > 0)
            {
                int current = q.Dequeue();

                Console.Write(current);

                foreach (var child in graph[current])
                {
                    if (!used.Contains(child))
                    {
                        q.Enqueue(child);
                        used.Add(child);
                    }
                }
            }
        }
    }
}
