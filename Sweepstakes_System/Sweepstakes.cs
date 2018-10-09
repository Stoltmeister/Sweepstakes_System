using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_System
{
    class Sweepstakes
    {
        Dictionary<string, string> Contestants = new Dictionary<string, string>();

        public Sweepstakes(string name)
        {

        }

        private void RegisterContestant(Contestant contestant)
        {

        }

        private string PickWinner()
        {
            return "";
        }

        private void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine("Name: " + contestant.FirstName + " " + contestant.LastName + "\n");
            Console.WriteLine("Email: " + contestant.Email + "\n");
            Console.WriteLine("Registration # : " + contestant.RegistrationNum + "\n");
        }
    }
}
