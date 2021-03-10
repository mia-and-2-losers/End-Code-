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
            string filePath = @"D:\visual studio\Voting System\Voting System\Vote\Assessment1TestResults.txt";

            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (string line in lines)

            {
                Console.WriteLine(line);
            }

            Console.ReadLine();

        }
    }
}