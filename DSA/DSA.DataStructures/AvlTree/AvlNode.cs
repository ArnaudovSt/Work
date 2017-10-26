using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DataStructures.AvlTree
{
    internal class AvlNode<T>
        where T : IComparable<T>
    {
        private int size;
        private int height;

        public AvlNode(T value)
        {
            this.size = 1;
            this.height = 1;
            this.Value = value;
            this.Children = new AvlNode<T>[2];
        }

        public T Value { get; private set; }

        public AvlNode<T>[] Children { get; private set; }

        public AvlNode<T> Left
        {
            get
            {
                return Children[0];
            }
            set
            {
                Children[0] = value;
            }
        }

        public AvlNode<T> Right
        {
            get
            {
                return Children[1];
            }
            set
            {
                Children[1] = value;
            }
        }

        private int Balance => GetHeight(this.Left) - GetHeight(this.Right);



        public static int GetSize(AvlNode<T> node)
        {
            return node == null ? 0 : node.size;
        }

        public static int GetHeight(AvlNode<T> node)
        {
            return node == null ? 0 : node.height;
        }

        public static void RotateRight(ref AvlNode<T> node)
        {
            Rotate(ref node, 0, 1);
        }

        public static void RotateLeft(ref AvlNode<T> node)
        {
            Rotate(ref node, 1, 0);
        }

        public static bool Contains(AvlNode<T> node, T value)
        {
            if (node == null)
            {
                return false;
            }

            var compareResult = value.CompareTo(node.Value);
            if (compareResult < 0)
            {
                return Contains(node.Left, value);
            }
            else if (compareResult > 0)
            {
                return Contains(node.Right, value);
            }

            return true;
        }

        public static bool Add(ref AvlNode<T> node, T value)
        {
            if (node == null)
            {
                node = new AvlNode<T>(value);
                return true;
            }

            var compareResult = value.CompareTo(node.Value);
            if (compareResult < 0)
            {
                var child = node.Left;
                var result = Add(ref child, value);
                if (result)
                {
                    node.Left = child;
                    BalanceIfLeftIsHeavy(ref node);
                }
                return result;
            }
            else if (compareResult > 0)
            {
                var child = node.Right;
                var result = Add(ref child, value);
                if (result)
                {
                    node.Right = child;
                    BalanceIfRightIsHeavy(ref node);
                }
                return result;
            }

            return false;
        }

        private static void BalanceIfLeftIsHeavy(ref AvlNode<T> node)
        {
            node.UpdateSizes();

            if (node.Balance > 1)
            {
                if (node.Left.Balance < 0)
                {
                    var child = node.Left;
                    RotateLeft(ref child);
                    node.Left = child;
                }
                RotateRight(ref node);
            }
        }
        private static void BalanceIfRightIsHeavy(ref AvlNode<T> node)
        {
            node.UpdateSizes();

            if (node.Balance < -1)
            {
                if (node.Right.Balance > 0)
                {
                    var child = node.Right;
                    RotateRight(ref child);
                    node.Right = child;
                }
                RotateLeft(ref node);
            }
        }

        private static void Rotate(ref AvlNode<T> oldRoot, int left, int right)
        {
            var newRoot = oldRoot.Children[left];
            oldRoot.Children[left] = newRoot.Children[right];
            newRoot.Children[right] = oldRoot;

            oldRoot.UpdateSizes();
            newRoot.UpdateSizes();

            oldRoot = newRoot;
        }

        private void UpdateSizes()
        {
            this.size = GetSize(this.Left) + GetSize(this.Right) + 1;
            this.height = Math.Max(GetHeight(this.Left), GetHeight(this.Right)) + 1;
        }
    }
}
