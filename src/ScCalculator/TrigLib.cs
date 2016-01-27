using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScCalculator
{
    public enum AngleType
    {
        DEGREES,
        RADIANS
    }

    class TrigLib
    {
        public TrigLib(AngleType angleType)
        {
            selectedAngleType = angleType;
        }

        public void SetTrigMode(AngleType newAngleType)
        {
            selectedAngleType = newAngleType;
        }

        public double CalculateSin(double input)
        {
            input = getCorrectedInput(input);

            double sinVal = Math.Sin(input);
            return sinVal;
        }

        public double CalculateCos(double input)
        {
            input = getCorrectedInput(input);

            double cosVal = Math.Cos(input);
            return cosVal;
        }

        public double CalculateTan(double input)
        {
            input = getCorrectedInput(input);

            double tanValue = Math.Tan(input);
            return tanValue;
        }

        public double CalculateArcSin(double input)
        {
            double arcsinValue = Math.Asin(input);
            arcsinValue = getCorrectedArcOutput(arcsinValue);

            return arcsinValue;
        }

        public double CalculateArCos(double input)
        {
            double arccosValue = Math.Acos(input);
            arccosValue = getCorrectedArcOutput(arccosValue);

            return arccosValue;
        }

        public double CalculateArcTan(double input)
        {
            double arctanValue = Math.Atan(input);
            arctanValue = getCorrectedArcOutput(arctanValue);

            return arctanValue;
        }
  
        private double getCorrectedArcOutput(double output)
        {
            if (selectedAngleType == AngleType.DEGREES)
            {
                output = output * (180 / Math.PI);
            }

            return output;
        }

        private double getCorrectedInput(double input)
        {
            if (selectedAngleType == AngleType.DEGREES)
            {
                input = input * Math.PI / 180;
            }

            return input;
        }

        private AngleType selectedAngleType;
    }
}
