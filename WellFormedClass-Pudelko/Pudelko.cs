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
        private double _a;
        private double _b;
        private double _c;
        public double A { get => _a / 100; private set { } } //metry
        public double B { get => _b / 100; private set { } }
        public double C { get => _c / 100; private set { } }
        public UnitOfMeasure Unit { get;  private set; }
        public double Pole { get => Math.Round(2 * A * B + 2 * B * C + 2 * A * C, 6); }
        public double Objetosc { get => Math.Round(A * B * C, 9); }

        public static bool operator ==(Pudelko p1, Pudelko p2)
            => (p1.A == p2.A && p1.B == p2.B && p1.C == p2.C);

        public static bool operator !=(Pudelko p1, Pudelko p2)
            => (p1.A != p2.A || p1.B != p2.B || p1.C != p2.C);


        private double ChangeDecimalPointToCM(double number)
        {
            switch (Unit)
            {
                case UnitOfMeasure.milimeter:
                    return number / 10;
                case UnitOfMeasure.centimeter:
                    return number; 
                case UnitOfMeasure.meter:
                    return number * 100;
                default:
                    throw new FormatException();
            }
        }



        public Pudelko(double? a = null, double? b = null, double? c = null,  UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if (a < 0 || b < 0 || c < 0) throw new ArgumentOutOfRangeException();
            else if ((a > 10 || b > 10 || c > 10) && unit == UnitOfMeasure.meter) throw new ArgumentOutOfRangeException();

            // jesli param jest null to sprawdz unitOfMeasure
            //jesli unit of measure jest cm to spoko
            // jesli uom jest meter to pomnoz razy 100
            //jesli uom jest mm to podziel przez 10
            double tempA, tempB, tempC;
            tempA = (a is null) ? ChangeDecimalPointToCM((double)a) : 1;
            if (b is null) tempB = ChangeDecimalPointToCM((double)b);
            if (c is null) tempC = ChangeDecimalPointToCM((double)c);

            Unit = unit;
            _a = ChangeDecimalPointToCM(tempA);
            _b = ChangeDecimalPointToCM(tempB);
            _c = ChangeDecimalPointToCM(tempC);

        }

        public bool Equals(Pudelko other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Pudelko);
        }


        //dla pudełka o wymiarach kolejno 2.5, 9.321 i 0.1, ToString() zwraca napis "2.500 m × 9.321 m × 0.100 m"
        public override string ToString() => $"{A:F3} × {B:F3} × {C:F3}";

        public string ToString(string format) => this.ToString(format);

        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            // do rozbudowania zmienianie jednostek
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
