using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PudelkoLib
{
    public sealed class Pudelko : IFormattable
    {
        private readonly UnitOfMeasure unitSys;
        private readonly double a;
        private readonly double b;
        private readonly double c;
        public string A => string.Format("{0:0.000}m", a * getCurrentUnitSystem());
        public string B => string.Format("{0:0.000}m", b * getCurrentUnitSystem());
        public string C => string.Format("{0:0.000}m", c * getCurrentUnitSystem());

        public Pudelko(double a = 0.1, double b = 0.1, double c = 0.1, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            dataCheck(a, b, c, unit);
            this.a = a;
            this.b = b;
            this.c = c;
            unitSys = unit;
        }


        double getCurrentUnitSystem()
        {
            if (unitSys == UnitOfMeasure.meter)
                return 1;
            else if (unitSys == UnitOfMeasure.centimeter)
                return 0.1 * 0.1;
            else
                return 0.1 * 0.1 * 0.1;
        }
        void dataCheck(double a, double b, double c, UnitOfMeasure unit)
        {
            if (a < 0 || b < 0 || c < 0)
                throw new ArgumentOutOfRangeException();
            switch (unit)
            {
                case UnitOfMeasure.meter:
                    if (a > 10 || b > 10 || c > 10)
                        throw new ArgumentOutOfRangeException();
                    break;
                case UnitOfMeasure.centimeter:
                    if (a > 1000 || b > 1000 || c > 1000)
                        throw new ArgumentOutOfRangeException();
                    break;
                case UnitOfMeasure.milimeter:
                    if (a > 10000 || b > 10000 || c > 10000)
                        throw new ArgumentOutOfRangeException();
                    break;
            }

        }

        public override string ToString()
        {
            return this.ToString("m", new CultureInfo("en-US"));
        }

        public string ToString(string format)
        {
            return this.ToString(format, new CultureInfo("en-US"));
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "m";
            if (provider == null) provider = new CultureInfo("en-US");

            switch (format)
            {
                case "m":
                    return "";
                case "mm":
                    return "";
                case "cm":
                    return "";
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
    }
}
