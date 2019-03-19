using System;
using System.Collections.Generic;
using TennisGameTest;

namespace TennisGame
{
    internal class TennisGameMainProgram
    {
        private static void Main(string[] args)
        {
            var tennisPlayers = new List<TennisPlayer>() { new TennisPlayer(), new TennisPlayer() };
            var gameScoreboard = new GameScoreBoard();

            InputPlayersName(tennisPlayers);
            InputPlayersScore(tennisPlayers);

            while (true)
            {
                var currentGameSituation = gameScoreboard.GetGameResult(tennisPlayers);
                Console.WriteLine("★Current game situation:  {0}", currentGameSituation);

                if (!gameScoreboard.IsGameEnd)
                {
                    Console.Write("Which player gets next point? (1 or 2):");

                    ClearKeyBuffer();
                    var inputKey = Console.ReadKey().Key;
                    Console.WriteLine();

                    int indexOfGetPointPlayer;

                    if (inputKey == ConsoleKey.D1 || inputKey == ConsoleKey.NumPad1)
                    {
                        indexOfGetPointPlayer = 0;
                        tennisPlayers[indexOfGetPointPlayer].Score++;
                    }
                    else if (inputKey == ConsoleKey.D2 || inputKey == ConsoleKey.NumPad2)
                    {
                        indexOfGetPointPlayer = 1;
                        tennisPlayers[indexOfGetPointPlayer].Score++;
                    }
                    else
                    {
                        Console.WriteLine("You enter a wrong key, please try to enter 1 or 2 again!");
                    }
                }
                else
                {
                    break;
                }
                Console.WriteLine();
            }

            Console.WriteLine("===== Game End =====");
            Console.ReadKey();
        }

        public static void ClearKeyBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
        }

        private static void InputPlayersName(List<TennisPlayer> tennisPlayers)
        {
            for (int i = 0; i < tennisPlayers.Count; i++)
            {
                Console.Write("Input player{0}'s name:", i + 1);
                tennisPlayers[i].Name = Console.ReadLine();
            }
            Console.WriteLine("====================");
        }

        private static void InputPlayersScore(List<TennisPlayer> tennisPlayers)
        {
            for (int i = 0; i < tennisPlayers.Count; i++)
            {
                Console.Write("Input player{0}'s score:", i + 1);

                int number = 0;
                bool convertSuccessful = int.TryParse(Console.ReadLine(), out number);
                if (convertSuccessful)
                {
                    tennisPlayers[i].Score = number;
                }
                else
                {
                    Console.WriteLine("What your input is not integer, please try to enter a integer again!");
                    i--;
                }
            }
        }
    }
}