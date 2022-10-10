using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_CL
{
    public class SinglyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int size;

        public SinglyLinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public int length()
        {
            return size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void addFirst(T element)
        {
            var newest = new Node<T>(element, null);

            if (isEmpty())
            {
                head = newest;
                tail = newest;
            }
            else
            {
                newest.next = head;
                head = newest;
            }

            size++;
        }

        public void addAny(T element, int position)
        {
            if (position <= 0 || position >= size)
            {
                Debug.WriteLine("Invalid position...");
                return;
            }

            var newest = new Node<T>(element, null);
            var p = head;
            var i = 1;

            while (i < position - 1)
            {
                p = p.next;
                i++;
            }

            newest.next = p.next;
            p.next = newest;

            size++;
        }

        public void addLast(T element)
        {
            var newest = new Node<T>(element, null);

            if (isEmpty())
            {
                head = newest;
            }
            else
            {
                tail.next = newest;
            }

            tail = newest;
            size++;
        }

        public T? removeFirst()
        {
            if (isEmpty())
            {
                Debug.WriteLine("List is empty...");
                return default(T);
            }

            var element = head.element;
            head = head.next;
            size--;

            if (isEmpty())
            {
                tail = null;
            }

            return element;
        }

        public T? removeAny(int position)
        {
            if (position <= 0 || position >= size - 1)
            {
                Debug.WriteLine("Invalid position...");
                return default(T);
            }

            var p = head;
            var i = 1;

            while (i < position - 1)
            {
                p = p.next;
                i++;
            }

            var element = p.next.element;
            p.next = p.next.next;
            size--;
            return element;
        }

        public T? removeLast()
        {
            if (isEmpty())
            {
                Debug.WriteLine("List is empty...");
                return default(T);
            }

            var p = head;
            var i = 1;

            while (i < length() - 1)
            {
                p = p.next;
                i++;
            }

            tail = p;
            p = p.next;

            var element = p.element;

            tail.next = null;
            size--;

            return element;
        }

        public void display()
        {
            var p = head;

            while (p != null)
            {
                if (p.next == null)
                {
                    Debug.WriteLine($"{p.element}");
                }

                Debug.WriteLine($"{p.element} --> ");
                p = p.next;
            }

            Console.WriteLine();
        }
    }
}
