using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using static System.Math;

namespace ToRefactorForOctave
{
    class Program
    {
        public const double Surface = 0.0065;
        public static double mass = 0.03317;
        public const double G = 9.81;
        public const double density = 1.2;
        public const double Multiplier = 0.5;
        public const double el0 = 0;
        public static double accel;
        public static double spd;
        public static double deltat;
        public static double veloc;
        public static double x;
        public static double x0;
        public static double t=0;
        public static double xprev;
        public static double velocprev;
        public static double g;
        public static double alpha;
        public static double B;


        static void Main(string[] args)
        {
            Console.WriteLine("Insert x0 in following line");
            Double.TryParse(Console.ReadLine().Replace('.', ','), out x0);
            Thread.Sleep(1);
            velocprev = 0;
            deltat = 0.01;
            xprev = x0;
            StreamWriter wrtofile = new StreamWriter($"D:\\experimental {x0}.txt");
            Console.WriteLine($"Here will be output of experimental data");
            B = density * Surface * Multiplier / (2 * mass);
            while (xprev>=0)
            {
                Console.WriteLine($"{t} , {deltat} , {x} , {veloc} , {accel} , {g} ");
                wrtofile.WriteLine($"{t} , {deltat} , {x} , {veloc} , {accel} , {g} ");
                alpha =  2 * deltat * density * veloc * Surface  * Multiplier / mass;
                g = (1 - alpha)*(1 + alpha);
                veloc = (-1 + Pow((1 + 4 * B * deltat * (velocprev + G * deltat)),0.5))/(B*deltat) ;
                accel = (veloc - velocprev) / deltat;
                x = xprev - velocprev * deltat - accel * Math.Pow(deltat, 2) / 2;
                t = t + deltat;
                deltat = 0.1;
                xprev = x;
                velocprev = veloc;
                

            }
            wrtofile.Close();
            Console.ReadKey();

        }
    }
}
