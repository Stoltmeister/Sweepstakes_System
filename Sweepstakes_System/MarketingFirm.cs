﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_System
{
    class MarketingFirm
    {
        ISweepstakesManager manager;

        public MarketingFirm(ISweepstakesManager manager)
        {
            this.manager = manager;
        }

        private static void DisplayWelcome()
        {
            string message = "";
            Console.WriteLine(message);
        }


        public void RunFirm()
        {
            bool gettingSweepstakes = true;
            bool runningSweepstakes = true;
            do
            {
                Console.WriteLine("Lets create a Sweepstakes \n");
                manager.InsertSweepstakes(CreateSweepstakes());
                if (UserInterface.GetInput("Create more Sweepstakes?  ('Y' or 'N') \n").ToLower() == "n")
                {
                    gettingSweepstakes = false;
                }
            } while (gettingSweepstakes);

            do
            {                 
                Console.WriteLine("Lets run a sweepstakes! \n");
                try
                {
                    RunSweepstakes(manager.GetSweepstakes());
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("No more Sweepstakes!");
                }
                if (UserInterface.GetInput("Run another sweepstakes? ('Y' or 'N' \n").ToLower() == "n")
                {
                    runningSweepstakes = false;
                }                
            } while (runningSweepstakes);
        }

        private void RunSweepstakes(Sweepstakes sweepstakes)
        {            
            Console.WriteLine("Lets pick a winner for " + sweepstakes.Name +"\n");
            sweepstakes.PickWinner();
            Console.WriteLine("The winner of " + sweepstakes.Name + "is ");
            sweepstakes.PrintContestantInfo(sweepstakes.Winner);            
        }

        private Sweepstakes CreateSweepstakes()
        {
            bool enteringContestants = true;
            Sweepstakes newSweepstakes = new Sweepstakes(UserInterface.GetInput("What name would you like for this Sweepstakes? \n"));
            Console.WriteLine("Please enter your contestants: \n");
            while (enteringContestants)
            {
                Contestant newContestant = new Contestant();
                newContestant.SetContestant();
                newSweepstakes.RegisterContestant(newContestant);

                if (UserInterface.GetInput("Add more contestants? ('Y' or 'N') \n").ToLower() == "n")
                {
                    enteringContestants = false;
                }
            }
            return newSweepstakes;
        }

    }
}
