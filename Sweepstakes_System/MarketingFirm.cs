using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace Sweepstakes_System
{
    class MarketingFirm
    {
        ISweepstakesManager manager;
        SmtpClient client = new SmtpClient("smtp.gmail.com");

        public MarketingFirm(ISweepstakesManager manager)
        {
            this.manager = manager;
        }

        private static void DisplayWelcome()
        {
            string message = "Welcome to the Marketing Firm. This application will allow you to create and run sweepstakes with the manager you chose. \n";
            Console.WriteLine(message);
        }


        public void RunFirm()
        {
            bool gettingSweepstakes = true;
            bool runningSweepstakes = true;
            DisplayWelcome();
            do
            {

                Console.WriteLine("Lets create a Sweepstakes! \n");
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
                    if (UserInterface.GetInput("No more Sweepstakes! Would you like to create more? ('Y' or 'N')").ToLower() == "n")
                    {
                        Console.WriteLine("Ok Goodbye (Any key to exit)");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        RunFirm();
                        return;
                    }
                }
                if (UserInterface.GetInput("Run another sweepstakes? ('Y' or 'N' \n").ToLower() == "n")
                {
                    runningSweepstakes = false;
                }
            } while (runningSweepstakes);
        }

        private void RunSweepstakes(Sweepstakes sweepstakes)
        {
            Console.WriteLine("Lets pick a winner for " + sweepstakes.Name + ". Are you ready? (any key to continue) \n");
            Console.ReadLine();
            sweepstakes.PickWinner();
            NotifyUsers(sweepstakes);
            //Console.WriteLine("The winner of " + sweepstakes.Name + " is ");
            sweepstakes.PrintContestantInfo(sweepstakes.Winner);
            Console.WriteLine("Emailing the winner.");
            Console.ReadLine();
            EmailWinner(sweepstakes);
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

        public void EmailWinner(Sweepstakes sweepstakes)
        {
            // works but I took out the password cause I probably don't want that public ;)

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("stoltenberg96@gmail.com");
            mail.To.Add(sweepstakes.Winner.Email);
            mail.Subject = "You won " + sweepstakes.Name + "!";
            mail.Body = "Congratulations " + sweepstakes.Winner.FirstName + " you won the sweepstakes!";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("stoltenberg96@gmail.com", "password");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }

        public void NotifyUsers(Sweepstakes sweepstakes)
        {
            foreach (KeyValuePair<int, Contestant> contestant in sweepstakes.AllContestants)
            {
                if (contestant.Value == sweepstakes.Winner)
                {
                    Console.WriteLine("The Sweepstakes has concluded. YOU WON POGGERS!");
                }
                else
                {
                    contestant.Value.Notify(sweepstakes.Winner);
                }
            }

        }
    }
}
