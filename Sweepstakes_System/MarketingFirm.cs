using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_System
{
    class MarketingFirm
    {
        public static ISweepstakesManager GetManager()
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
        
    }
}
