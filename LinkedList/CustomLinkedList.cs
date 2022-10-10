using System.Diagnostics;

namespace LinkedList_CL
{
    public class CustomLinkedList<T>
    {
        internal CustomLinkedListNode<T>? head;
        internal int length;

        public bool Empty
        {
            get { return length == 0; }
        }

        public int Length
        {
            get { return length; }
        }

        public CustomLinkedList()
        {
            head = null;
            length = 0;
        }

        public T Add(int position, T o)
        {
            if (position < 0)
            {
                throw new ArgumentOutOfRangeException($"Position: {position}");
            }

            if (position > length)
            {
                position = length;
            }

            CustomLinkedListNode<T> current = head;

            if (Empty || position == 0)
            {
                head = new CustomLinkedListNode<T>(o, head);
            }
            else
            {
                for (var i = 0; i < position - 1; i++)
                {
                    current = current.Next;
                }

                current.Next = new CustomLinkedListNode<T>(o, current.Next);
            }

            length++;
            return o;
        }

        public T? Remove(int position)
        {
            if (position < 0)
            {
                throw new ArgumentOutOfRangeException($"Position: {position}");
            }

            if (Empty)
            {
                return null;
            }

            if (position >= length)
            {
                position -= length;
            }

            CustomLinkedListNode<T> current = head;
            object result;

            if (position == 0)
            {
                result = current.Node;
                head = current.Next;
            }
            else
            {
                for (var i = 0; i < position - 1; i++)
                {
                    current = current.Next;
                }

                result = current.Next.Node;
                current.Node = current.Next.Next;
            }

            length--;
            return result;
        }

        public void PrintList()
        {
            CustomLinkedListNode<T> node = head;
            var position = 0;

            Debug.WriteLine("=======================");
            Debug.WriteLine("Position\tValue");

            Console.WriteLine("=======================");
            Console.WriteLine("Position\tValue");
            while (node != null)
            {
                Debug.WriteLine($"{position}\t\t\t{node.Node}");

                Console.WriteLine($"{position}\t\t\t{node.Node}");
                node = node.Next;
                position++;
            }
            Debug.WriteLine("=======================");

            Console.WriteLine("=======================");
        }
    }

    public sealed class CustomLinkedListNode<T>
    {
        private T _node;
        private CustomLinkedListNode<T> _next;

        public T Node
        {
            get { return _node; }
            set { _node = value; }
        }

        public CustomLinkedListNode<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public CustomLinkedListNode(T node, CustomLinkedListNode<T> next)
        {
            _node = node;
            _next = next;
        }
    }
}