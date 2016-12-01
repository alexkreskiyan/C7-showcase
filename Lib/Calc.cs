using System;

namespace Lib
{
    public class Calc
    {
        public double Divide(int x, int y)
        {
            if (y == 0)
                throw new DivideByZeroException();

            var result = x / y;

            return result;
        }
    }
}
