using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_System
{
    class Contestant
    {
        string firstName;
        string lastName;
        string email;
        int registrationNum;        

        public void SetContestant()
        {
            firstName = UserInterface.GetInput("");
            firstName = UserInterface.GetInput("");
            email = UserInterface.GetInput("");
            registrationNum = Int32.Parse(UserInterface.GetInput("Please enter the registration Number: "));
        }
    }
}
