using TestingLib.Math;

namespace UnitTesting.twice
{
    public class GCDTest
    {
        private readonly BasicCalc _calculator;

        public GCDTest()
        {
            _calculator = new BasicCalc();
        }
        [Fact]
        public void Add_ShouldReturnCorrectGCD()
        {
            long result = _calculator.GCD(4, 8);
            Assert.Equal(4, result);
        }
        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(0, 0, 0)]
        [InlineData(-1, -1, -2)]
        public void Add_Theory(int a, int b, int expectedResult)
        {
            int result = _calculator.Add(a, b);
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void Divide_ShouldThrowDivideByZeroException()
        {
            Assert.Throws< System.ArgumentOutOfRangeException> (() => _calculator.GCD(-5, 0));
        }
    }
}
