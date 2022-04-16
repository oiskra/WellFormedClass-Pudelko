using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellFormedClass 
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;
        public double A
        {
            get
            {
                if (Unit == UnitOfMeasure.milimeter) return _a / 1000;
                else if (Unit == UnitOfMeasure.centimeter) return _a / 100;
                else return _a;
            }
        }
        public double B
        {
            get
            {
                if (Unit == UnitOfMeasure.milimeter) return _b / 1000;
                else if (Unit == UnitOfMeasure.centimeter) return _b / 100;
                else return _b;
            }
        }
        public double C
        {
            get
            {
                if (Unit == UnitOfMeasure.milimeter) return _c / 1000;
                else if (Unit == UnitOfMeasure.centimeter) return _c / 100;
                else return _c;
            }
        }
        public readonly UnitOfMeasure Unit; 
        public double Pole 
        {
            get 
            { 
                return Math.Round(2 * (A * B +  B * C +  A * C), 6); 
            }
        } 
        public double Objetosc 
        {
            get 
            { 
                return Math.Round(A * B * C, 9); 
            }
        } 
        public static bool operator ==(Pudelko p1, Pudelko p2) 
            => p1.Equals(p2);
        public static bool operator !=(Pudelko p1, Pudelko p2) 
            => !(p1 == p2);
        public static Pudelko operator +(Pudelko p1, Pudelko p2)
            => new Pudelko(p1.A + p2.A, p1.B + p2.B, p1.C + p2.C, unit: UnitOfMeasure.meter); 
        public static explicit operator double[](Pudelko p) 
            => new double[] {p._a,p._b,p._c};
        public static implicit operator Pudelko(ValueTuple<int,int,int> tuple) 
            => new Pudelko(tuple.Item1, tuple.Item2, tuple.Item3, UnitOfMeasure.milimeter);
        public double this[int index]
        {
            get
            {
                var doubleArray = (double[])this;
                return doubleArray[index];
            }
        }

        private static double ChangeDecimalPoint(double number, UnitOfMeasure unit)
        {
            switch (unit)
            {
                case UnitOfMeasure.milimeter:
                    return number * 10;
                case UnitOfMeasure.centimeter:
                    return number; 
                case UnitOfMeasure.meter:
                    return number / 100;
                default:
                    throw new FormatException();
            }
        }

        #region constructors
        public Pudelko(double a, double b, double c, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            Unit = unit;
            _a = a;
            _b = b;
            _c = c;

            if (A > 10 || B > 10 || C > 10) throw new ArgumentOutOfRangeException();
            else if (A < 0.001 || B < 0.001 || C < 0.001) throw new ArgumentOutOfRangeException();
        }

        public Pudelko(double a, double b, UnitOfMeasure unit = UnitOfMeasure.meter) 
            : this(a,b, ChangeDecimalPoint(10, unit), unit) { }

        public Pudelko(double a, UnitOfMeasure unit = UnitOfMeasure.meter) 
            : this(a, ChangeDecimalPoint(10, unit), ChangeDecimalPoint(10, unit), unit) { }

        public Pudelko(UnitOfMeasure unit = UnitOfMeasure.meter) 
            : this(ChangeDecimalPoint(10, unit), ChangeDecimalPoint(10, unit), ChangeDecimalPoint(10, unit), unit) { }

        #endregion

        public override string ToString() 
            => this.ToString("m", null);

        public string ToString(string format) 
            => this.ToString(format, null);

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if(format is null) return $"{A:F3} m × {B:F3} m × {C:F3} m";
            switch (format)
            {
                case "mm":
                    return $"{A*1000} mm × {B * 1000} mm × {C * 1000} mm";
                case "cm":
                    return $"{A * 100:F1} cm × {B * 100:F1} cm × {C * 100:F1} cm";
                case "m":
                    return $"{A:F3} m × {B:F3} m × {C:F3} m";
                default:
                    throw new FormatException();                    
            }
        }

        public bool Equals(Pudelko other)
        {
            double[] thisArr = new[] { this.A, this.B, this.C };
            double[] otherArr = new[] { other.A, other.B, other.C };
            int sameValueCount = 0;

            foreach (double item in thisArr)
            {
                if (otherArr.Contains(item)) sameValueCount++;
            }

            if (sameValueCount == 3) return true;
            else return false;

        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (obj is Pudelko other) return Equals(other);
            
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(A, B, C);
        }

        public IEnumerator GetEnumerator()
        {
            var arr = (double[])this;
            foreach (double item in arr)
            {
                yield return item;
            }
        }

        public static Pudelko Parse(string text)
        {
            string[] textArr = text.Split(" ");
            double a = double.Parse(textArr[0]);
            double b = double.Parse(textArr[3]);
            double c = double.Parse(textArr[6]);
            switch (textArr[1])
            {
                case "mm":
                    return new Pudelko(a, b, c, UnitOfMeasure.milimeter);
                case "cm":
                    return new Pudelko(a, b, c, UnitOfMeasure.centimeter);
                case "m":
                    return new Pudelko(a, b, c, UnitOfMeasure.meter);
                default:
                    throw new ArgumentException("Zły argument");
            }

        } 
    }
}
