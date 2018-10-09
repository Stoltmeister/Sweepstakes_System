using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_System
{
    class UserInterface
    {
        public static string GetInput(string message)
        {
            Console.WriteLine(message + "\n");
            string input = Console.ReadLine();
            return input;
        }
    }
}
