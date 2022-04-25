using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellFormedClass
{
    static class ExtensionMethods
    {
        public static Pudelko Kompresuj(this Pudelko p)
        {
            double side = Math.Cbrt(p.Objetosc);
            return new Pudelko(side, side, side);
        }
    }
}
