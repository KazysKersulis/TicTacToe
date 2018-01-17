using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{

    class Players
    {
        public string Player { get; set; }
        public string Opponent { get; set; }
    }

    class Program : Players
    {

        public static void EndGame()
        {
            Console.WriteLine("Ar norite žaisti dar kartą?");
            string input = Console.ReadLine();

            if (input.ToLower().Equals("taip"))
            {
                Board();

            }
            else if (input.ToLower().Equals("ne"))
            {
                Environment.Exit(0);
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
