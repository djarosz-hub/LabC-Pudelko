using System;
using PudelkoLib;

namespace PudelkoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Pudelko p = new Pudelko(1, 2, 3, UnitOfMeasure.meter);
            Console.WriteLine(p[0]);
            Console.WriteLine(p[1]);
            Console.WriteLine(p[2]);

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
            //double x = 2.5559;
            //string y = string.Format("{0:0.00}", x);
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
    }
}
