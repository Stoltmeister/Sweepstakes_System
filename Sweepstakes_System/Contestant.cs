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
            firstName = UserInterface.GetInput("Please enter the contestant's first name: ");
            lastName = UserInterface.GetInput("Please enter the contestant's last name: ");
            email = UserInterface.GetInput("Please enter the contestant's email address: ");
            registrationNum = int.Parse(UserInterface.GetInput("Please enter the registration Number: "));
        }

        public string FirstName
        {
            get => firstName;
        }
        public string LastName
        {
            get => lastName;
        }
        public string Email
        {
            get => email;
        }
        public int RegistrationNum
        {
            get => registrationNum;
        }
    }
}
