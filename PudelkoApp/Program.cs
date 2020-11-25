using System;
using PudelkoLib;

namespace PudelkoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Pudelko p = new Pudelko(2.5,9.231,0.1,UnitOfMeasure.meter);
            Console.WriteLine(p.A);
            Console.WriteLine(p.B);
            Console.WriteLine(p.C);

        }
    }
}
