using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_System
{
    class MarketingFirm
    {
        ISweepstakesManager manager;

        public MarketingFirm()
        {            
        }

        private static void DisplayWelcome()
        {
            string message = "";
            Console.WriteLine(message);
        }

        private static ISweepstakesManager GetManager()
        {
            // dependency injection needed
            // probably not needed until methods implemented
            switch (UserInterface.GetInput("Enter '1' if you would like to use the StackManager or '2' if you would like to use the QueueManager \n"))
            {
                case "1": SweepstakesStackManager stackSweep = new SweepstakesStackManager();
                    return stackSweep;
                case "2": SweepstakesQueueManager queueSweep = new SweepstakesQueueManager();
                    return queueSweep;
                default:
                    // input checking?
                    return new SweepstakesStackManager();
            }
        }

        public void RunFirm()
        {
            manager = GetManager();
            Console.WriteLine("Lets create your first Sweepstakes \n");
            CreateSweepstakes();

        }

        private Sweepstakes CreateSweepstakes()
        {
            bool enteringContestants = true;
            Sweepstakes newSweepstakes = new Sweepstakes(UserInterface.GetInput("What name would you like for this Sweepstakes?"));
            Console.WriteLine("Please enter your contestants: \n");
            while (enteringContestants)
            {
                Contestant newContestant = new Contestant();
                newContestant.SetContestant();
                newSweepstakes.RegisterContestant(newContestant);

                if (UserInterface.GetInput("Add more contestants? ('Y' or 'N')").ToLower() == "y")
                {
                    enteringContestants = false;
                }
            }
                  
            return newSweepstakes;
        }
        
    }
}
