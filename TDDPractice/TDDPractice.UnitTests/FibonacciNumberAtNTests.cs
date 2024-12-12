namespace TDDPractice.UnitTests
{
    internal class FibonacciNumberAtNTests
    {
        const int MaxPosition = 92; 

        [Test]
        public void GetFibonacciNumberAtZero_Returns_Zero()
        {
            long number = GetFibonacciNumberAtN(0);

            Assert.That(number, Is.EqualTo(0));
        }

        [Test]
        public void GetFibonacciNumberAtTwo_Returns_One()
        {
            long number = GetFibonacciNumberAtN(2);

            Assert.That(number, Is.EqualTo(1));
        }
        
        [TestCase(1, 1)]
        [TestCase(4, 3)]
        [TestCase(50, 12586269025)]
        [TestCase(92, 7540113804746346429)]
        public void GetFibonacciNumberAtN_Returns_CorrectNumber(int position, long result)
        {
            long number = GetFibonacciNumberAtN(position);

            Assert.That(number, Is.EqualTo(result));
        }

        [TestCase(-1)]
        [TestCase(-400)]
        public void GetFibonacciNumberAtN_ThrowsException_WhenPositionIsNegative(int position)
        {
            Assert.Throws<ArgumentException>(() => GetFibonacciNumberAtN(position));
        }

        [Test]
        public void GetFibonacciNumberAtN_ThrowsException_WhenPositionIsBeyondUpperLimit()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GetFibonacciNumberAtN(MaxPosition + 1));
        }

        private static long GetFibonacciNumberAtN(int position)
        {
            if (position is < 0)
                throw new ArgumentException("Position cannot be negative");

            if (position is > MaxPosition)
                throw new ArgumentOutOfRangeException("Position exceeds the supported limit");

            if (position is 0 or 1) return position;

            long firstNumber = 0L, secondNumber = 1L;
            long secondPreviousNumber = firstNumber, previousNumber = secondNumber;
            long number = 0L;

            for (int i = 2; i <= position; i++)
            {
                number = secondPreviousNumber + previousNumber;

                secondPreviousNumber = previousNumber;
                previousNumber = number;
            }

            return number;
        }

    }
}
