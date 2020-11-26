using System;
using System.Collections.Generic;
using PudelkoLib;

namespace PudelkoApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            double a = 0.77777;
            Console.WriteLine(Math.Round(a,3));
            a = Math.Truncate(1000 * a) / 1000;
            Console.WriteLine(a);

            //Pudelko p1 = new Pudelko(10, 10,10 );
            //Pudelko p2 = p1.Kompresuj();
            //Console.WriteLine(p1.ToString());
            //Console.WriteLine(p2.ToString());
            //Console.WriteLine(p1.Objetosc);
            //Console.WriteLine(p2.Objetosc);

            //List<Pudelko> lista = new List<Pudelko>();
            //Pudelko p = new Pudelko(2, 5);
            //Pudelko p1 = new Pudelko(1, 3, 4);
            //Pudelko p2 = new Pudelko(0.5, 5.5, 3.3,UnitOfMeasure.milimeter);
            //Pudelko p3 = new Pudelko(3.3);
            //Pudelko p4 = new Pudelko(6, 5, 0.3, UnitOfMeasure.centimeter);
            //Pudelko p5 = new Pudelko(5.2, 0.93);
            //lista.Add(p1);
            //lista.Add(p2);
            //lista.Add(p3);
            //lista.Add(p4);
            //lista.Add(p5);
            //foreach (var x in lista)
            //{
            //    Console.WriteLine(x);
            //}
            //lista.Sort(Pudelko.CompareBox);
            //Console.WriteLine("------------");
            //foreach (var x in lista)
            //{
            //    Console.WriteLine(x);
            //}

            //Pudelko p = new Pudelko(1, 2, 3, UnitOfMeasure.meter);
            //Console.WriteLine(p[0]);
            //Console.WriteLine(p[1]);
            //Console.WriteLine(p[2]);

            //Console.WriteLine("Hello World!");
            //Pudelko p = new Pudelko(0.1, 2.5);
            //Console.WriteLine(  p.ToString());
            //Console.WriteLine(p.A);
            //Console.WriteLine(p.B);
            //Pudelko p1 = new Pudelko(a: 5, b: 3);
            //Console.WriteLine(p1.ToString());
            //Pudelko p2 = new Pudelko(a:-1.0);
            //Pudelko p = new Pudelko(unit: UnitOfMeasure.centimeter, a: 11);
            //Console.WriteLine(p.ToString());
            //double x = 2.59999;
            //string y = string.Format("{0:0.000}", x);
            //double z = Convert.ToDouble(y);
            //Console.WriteLine(x);
            //Console.WriteLine(y);
            //Console.WriteLine(z);

            //Pudelko p = new Pudelko(1,2.1,3.05);
            //Pudelko p1 = new Pudelko(1,3.05,2.1);
            //Pudelko p2 = new Pudelko(2.1, 1, 3.05);
            //Pudelko p3 = new Pudelko(2100, 1000, 3050, UnitOfMeasure.milimeter);
            //Console.WriteLine("p equals p1" + p.Equals(p1));
            //Console.WriteLine(" equals pp1"+Pudelko.Equals(p,p1));
            //Console.WriteLine("==" + (p == p1));
            //Console.WriteLine("!=" + (p!=p1));
            //Console.WriteLine("p1 equals p2" + p1.Equals(p2));
            //Console.WriteLine(" equals p1p2" + Pudelko.Equals(p1, p2));
            //Console.WriteLine("==" + (p1 == p2));
            //Console.WriteLine("!=" + (p1 != p2));
            //Console.WriteLine("p equals p3" + p.Equals(p3));
            //Console.WriteLine(" equals p1p3" + Pudelko.Equals(p1, p3));
            //Console.WriteLine("==" + (p1 == p3));
            //Console.WriteLine("!=" + (p1 != p3));
            //Console.WriteLine("--------------------");
            //Console.WriteLine("p equals p3" + p.Equals(p3));
            //Console.WriteLine("p1 equals p3" + p1.Equals(p3));
            //Console.WriteLine("p2 equals p3" + p2.Equals(p3));
            //Console.WriteLine("-------------------");
            //Console.WriteLine("equals pp3" + Pudelko.Equals(p,p3));
            //Console.WriteLine("equals p1p3" + Pudelko.Equals(p1,p3));
            //Console.WriteLine("equals p2p3" + Pudelko.Equals(p2,p3));
            //Console.WriteLine("--------------");
            //Console.WriteLine("p==p3" + (p == p3));
            //Console.WriteLine("p1==p3" + (p1 == p3));
            //Console.WriteLine("p2==p3" + (p2 == p3));
            //Console.WriteLine($"P:  {p.A} {p.B} {p.C}");
            //Console.WriteLine($"P3: {p3.A} {p3.B} {p3.C}");
            //Console.WriteLine("p == p2" + (p==p2));





        }
        public static Pudelko Kompresuj(this Pudelko p)
        {
            double pudelkoObj = p.Objetosc;
            double sqrt = Math.Pow(pudelkoObj, (double)1 / 3);
            return new Pudelko(sqrt, sqrt, sqrt);
        }
    }
}
