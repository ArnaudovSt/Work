using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DataStructures.GraphRelated
{
    public class Node
    {
        public Node(int id)
        {
            this.Id = id;
            this.DijkstraDistance = double.PositiveInfinity;
        }

        public int Id { get; private set; }

        public double DijkstraDistance { get; set; }
    }
}
