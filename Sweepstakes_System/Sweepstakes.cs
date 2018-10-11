using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_System
{
    class Sweepstakes
    {
        string name;
        Contestant winner;
        Dictionary<int, Contestant> allContestants;

        public Sweepstakes(string name)
        {
            this.name = name;
            Contestant winner = new Contestant();
            allContestants = new Dictionary<int, Contestant>();
        }

        public Dictionary<int, Contestant> AllContestants
        {
            get => allContestants;
        }

        public string Name
        {
            get => name;
        }
        public Contestant Winner
        {
            get => winner;
        }

        public void RegisterContestant(Contestant contestant)
        {
            allContestants.Add(contestant.RegistrationNum, contestant);
            Console.WriteLine("Contestant added! \n");
            PrintContestantInfo(contestant);
        }
        public IEnumerable<TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dict)
        {
            Random rand = new Random();
            List<TValue> contestants = Enumerable.ToList(dict.Values);
            int size = dict.Count;
            yield return contestants[rand.Next(size)];            
        }

        public string PickWinner()
        {                        
            foreach (Contestant contestant in RandomValues(allContestants).Take(1))
            {
                winner = contestant;
            }
            return winner.FirstName;
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine("Name: " + contestant.FirstName + " " + contestant.LastName + "\n");
            Console.WriteLine("Email: " + contestant.Email + "\n");
            Console.WriteLine("Registration # : " + contestant.RegistrationNum + "\n");
        }
    }
}
