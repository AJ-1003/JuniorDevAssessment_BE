using Shouldly;

using LinkedList_CL;

namespace LinkedList_Test
{
    public class Tests
    {
        private SinglyLinkedList<string> _linkedList;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _linkedList = new SinglyLinkedList<string>();
        }

        [Test]
        [TestCase("Node")]
        public void Add_As_First_Node_Into_List(string element)
        {
            // Act
            _linkedList.addFirst(element);

            // Assert
            _linkedList.length().ShouldBe(1);
        }

        [Test]
        [TestCase("Node", 5)]
        public void Add_Node_Into_List_At_Position(string element, int position)
        {
            // Act
            _linkedList.addAny(element, position);

            // Assert
            _linkedList.length().ShouldBe(0);
        }

        [Test]
        [TestCase("Node")]
        public void Add_As_Last_Node_Into_List(string element)
        {
            // Act
            _linkedList.addLast(element);

            // Assert
            _linkedList.length().ShouldBe(1);
        }

        [Test]
        public void Delete_First_Node_From_List()
        {
            // Act
            _linkedList.addFirst("Node");
            _linkedList.removeFirst();

            // Assert
            _linkedList.length().ShouldBe(0);
        }

        [Test]
        [TestCase(1)]
        public void Delete_Node_From_List_At_Position(int position)
        {
            // Act
            _linkedList.addFirst("Node 1");
            _linkedList.addLast("Node 2");
            _linkedList.addLast("Node 3");
            _linkedList.addLast("Node 4");
            _linkedList.addLast("Node 5");

            _linkedList.removeAny(position);

            // Assert
            _linkedList.length().ShouldBe(4);
        }

        [Test]
        public void Delete_Last_Node_From_List()
        {
            _linkedList.addFirst("Node 1");
            _linkedList.addLast("Node 2");
            _linkedList.addLast("Node 3");
            _linkedList.addLast("Node 4");
            _linkedList.addLast("Node 5");

            _linkedList.removeLast();
            _linkedList.removeLast();

            // Assert
            _linkedList.length().ShouldBe(3);
        }

        [Test]
        public void Print_Node_List()
        {
            // Act
            _linkedList.addFirst("Node 1");
            _linkedList.addLast("Node 2");
            _linkedList.addLast("Node 3");
            _linkedList.addLast("Node 4");
            _linkedList.addLast("Node 5");
            _linkedList.display();

            // Assert
            _linkedList.length().ShouldBe(5);
        }
    }
}