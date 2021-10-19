using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToRefactorForOctave
{
    class Program
    {
        public const double Surface = 65;
        public const double mass = 2.224;
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

        static void Main(string[] args)
        {
            Console.WriteLine("Insert x0 in following line");
            Double.TryParse(Console.ReadLine().Replace('.', ','), out x0);
            Thread.Sleep(1);
            velocprev = 0;
            deltat = 0.1;
            xprev = x0;
            Console.WriteLine($"Here will be output of experimental data");
            while (xprev>=0)
            {
                Console.WriteLine($"{t} , {deltat} , {x} , {veloc} , {accel} , {g} ");
                accel = G - 0.5 * density * Math.Pow(velocprev, 2) * Surface * Multiplier / mass;
                alpha = density * veloc * Surface * Multiplier * deltat;
                g = 1 - alpha;
                veloc = velocprev + accel * deltat;
                x = xprev - velocprev * deltat - accel * Math.Pow(deltat, 2) / 2;
                t = t + deltat;
                deltat = 0.2 * mass / (density * veloc * Surface * Multiplier);
                xprev = x;
                velocprev = veloc;
                

            }
            Console.ReadKey();

        }
    }
}
