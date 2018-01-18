using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{

    class Game
    {
        public static string Player { get; set; }
        public static string Opponent { get; set; }
        public static String[] GameGridArray = new string[9];

    }

    class Program : Game
    {
        private static void Grid()
        {

            int Index = 0;

            for (int i = 0; i < GameGridArray.Length; i++)
            {
                GameGridArray[i] = Index.ToString();
                Index++;
            }

            string WinorLose = "";
            Random Numbergen = new Random();
            int enemy = Numbergen.Next(0, 9);

            int freeSpaces = 9;

            while (freeSpaces > 0)
            {

                DrawGameGrid(GameGridArray);

                Console.WriteLine("Įveskite koordinatę, kur norėtumėte įstatyti {0} simbolį", Player);

                try
                {
                    string inputCoordinates = Console.ReadLine();

                    int input = TryConvertToInt(inputCoordinates);

                    //int input = Convert.ToInt32(inputCoordinates);

                    checkPlayerIndexBounds(input);
                    input = checkIfIndexIsNotOccupied(input);
                    GameGridArray[input] = Player;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " \nĮvyko klaida, bandykite dar kartą...");
                    Console.Write("Spauskite bet kurį mygtuką...");
                    Console.ReadKey();

                }

                if (!(freeSpaces <= 1))
                {
                    if (GameGridArray[enemy] == Opponent || GameGridArray[enemy] == Player)
                    {

                        do
                        {

                            enemy = Numbergen.Next(0, 9);

                            if (GameGridArray[enemy] != Player && GameGridArray[enemy] != Opponent)
                            {
                                GameGridArray[enemy] = Opponent;
                                break;

                            }

                        } while (GameGridArray[enemy] != Opponent || GameGridArray[enemy] != Player);

                    }
                    else
                    {
                        GameGridArray[enemy] = Opponent;
                    }
                }
                else break;

                if (CheckPlayerWin(0, 1, 2) || CheckPlayerWin(0, 4, 8) || CheckPlayerWin(3, 4, 5) ||
                    CheckPlayerWin(6, 7, 8) || CheckPlayerWin(6, 4, 2) || CheckPlayerWin(1, 4, 7) ||
                    CheckPlayerWin(0, 3, 6) || CheckPlayerWin(2, 5, 8))

                {
                    WinorLose = "laimėjai";
                    break;
                }

                else if (CheckOpponentWin(0, 1, 2) || CheckOpponentWin(0, 4, 8) || CheckOpponentWin(3, 4, 5) ||
                         CheckOpponentWin(6, 7, 8) || CheckOpponentWin(6, 4, 2) || CheckOpponentWin(1, 4, 7) ||
                         CheckOpponentWin(0, 3, 6) || CheckOpponentWin(2, 5, 8))
                {
                    WinorLose = "pralaimėjai";
                    break;
                }
                else if (freeSpaces <= 1)
                {
                    WinorLose = "Lygiosios!";
                    break;
                }
                else
                    freeSpaces = freeSpaces - 2;

            }
            Console.Clear();

            Console.WriteLine("{0}!", WinorLose);
            EndGame();
        }

        private static int TryConvertToInt(string inputCoordinates)
        {
            int returnedInput;
            int outInput;
            bool result = Int32.TryParse(inputCoordinates, out returnedInput);
            if (!result)
            {
                Console.WriteLine("Koordinate {0} yra neteisinga, bandykite įvesti nuo 0 iki 8", inputCoordinates);
                inputCoordinates = Console.ReadLine();
                TryConvertToInt(inputCoordinates);
            }
            outInput = Convert.ToInt32(inputCoordinates);
            return outInput;
        }

        private static bool CheckPlayerWin(int first, int second, int third)
        {
            return GameGridArray[first].ToLower().Equals(Player) && GameGridArray[second].ToLower().Equals(Player) && GameGridArray[third].ToLower().Equals(Player);
        }

        private static bool CheckOpponentWin(int first, int second, int third)
        {
            return GameGridArray[first].ToLower().Equals(Opponent) && GameGridArray[second].ToLower().Equals(Opponent) && GameGridArray[third].ToLower().Equals(Opponent);
        }

        private static void DrawGameGrid(string[] gameGridArray)
        {
            Console.Clear();
            Console.WriteLine("           |               |           ");
            Console.WriteLine("     {0}     |       {1}       |     {2}     ", gameGridArray[0], gameGridArray[1], gameGridArray[2]);
            Console.WriteLine("___________|_______________|___________");
            Console.WriteLine("           |               |           ");
            Console.WriteLine("     {0}     |       {1}       |     {2}     ", gameGridArray[3], gameGridArray[4], gameGridArray[5]);
            Console.WriteLine("___________|_______________|___________");
            Console.WriteLine("           |               |           ");
            Console.WriteLine("     {0}     |       {1}       |     {2}     ", gameGridArray[6], gameGridArray[7], gameGridArray[8]);
            Console.WriteLine("           |               |           ");
            Console.WriteLine("                                       ");
        }

        public static void EndGame()
        {
            Console.WriteLine("Ar nori žaisti dar kartą? taip arba ne");
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

        static void checkIfPlayerSymbolValid(String inputPlayerSymbol)
        {

            if (!inputPlayerSymbol.ToLower().Equals("x") && !inputPlayerSymbol.ToLower().Equals("o"))
            {
                Console.WriteLine("{0} - tokio simbolio nėra TicTacToe. Rinkis tarp x arba o", inputPlayerSymbol);
                inputPlayerSymbol = Console.ReadLine();
                checkIfPlayerSymbolValid(inputPlayerSymbol);
            }
        }

        private static void checkPlayerIndexBounds(int input)
        {
            if (!Enumerable.Range(0, 9).Contains(input))
            {
                Console.WriteLine("{0} - indeksas yra už lentos ribų arba netinkamas. Rinkis nuo 0 iki 8", input);
                input = Convert.ToInt32(Console.ReadLine());
                checkPlayerIndexBounds(input);
            }
        }

        private static int checkIfIndexIsNotOccupied(int input)
        {
            if (GameGridArray[input].ToLower().Equals("x") || GameGridArray[input].ToLower().Equals("o"))
            {
                Console.WriteLine("Laukelis {0} jau yra užimtas, rinkites kitą laisvą", input);
                input = Convert.ToInt32(Console.ReadLine());
                checkIfIndexIsNotOccupied(input);
            }
            return input;
        }

        private static void StartGame()
        {
            Console.Write("Spauskite bet kurį mygtuką, kad pradėtume...");
            Console.ReadKey();
            Grid();
        }

        static void Main(string[] args)
        {

            Console.WriteLine("--------TicTacToe--------");
            Console.Write("Kuo nori žaisti x ar o: ");
            string input = Console.ReadLine();

            checkIfPlayerSymbolValid(input);

            if (input.ToLower().Equals("x"))
            {
                Player = "x";
                Opponent = "o";
                StartGame();
            }
            else if (input.ToLower().Equals("o"))
            {
                Player = "o";
                Opponent = "x";
                StartGame();
            }

            Console.ReadLine();
        }
    }
}
