using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryzyk3
{
    class Program
    {
        class ChooseWork
        {
            public int Var1;
            public int Var2;
            public double Probab1 = 0.5;
            public double Probab2 = 0.5;
            
            public ChooseWork(int v1,int v2)
            {
                Var1 = v1;
                Var2 = v2;
            }
            public double defineRiskReward(double Func)
            {
                double ExpectedWin = (Var1 + Var2) / 2.0;
                double ExpectUse = Probab1 * Math.Pow(Var1, 2.0) * Func + Probab2 * Math.Pow(Var2, 2.0) * Func;
                double DetermEquival = Math.Sqrt(ExpectUse / Func);
                return ExpectedWin-DetermEquival;
            }
        }
        static void Main(string[] args)
        {
            double Func = 0.01; //Variant 4 = 0,01x^2
            ChooseWork Work1 = new ChooseWork(2000,2000);
            ChooseWork Work2 = new ChooseWork(3000,1000);
            ChooseWork Work3 = new ChooseWork(4000, 0);
            double[] WorkRewards = new double[3];
            WorkRewards[0] = Work1.defineRiskReward(Func);
            WorkRewards[1] = Work2.defineRiskReward(Func);
            WorkRewards[2] = Work3.defineRiskReward(Func);
            if (Func > 0)
            {
                Console.WriteLine("Людина схильна до ризику: вона вибере " + (Array.IndexOf(WorkRewards, WorkRewards.Min()) + 1) + " роботу i її премія за ризик - " + WorkRewards.Min().ToString());
            }else if(Func < 0)
            {
                Console.WriteLine("Людина не схильна до ризику: вона вибере " + (Array.IndexOf(WorkRewards, WorkRewards.Max()) + 1) + " роботу i її премія за ризик - " + WorkRewards.Max().ToString());
            }
            else
            {
                Console.WriteLine("Людина нейтральна до ризику: вона вибере " + (Array.IndexOf(WorkRewards, 0.0) + 1) + " роботу i її премiя за ризик -  0.0");
            }
            Console.ReadKey();
        }
    }
}
