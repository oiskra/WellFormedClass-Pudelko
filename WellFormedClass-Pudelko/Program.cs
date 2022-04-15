using System;

namespace WellFormedClass
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var p = new Pudelko(a: 6.12354, c: 5.1); //b = 10cm
                var p1 = new Pudelko();

                Console.WriteLine(p.ToString());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            } 
        }
    }
}
