namespace TDDPractice.UnitTests
{
    internal class FibonacciNumberAtNTests
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(4, 3)]
        [TestCase(50, 12586269025)]
        public void GetFibonacciNumberAtN_Returns_CorrectNumber(int position, long result)
        {
            var number = GetFibonacciNumberAtN(position);

            Assert.That(number, Is.EqualTo(result));
        }

        [TestCase(-1)]
        [TestCase(-400)]
        public void GetFibonacciNumberAtN_ThrowsException_WhenPositionIsNegative(int position)
        {
            Assert.Throws<ArgumentException>(() => GetFibonacciNumberAtN(position));
        }
        
        private static int GetFibonacciNumberAtNRecursion(int position)
        {
            if (position == 0 || position == 1)
                return position;

            var previousNumber = GetFibonacciNumberAtNRecursion(position-1);
            var secondPreviousNumber = GetFibonacciNumberAtNRecursion(position-2);

            return previousNumber + secondPreviousNumber;
        }

        private static long GetFibonacciNumberAtN(int position)
        {
            if (position < 0)
                throw new ArgumentException("Position cannot be negative");

            if (position == 0 || position == 1) return position;

            var firstNumber = 0L;
            var secondNumber = 1L;
            var previousNumber = secondNumber;
            var secondPreviousNumber = firstNumber;
            var number = 0L;

            for(int i = 2; i <= position; i++)
            {
                number = secondPreviousNumber + previousNumber;
                
                secondPreviousNumber = previousNumber;
                previousNumber = number;
            }

            return number;
        }

    }
}
