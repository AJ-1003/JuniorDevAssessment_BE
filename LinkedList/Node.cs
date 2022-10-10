using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_CL
{
    public class Node<T>
    {
        public T element;
        public Node<T> next;

        public Node(T e, Node<T> n)
        {
            element = e;
            next = n;
        }
    }
}
