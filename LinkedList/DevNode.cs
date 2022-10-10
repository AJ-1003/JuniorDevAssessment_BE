using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_CL
{
    public class DevNode<T>
    {
        public T element;
        public DevNode<T> next;

        public DevNode(T e, DevNode<T> n)
        {
            element = e;
            next = n;
        }
    }
}
