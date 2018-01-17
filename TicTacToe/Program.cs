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

        private static void Grid()
        {

            string[] GameGridArray = new string[9];
            int index = 0;

            for (int i = 0; i < GameGridArray.Length; i++)
            {
                GameGridArray[i] = index.ToString();
                index++;
            }

            Random Numbergen = new Random();

        }

        public static void EndGame()
        {
            Console.WriteLine("Ar norite žaisti dar kartą?");
            string input = Console.ReadLine();

            if (input.ToLower().Equals("taip"))
            {
                Grid();

            }
            else if (input.ToLower().Equals("ne"))
            {
                Environment.Exit(0);
            }
        }

        static void Main(string[] args)
        {
            Grid();
        }
    }
}
