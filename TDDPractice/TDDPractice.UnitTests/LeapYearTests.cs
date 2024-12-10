namespace TDDPractice.UnitTests
{
    public class LeapYearTests
    {
        [TestCase(4)]
        [TestCase(2008)]
        [TestCase(2012)]
        public void IsLeapYear_ReturnsTrue_WhenYearIsDivisibleBy4(int year)
        {
            var result = IsLeapYear(year);

            Assert.That(result, Is.True);
        }

        [TestCase(4000)]
        [TestCase(8000)]
        [TestCase(1600)]
        public void IsLeapYear_ReturnsTrue_WhenYearIsDivisibleBy400(int year)
        {
            var result = IsLeapYear(year);

            Assert.That(result, Is.True);
        }

        [TestCase(1)]
        [TestCase(2023)]
        public void IsLeapYear_ReturnsFalse_WhenYearIsNotDivisibleBy4(int year)
        {
            var result = IsLeapYear(year);

            Assert.That(result, Is.False);
        }

        [TestCase(1900)]
        [TestCase(1700)]
        public void IsLeapYear_ReturnsFalse_WhenYearIsDivisibleBy100ButNot400(int year)
        {
            var result = IsLeapYear(year);

            Assert.That(result, Is.False);
        }

        public void IsLeapYear_ReturnsFalse_WhenYearIsZero()
        {
            var result = IsLeapYear(0);

            Assert.That(result, Is.False);
        }

        [TestCase(-1)]
        [TestCase(-400)]
        public void IsLeapYear_ThrowsException_WhenYearIsNegative(int year)
        {
            Assert.Throws<ArgumentException>(() => IsLeapYear(year));
        }

        private static bool IsLeapYear(int year)
        {
            if (year < 0)
                throw new ArgumentException("Year should not be negative");

            if (year % 400 == 0)
                return true;

            if (year % 4 == 0 && year % 100 != 0)
                return true;

            return false;
        }
    }
}