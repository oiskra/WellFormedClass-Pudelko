using System;
using System.Collections.Generic;

namespace WellFormedClass
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pudelko> list = new() { 
                new Pudelko(12,3,60, UnitOfMeasure.centimeter),
                new Pudelko(1, 3, 6),
                new Pudelko(42, 150, UnitOfMeasure.milimeter),
                new Pudelko(1348, UnitOfMeasure.milimeter),
                new Pudelko(10, UnitOfMeasure.meter),
            };

            Console.WriteLine("Unsorted:");
            foreach (var item in list)
            {
                Console.WriteLine($"{item} volume: {item.Objetosc} area: {item.Pole}");
            }

            list.Sort(ComparePudelko);
            
            Console.WriteLine();
            Console.WriteLine("Sorted:");
            foreach (var item in list)
            {
                Console.WriteLine($"{item} volume: {item.Objetosc} area: {item.Pole}");
            }

            Console.WriteLine();
            Console.WriteLine("Compression:");
            Console.WriteLine("------------------------------------------");
            foreach (var item in list)
            {
                var p = item.Kompresuj();
                Console.WriteLine($"Input: {item} volume: {item.Objetosc}");
                Console.WriteLine($"Compressed: {p} volume: {p.Objetosc}");
                Console.WriteLine("------------------------------------------");
            }

        }

        static int ComparePudelko(Pudelko p1, Pudelko p2)
        {
            int volumeValue = p1.Objetosc.CompareTo(p2.Objetosc);
            int areaValue = p1.Pole.CompareTo(p2.Pole);
            
            if (volumeValue != 0) 
                return volumeValue;
            else
            {
                if (areaValue != 0)
                    return areaValue;
                else
                    return p1.A + p1.B + p1.C > p2.A + p2.B + p2.C ? 1 : -1;
            }   
        }
    }
}
