using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DataStructures.PriorityQueue
{
    public class PriorityQueue<T>
    {
        private List<T> heap;
        private Func<T, T, bool> compareFunc;

        public PriorityQueue(Func<T, T, bool> compareFunc)
        {
            this.heap = new List<T>
            {
                default(T)
            };

            this.compareFunc = compareFunc;
        }

        public T Top => heap[1];

        public int Count => heap.Count - 1;

        public bool IsEmpty => this.Count == 0;

        public void Enqueue(T item)
        {
            var indexWhereInserted = heap.Count;

            heap.Add(item);

            while (indexWhereInserted > 1 && compareFunc(item, heap[indexWhereInserted / 2]))
            {
                heap[indexWhereInserted] = heap[indexWhereInserted / 2];
                indexWhereInserted /= 2;
            }

            heap[indexWhereInserted] = item;
        }

        public T Dequeue()
        {
            var toReturn = heap[1];

            var lastMemberValue = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            if (!IsEmpty)
            {
                int parentIndex = 1;

                while (parentIndex * 2 + 1 < heap.Count)
                {
                    int smallerKidIndex = compareFunc(heap[parentIndex * 2], heap[parentIndex * 2 + 1]) ?
                                            parentIndex * 2 :
                                            parentIndex * 2 + 1;
                    if (compareFunc(heap[smallerKidIndex], lastMemberValue))
                    {
                        heap[parentIndex] = heap[smallerKidIndex];
                        parentIndex = smallerKidIndex;
                    }
                    else
                    {
                        break;
                    }
                }

                if (parentIndex * 2 < heap.Count)
                {
                    int smallerKidIndex = parentIndex * 2;

                    if (compareFunc(heap[smallerKidIndex], lastMemberValue))
                    {
                        heap[parentIndex] = heap[smallerKidIndex];
                        parentIndex = smallerKidIndex;
                    }
                }

                heap[parentIndex] = lastMemberValue;
            }

            return toReturn;
        }
    }
}
