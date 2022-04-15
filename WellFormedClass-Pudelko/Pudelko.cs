using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellFormedClass 
{
    public sealed class Pudelko : IEquatable<Pudelko>, IFormattable, IEnumerable
    {

        public readonly double A;
        public readonly double B;
        public readonly double C;
        public readonly UnitOfMeasure Unit;
        public double Pole { get => Math.Round(2 * A * B + 2 * B * C + 2 * A * C, 6); }
        public double Objetosc { get => Math.Round(A * B * C, 9); }

        public static bool operator == (Pudelko p1, Pudelko p2)
        {
            return
        }
        public static bool operator != (Pudelko p1, Pudelko p2)
        {
            return
        }
        public static implicit operator double(Pudelko p)
        {
            return 
        } 
            




        public Pudelko(double a = 10, double b = 10, double c = 10, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if (a < 0 || b < 0 || c < 0) throw new ArgumentOutOfRangeException();
            if ((a > 10 || b > 10 || c > 10) && unit == UnitOfMeasure.meter) throw new ArgumentOutOfRangeException();

            A = a;
            B = b;
            C = c;
            Unit = unit;
        }

        public bool Equals(Pudelko other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{A} × {B} × {C}";
        }

        public string ToString(string format)
        {
            return this.ToString(format, null);
        } 

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "mm":
                    return $"{A} mm × {B} mm × {C} mm";
                case "cm":
                    return $"{A} cm × {B} cm × {C} cm";
                case "m":
                    return $"{A} m × {B} m × {C} m";
                default:
                    throw new FormatException();
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
