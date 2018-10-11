using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_System
{
    class SweepstakesQueueManager : ISweepstakesManager
    {
        Queue<Sweepstakes> allSweepstakes;

        public SweepstakesQueueManager()
        {
            allSweepstakes = new Queue<Sweepstakes>();
        }

        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            allSweepstakes.Enqueue(sweepstakes);
        }
        public Sweepstakes GetSweepstakes()
        {
            return allSweepstakes.Dequeue();
        }
    }
}