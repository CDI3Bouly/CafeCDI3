using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MachineACafe;

namespace CafeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            IMonnayeur testMon = new Monnayeur(1);

            Console.WriteLine(testMon.etat());

            testMon.insertCoin(1.00);

            Console.WriteLine(testMon.etat());

            double d = testMon.checkInsertedMoney(0.50);

            if (d < 0)
            {
                Console.WriteLine("Insérez " + Math.Abs(d) +" €");
            }

            else if (d == 0)
            {
                Console.WriteLine("Voilà votre café !");
            }

            else
            {
                Console.WriteLine("Voilà votre café et " + Math.Abs(d) + " € de monnaie.");
            }

            Console.ReadKey();

            
        }
    }
}
