using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScCalculator
{
    class PowersLib
    {
        public double Pow2(double d1)
        {
            double value = d1 * d1;
            return value;
        }

        public double Pow3(double d1)
        {
            double value = Math.Pow(d1, 3);
            return value;
        }

        public double Log(double number)
        {
            double value = Math.Log(number);
            return value;
        }

        public double Ln(double number)
        {
            double value = Math.Log10(number);
            return value;
        }
    }
}
