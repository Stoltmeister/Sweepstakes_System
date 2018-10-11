using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_System
{
    class Program
    {
        static void Main(string[] args)
        {
            MarketingFirm firm = new MarketingFirm(ManagerFactory.GetManager());
            firm.RunFirm();

            //Sweepstakes test = new Sweepstakes("test");
            //    for (int i = 0; i < 4; i++)
            //    {
            //        Contestant contestant = new Contestant();
            //        contestant.SetContestant();
            //        test.RegisterContestant(contestant);
            //    }

            //    Console.WriteLine(test.PickWinner());
            //    Console.ReadLine();
            //}
        }

    }
}