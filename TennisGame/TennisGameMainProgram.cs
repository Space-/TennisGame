using System;
using System.Collections.Generic;

namespace TennisGame
{
    class TennisGameMainProgram
    {
        static void Main(string[] args)
        {
            var tennisPlayers = new List<TennisPlayer>(){new TennisPlayer(), new TennisPlayer()};
            var gameScoreboard = new GameScoreBoard();

            InputPlayersName(tennisPlayers);

            while (!gameScoreboard.IsGameEnd)
            {
                InputPlayersScore(tennisPlayers);
                var currentGameSituation = gameScoreboard.GetGameResult(tennisPlayers);
                Console.WriteLine("★Current game situation:  {0}",currentGameSituation);
            }

            Console.WriteLine("===== Game End =====");
            Console.ReadKey();
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
                tennisPlayers[i].Score = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
