using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    class Program
    {

        static void Main(string[] args)
        {
            string filePath = @"D:\visual studio\Voting System\Voting System\Vote\Assessment1Data   .txt";

            List<string> file = File.ReadAllLines(filePath).ToList();

            List<Party> partys = new List<Party>();
            foreach (string line in file)

            {
                string[] items = line.Split(',');
                Party p = new Party(items[0], Convert.ToInt32(items[1]));
                partys.Add(p);
            }

            Console.WriteLine("poooooop");
            int thresHold = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the threshold for partys (% round number)");
            int seatsCount = Convert.ToInt32(Console.ReadLine());

            int totalVotes = SumOfVotes(partys);
            object p1 = DisplayPercentageVotes(partys, thresHold, totalVotes);
            CalculateDhondt(partys, seatsCount);
            DisplayWinningParties(partys);

            Console.ReadKey();
        }

        private static void DisplayWinningParties(List<Party> partys)
        {
            foreach (Party p in partys)
            {
                if (p.Seats > 0)
                {
                    Console.WriteLine(p);
                }
            }
        

        private static void DisplayPercentageVotes(List<Party> partys, int threshold, int totalvotes);
        {
            Console.WriteLine($"PARTIES THAT MEET THE {threshold} % INPUTTED THRESHOLD: ");
            foreach (Party p in partys)
            {
                if (p.PercentOfVotes(totalvotes) > threshold)
                {
                    Console.WriteLine($"{p.Name} has {Math.Round(p.PercentOfVotes(totalvotes),2)} % of total votes");
                
            
        
            private static void CalculateDhondt(List<Party> partys, int seatsCount)
        {

            Party biggestVote = partys.Aggregate((v1, v2) => v1.Votes > v2.Votes ? v1 : v2);
            biggestVote.Seats += 1;
            biggestVote.DivideParty();

            int totalSeatscount = 0;
            while (totalSeatscount != seatsCount)

            {
                Party biggestVotes = partys.Aggregate((v1, v2) => v1.NewVotes > v2.NewVotes ? v1 : v2);
                biggestVotes.Seats += 1;
                biggestVotes.DivideParty();

                foreach (Party p in Party)
                {
                    totalSeatscount += p.Seats;
                }

                if (totalSeatscount != seatsCount)
                {
                                    totalSeatscount = 0;
                }
            }
        Console.WriteLine($"\nWE HAVE {seatsCount} SEATS ALLOCATED: ");
        }
    }
}



class Party
        {
            public string Name { get; private set; }
            public int Votes { get; private set; }
            public int NewVotes { get; private set; }
            public int Seats { get; set; }


            public Party(string name, int votes)
            {
                Name = name;
                Votes = votes;
                NewVotes = Votes;
            }

            public double PercentOfVotes(double totalVotes) => (Votes / totalVotes) * 100;

            public override string ToString()
            {
                return $"NAME: {Name} Votes: {Votes} Seats: {Seats}";
            }

            public void DivideParty()
            {
                NewVotes = Votes / (1 + Seats);
            }
        }




