using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> fstcorp = new List<double>(new List<double> { 10.0, 0.5 });
            List<double> seccorp = new List<double>(new List<double> { 10.0, 1.0 });
            List<double> fstcorpch = new List<double>(new List<double> { 0.6, 0.4 });
            List<double> seccorpch = new List<double>(new List<double> { 0.4, 0.6 });
            double effectGrade = M(fstcorp,fstcorpch);
            double effectGrade2 = M(seccorp, seccorpch);
            double dispersion = V(fstcorp, fstcorpch, effectGrade);
            double dispersion2 = V(seccorp, seccorpch, effectGrade2);
            if (dispersion > dispersion2)
            {
                Console.WriteLine("Найбiльш вiрогiдний i вигiдний варiант злиття - 1 корпорацiя: " + "{0:F5} млн. $",dispersion);
            } else Console.WriteLine("Найбiльш вiрогiдний i вигiдний варiант злиття - 2 корпорацiя: " + "{0:F5} млн. $", dispersion2);
            Console.WriteLine(dispersion2);
            Console.ReadKey();
        }

        public static double M(List<double> X, List<double> P)
        {
            double res;
            res = X[0] * P[0] + X[1] * P[1];
            return res;
        }

        public static double V(List<double> X, List<double> P, double eg)
        {
            double result;
            result = Math.Sqrt(P[0] * Math.Pow((X[0] - eg),2.0) + P[1] * Math.Pow((X[1] - eg),2.0));
            return result;
        }
    }
}
