using Algorithms.DoublyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.AVLSearchTree
{
    public interface IAvlSearchTree
    {
        // TODO: Add Node
        public object Find(int value);

        // TODO: Add Node
        public object FindMinimum();

        // TODO: Add Node
        public object FindMaximum();

        public void Insert(int value);

        public void Remove(int value);
    }
}
