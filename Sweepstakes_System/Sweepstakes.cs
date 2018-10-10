﻿using System;
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
        Dictionary<string, Contestant> allContestants;

        public Sweepstakes(string name)
        {
            this.name = name;
            Contestant winner = new Contestant();
            Dictionary<string, Contestant> allContestants = new Dictionary<string, Contestant>();
        }

        private void RegisterContestant(Contestant contestant)
        {

        }
        public IEnumerable<TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dict)
        {
            Random rand = new Random();
            List<TValue> contestants = Enumerable.ToList(dict.Values);
            int size = dict.Count;
            yield return contestants[rand.Next(size)];            
        }

        private string PickWinner()
        {                        
            foreach (Contestant contestant in RandomValues(allContestants).Take(1))
            {
                winner = contestant;
            }
            return winner.FirstName;
        }

        private void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine("Name: " + contestant.FirstName + " " + contestant.LastName + "\n");
            Console.WriteLine("Email: " + contestant.Email + "\n");
            Console.WriteLine("Registration # : " + contestant.RegistrationNum + "\n");
        }
    }
}
