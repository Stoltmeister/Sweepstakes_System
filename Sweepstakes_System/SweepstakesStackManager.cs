using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_System
{
    class SweepstakesStackManager: ISweepstakesManager
    {

        Stack<Sweepstakes> allSweepstakes;

        public SweepstakesStackManager()
        {
            Stack<Sweepstakes> allSweepstakes = new Stack<Sweepstakes>();
        }
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            allSweepstakes.Push(sweepstakes);
        }
        public Sweepstakes GetSweepstakes()
        {            
            return allSweepstakes.Pop();
        }
    }
}
