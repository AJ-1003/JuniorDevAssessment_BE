using Shouldly;

using LinkedList_CL;

namespace LinkedList_Test
{
    public class Tests
    {
        private CustomLinkedList _linkedList;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _linkedList = new CustomLinkedList();
        }

        [Test]
        [TestCase(10, "Node")]
        public void Add_Node_Into_List(int position, object o)
        {
            // Act
            _linkedList.Add(position, o);

            // Assert
            _linkedList.ShouldNotBe(null);
            _linkedList.Length.ShouldBe(1);
        }

        [Test]
        [TestCase(1)]
        public void Delete_Node_From_List(int position)
        {
            // Act
            _linkedList.Add(1, "Node 1");
            _linkedList.Remove(position);

            // Assert
            _linkedList.Length.ShouldBe(0);
        }

        [Test]
        public void Print_Node_List()
        {
            // Act
            _linkedList.Add(0, "Node 1");
            _linkedList.Add(1, 500);
            _linkedList.Add(2, "Node 3");
            _linkedList.Add(3, "Node 4");
            _linkedList.Add(4, "Node 5");
            _linkedList.Add(5, 250);
            _linkedList.Add(6, "Node 7");
            _linkedList.Add(7, "Node 8");
            _linkedList.Add(8, "Node 9");
            _linkedList.PrintList();

            // Assert
            _linkedList.Length.ShouldBe(9);
        }
    }
}