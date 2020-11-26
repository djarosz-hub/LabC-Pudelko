using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace PudelkoLib
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>/*, IEnumerable*/
    {
        private readonly UnitOfMeasure unitSys;
        private readonly double a;
        private readonly double b;
        private readonly double c;
        public double this[int index]
        {
            get
            {
                if (index == 0)
                    return a;
                else if (index == 1)
                    return b;
                else if (index == 2)
                    return c;
                throw new IndexOutOfRangeException();
            }
        }
        public double A => Math.Round(a * ChangeSystemToMeters(), 3);
        public double B => Math.Round(b * ChangeSystemToMeters(), 3);
        public double C => Math.Round(c * ChangeSystemToMeters(), 3);

        public double Objetosc => Math.Round(A * B * C, 9);
        public double Pole => GetAreaOfBox(A, B, C);

        public Pudelko(double a = -999, double b = -999, double c = -999, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if (a == -999)
            {
                if (unit == UnitOfMeasure.meter)
                    a = 0.1;
                if (unit == UnitOfMeasure.centimeter)
                    a = 10;
                if (unit == UnitOfMeasure.milimeter)
                    a = 100;
            }
            if (b == -999)
            {
                if (unit == UnitOfMeasure.meter)
                    b = 0.1;
                if (unit == UnitOfMeasure.centimeter)
                    b = 10;
                if (unit == UnitOfMeasure.milimeter)
                    b = 100;
            }
            if (c == -999)
            {
                if (unit == UnitOfMeasure.meter)
                    c = 0.1;
                if (unit == UnitOfMeasure.centimeter)
                    c = 10;
                if (unit == UnitOfMeasure.milimeter)
                    c = 100;
            }
            if (UnitOfMeasure.milimeter == unit)
            {
                a = Math.Round(a, 0);
                b = Math.Round(b, 0);
                c = Math.Round(c, 0);
            }
            if (UnitOfMeasure.centimeter == unit)
            {
                a = Math.Truncate(10 * a) / 10;
                b = Math.Truncate(10 * b) / 10;
                c = Math.Truncate(10 * c) / 10;
            }
            if (UnitOfMeasure.meter == unit)
            {
                a = Math.Truncate(1000 * a) / 1000;
                b = Math.Truncate(1000 * b) / 1000;
                c = Math.Truncate(1000 * c) / 1000;
            }
            BoxMeasurmentValidation(a, b, c, unit);
            this.a = a;
            this.b = b;
            this.c = c;
            unitSys = unit;
        }

        public static explicit operator double[](Pudelko p) => new double[] { p.A, p.B, p.C };

        public static implicit operator Pudelko(ValueTuple<int, int, int> tuple) => new Pudelko(tuple.Item1, tuple.Item2, tuple.Item3, UnitOfMeasure.milimeter);

        double GetAreaOfBox(double a, double b, double c)
        {
            double total = 0;
            total += a * b * 2;
            total += b * c * 2;
            total += a * c * 2;
            return Math.Round(total, 6);
        }
        public static int CompareBox(Pudelko p1, Pudelko p2)
        {
            if (p1 is null && p2 is null) return 0;
            if (p1 is null && !(p2 is null)) return -1;
            if (!(p1 is null) && p2 is null) return +1;

            if (p1.Objetosc != p2.Objetosc)
                return (p1.Objetosc).CompareTo(p2.Objetosc);
            if (p1.Pole != p2.Pole)
                return (p1.Pole.CompareTo(p2.Pole));

            return (p1.A + p1.B + p1.C).CompareTo(p2.A + p2.B + p2.C);
        }
        double ChangeSystemToMeters()
        {
            if (unitSys == UnitOfMeasure.meter)
                return 1;
            else if (unitSys == UnitOfMeasure.centimeter)
                return 0.1 * 0.1;
            else
                return 0.1 * 0.1 * 0.1;
        }
        double ReturnCorrectUnitSystem(UnitOfMeasure current, string target)
        {
            switch (target)
            {
                case "m":
                    {
                        if (current == UnitOfMeasure.meter)
                            return 1;
                        else if (current == UnitOfMeasure.centimeter)
                            return 0.1 * 0.1;
                        else
                            return 0.1 * 0.1 * 0.1;
                    }
                case "cm":
                    {
                        if (current == UnitOfMeasure.meter)
                            return 100;
                        else if (current == UnitOfMeasure.centimeter)
                            return 1;
                        else
                            return 0.1;
                    }
                case "mm":
                    {
                        if (current == UnitOfMeasure.meter)
                            return 1000;
                        else if (current == UnitOfMeasure.centimeter)
                            return 10;
                        else
                            return 1;
                    }
            }
            throw new ArgumentException("unhandled unit system");
        }
        void BoxMeasurmentValidation(double a, double b, double c, UnitOfMeasure unit)
        {
            if (a <= 0 || b <= 0 || c <= 0)
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
        //toString override
        #region

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
            char X = '\u00D7';
            switch (format)
            {
                case "m":
                    return string.Format("{0:0.000} m {3} {1:0.000} m {3} {2:0.000} m", a * ReturnCorrectUnitSystem(unitSys, format), b * ReturnCorrectUnitSystem(unitSys, format), c * ReturnCorrectUnitSystem(unitSys, format), X);
                case "cm":
                    return string.Format("{0:0.0} cm {3} {1:0.0} cm {3} {2:0.0} cm", a * ReturnCorrectUnitSystem(unitSys, format), b * ReturnCorrectUnitSystem(unitSys, format), c * ReturnCorrectUnitSystem(unitSys, format), X);
                case "mm":
                    return string.Format("{0:0} mm {3} {1:0} mm {3} {2:0} mm", a * ReturnCorrectUnitSystem(unitSys, format), b * ReturnCorrectUnitSystem(unitSys, format), c * ReturnCorrectUnitSystem(unitSys, format), X);
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
        #endregion
        //IEquatable implementation
        #region
        public bool Equals(Pudelko other)
        {
            if (other is null) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            //return (A == other.A && B == other.B && C == other.C);
            //patterns to check: ABC ACB BCA BAC CBA CAB 
            if (A == other.A && B == other.B && C == other.C)
                return true;
            else if (A == other.A && B == other.C && C == other.B)
                return true;
            else if (A == other.B && B == other.C && C == other.A)
                return true;
            else if (A == other.C && B == other.B && C == other.A)
                return true;
            else if (A == other.B && B == other.A && C == other.C)
                return true;
            else if (A == other.C && B == other.A && C == other.B)
                return true;
            else
                return false;
        }
        public override bool Equals(object obj)
        {
            return obj is Pudelko ? Equals((Pudelko)obj) : false;
        }
        public static bool Equals(Pudelko p1, Pudelko p2)
        {
            if ((p1 is null) && (p2 is null)) return true;
            if ((p1 is null)) return false;
            return p1.Equals(p2);
        }
        public static Pudelko Parse(string parseInput)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            UnitOfMeasure unit;
            double a, b, c;
            string[] tab = parseInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (tab[1] == "m" && tab[4] == "m" && tab[7] == "m")
                unit = UnitOfMeasure.meter;
            else if (tab[1] == "cm" && tab[4] == "cm" && tab[7] == "cm")
                unit = UnitOfMeasure.centimeter;
            else if (tab[1] == "mm" && tab[4] == "mm" && tab[7] == "mm")
                unit = UnitOfMeasure.milimeter;
            else
                throw new FormatException("not supported format of input");
            if (double.TryParse(tab[0], out a) && double.TryParse(tab[3], out b) && double.TryParse(tab[6], out c))
                return new Pudelko(a, b, c, unit);
            else
                throw new FormatException("not supported format of input");


        }
        public override int GetHashCode() => (A, B, C).GetHashCode();

        //public IEnumerator GetEnumerator()
        //{
            
        //}

        public static bool operator ==(Pudelko p1, Pudelko p2) => Equals(p1, p2);
        public static bool operator !=(Pudelko p1, Pudelko p2) => !(p1 == p2);
        //public static Pudelko operator +(Pudelko p1, Pudelko p2)
        //{
        //    //patterns to check: ABC ACB BCA CBA
        //    double[] p1Measures = new double[] { p1.A, p1.B, p1.C };
        //    double[] p2Measures = new double[] { p2.A, p2.B, p2.C };

        //}
        #endregion
    }
}
