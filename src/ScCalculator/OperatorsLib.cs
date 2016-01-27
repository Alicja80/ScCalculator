using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScCalculator
{
    public class OperatorsLib
    {
        public double Add(double d1, double d2)
        {
            double Addvalue = d1 + d2;
            return Addvalue;
        }

        public double Min(double d1, double d2)
        {
            double value = d1 - d2;
            return value;
        }
        public double PlusMin(double d1, double d2)
        {
            double value = d1 + - d2;
            return value;
        }
        public double Multipl(double d1, double d2)
        {
            double value = d1 * d2;
            return value;
        }

        public double Div(double d1, double d2)
        {
            double value = d1 / d2;
            return value;
        }

        public double Mod(double d1, double d2)
        {
            return d1 * (1 / 100 * d2);
        }
    } 
}
