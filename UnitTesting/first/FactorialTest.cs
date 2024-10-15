using TestingLib.Math;


namespace UnitTesting.first
{

    public class FactorialTest
    {
        private readonly BasicCalc _calculator;
        public FactorialTest()
        {
            _calculator = new BasicCalc();
        }

        [Fact]
        public void Add_ShouldReturnCorrectFactorial()
        {
            long result = _calculator.Factorial(5);
            Assert.Equal(120, result);
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
            Assert.Throws<ArgumentException>(() => _calculator.Factorial(-1));
        }
    }
}