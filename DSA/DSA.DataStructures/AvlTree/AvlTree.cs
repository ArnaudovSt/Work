using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DataStructures.AvlTree
{
    public class AvlTree<T>
        where T : IComparable<T>
    {
        private AvlNode<T> root;

        public int Count => AvlNode<T>.GetSize(root);
        public int Height => AvlNode<T>.GetHeight(root);

        public AvlTree()
        {
        }

        public bool Contains(T value)
        {
            return AvlNode<T>.Contains(this.root, value);
        }

        public bool Add(T value)
        {
            return AvlNode<T>.Add(ref this.root, value);
        }

        public void GetOrdered()
        {
            InOrderTraverse(root);
        }

        private void InOrderTraverse(AvlNode<T> node)
        {
            if (node != null)
            {
                InOrderTraverse(node.Left);
                Console.Write("{0}, ", node.Value);
                InOrderTraverse(node.Right);
            }
        }
    }
}
