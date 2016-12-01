using Xunit;

namespace Lib.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Divide_ByZero()
        {
            //arrange
            var x = 1;
            var y = 0;
            var calc = new Calc();

            //act
            var result = calc.Divide(x, y);

            //assert
            Assert.Equal(result, 0);
        }

        [Fact]
        public void Divide_Normally()
        {
            //arrange
            //act
            //assert
        }
    }
}