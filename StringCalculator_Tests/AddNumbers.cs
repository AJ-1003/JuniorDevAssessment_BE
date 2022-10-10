using Shouldly;

using StringCalculator_CL;

namespace StringCalculator_Tests
{
    public class Tests
    {
        private StringCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _calculator = new StringCalculator();
        }

        [Test]
        [TestCase("")]
        public void Add_Numbers_Should_Return_Zero(string numbers)
        {
            // Act
            var sum = _calculator.Add(numbers);

            // Assert
            sum.ShouldBe(0);
        }

        [Test]
        [TestCase("1")]
        public void Add_Numbers_Should_Return_One(string numbers)
        {
            // Act
            var sum = _calculator.Add(numbers);

            // Assert
            sum.ShouldBe(1);
        }

        [Test]
        [TestCase("1, 2")]
        public void Add_Numbers_Should_Return_Three(string numbers)
        {
            // Act
            var sum = _calculator.Add(numbers);

            // Assert
            sum.ShouldBe(3);
        }

        [Test]
        [TestCase("1\n2,3")]
        public void Add_Numbers_Should_Return_Six(string numbers)
        {
            // Act
            var sum = _calculator.Add(numbers);

            // Assert
            sum.ShouldBe(6);
        }

        [Test]
        [TestCase("//;\n2;3")]
        public void Add_Numbers_Should_Return_Five(string numbers)
        {
            // Act
            var sum = _calculator.Add(numbers);

            // Assert
            sum.ShouldBe(5);
        }

        [Test]
        [TestCase("-5")]
        public void Add_Numbers_Should_Throw_No_Negatives_Exception(string numbers)
        {
            // Act & Assert
            var sum = Should.Throw<NonNegativeException>(() => _calculator.Add(numbers));
        }

        [Test]
        [TestCase("1001, 2")]
        public void Add_Numbers_Should_Return_Two(string numbers)
        {
            // Act
            var sum = _calculator.Add(numbers);

            // Assert
            sum.ShouldBe(2);
        }

        [Test]
        [TestCase("//[***]\n3***3")]
        [TestCase("//[***]\n2***2*2")]
        public void Add_Numbers_Should_Return_Six_With_Mulitple_Character_Delimiter(string numbers)
        {
            // Act
            var sum = _calculator.Add(numbers);

            // Assert
            sum.ShouldBe(6);
        }

        [Test]
        [TestCase("//[*][%]\n1*2%3")]
        public void Add_Numbers_Should_Return_Six_With_Mulitple_Delimiters(string numbers)
        {
            // Act
            var sum = _calculator.Add(numbers);

            // Assert
            sum.ShouldBe(6);
        }

        [Test]
        [TestCase("//[***][%%][@]\n1***2%%3@4")]
        [TestCase("//[***][%%][@@]\n1*2%3@4")]
        [TestCase("//[**][%][@@@]\n1*2@@@3,4")]
        [TestCase("//[***][%%][@@]\n1*2%3\n4")]
        [TestCase("//[***][!][%][%%][@@]\n1*2%3\n4")]
        public void Add_Numbers_Should_Return_Ten_With_Mulitple_Delimiters_With_Multiple_Characters(string numbers)
        {
            // Act
            var sum = _calculator.Add(numbers);

            // Assert
            sum.ShouldBe(10);
        }
    }
}