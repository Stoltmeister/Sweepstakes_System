using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_System
{
    static class ManagerFactory
    {
        public static ISweepstakesManager GetManager()
        {
            // dependency injection needed
            // probably not needed until methods implemented
            ISweepstakesManager manager;
            switch (UserInterface.GetInput("Enter '1' if you would like to use the StackManager or '2' if you would like to use the QueueManager \n"))
            {
                case "1":
                    manager = new SweepstakesStackManager();
                    return manager;
                case "2":
                    manager = new SweepstakesQueueManager();
                    return manager;
                default:
                    Console.Clear();
                    Console.WriteLine("Please enter correct input! \n");
                    return GetManager();                    
            }
        }
    }
}
