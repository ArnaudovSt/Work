using DSA.DataStructures.GraphRelated;
using DSA.DataStructures.PriorityQueue;
using DSA.DataStructures.WeightedNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//set all nodes DIST = INFINITY;
//set current node the source and distance = 0;
//Q -> all nodes from graph, ordered by distance;
//while (Q is not empty)
//    a = dequeue the smallest element(first in PriorityQueue);
//    if (distance of a == INFINITY) break

//    foreach neighbour v of a
//        potDistance = distance of a + distance of(a-v)
//        if (potDistance<distance of v)
//            distance of v = potDistance;
//            reorder Q;

namespace DSA.Algorithms.Graphs
{
    public static class Dijkstra
    {
        public static double DijkstraShortestPath(this List<Edge>[] graph, Node source, Node destination)
        {
            var pq = new PriorityQueue<Node>((a,b) => a.DijkstraDistance.CompareTo(b.DijkstraDistance) < 0);

            source.DijkstraDistance = 0;

            pq.Enqueue(source);

            while (!pq.IsEmpty)
            {
                var current = pq.Dequeue();

                if (double.IsPositiveInfinity(current.DijkstraDistance))
                {
                    break;
                }

                foreach (var neighbour in graph[current.Id])
                {
                    var potentialDistance = current.DijkstraDistance + neighbour.Distance;
                    if (potentialDistance < neighbour.Node.DijkstraDistance)
                    {
                        neighbour.Node.DijkstraDistance = potentialDistance;
                        pq.Enqueue(neighbour.Node);
                    }
                }
            }

            return destination.DijkstraDistance;
        }
    }
}
