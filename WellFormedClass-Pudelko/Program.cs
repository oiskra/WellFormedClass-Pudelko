using System;

namespace WellFormedClass
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var p = new Pudelko (1001, 100, 2500, unit: UnitOfMeasure.milimeter);
                var p1 = new Pudelko(250, 100.1, 10, unit: UnitOfMeasure.centimeter);
                if (p.Equals(p1)) Console.WriteLine("są równe");
                else Console.WriteLine("nie są równe");

                var test = new Pudelko(1, unit: UnitOfMeasure.milimeter);
                Console.WriteLine("obj" + p.Objetosc);
                
                Console.WriteLine(p.A);
                Console.WriteLine(p.B);
                Console.WriteLine(p.C);
                Console.WriteLine();
                Console.WriteLine(p.ToString("mm"));
                Console.WriteLine(p.ToString("cm"));
                Console.WriteLine(p.ToString("m"));
                Console.WriteLine(p.ToString(null));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } 
        }
    }
}
