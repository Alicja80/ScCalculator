using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScCalculator
{
    class CalMathLib
    {       
        public double CalculateSqrt(double number)
        { 
            double value = Math.Sqrt(number);  
            return value;
        }

        public int CalculateFactorial(int number)
        {
            int result = 1;

            for (int i = number; i > 0; i--)
            {
                result = result * i;
            }

            return result;
        }
    }
}
