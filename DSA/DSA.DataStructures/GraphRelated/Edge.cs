using DSA.DataStructures.GraphRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DataStructures.WeightedNode
{
    public class Edge
    {
        public Edge(Node node, double distance)
        {
            this.Node = node;
            this.Distance = distance;
        }

        public Node Node { get; set; }

        public double Distance { get; set; }
    }
}
