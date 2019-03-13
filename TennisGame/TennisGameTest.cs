using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisGame
{
    [TestClass]
    public class TennisGameTest
    {
        [TestMethod]
        public void GetTennisResult_Player1_score_0_Player2_score_0()
        {
            var players = new List<TennisPlayer>()
            {
                new TennisPlayer(0),
                new TennisPlayer(0)
            };

            GameResultShouldBe("Love All", players);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_1_Player_score_0()
        {
            var players = new List<TennisPlayer>()
            {
                new TennisPlayer(1),
                new TennisPlayer(0)
            };

            GameResultShouldBe("15 Love", players);
        }

        private static void GameResultShouldBe(string expected, List<TennisPlayer> players)
        {
            var scoreboard = new GameScoreboard();

            // act
            var gameResult = scoreboard.GetGameResult(players[0], players[1]);

            // assert
            Assert.AreEqual(expected, gameResult);
        }
    }

    public class GameScoreboard
    {
        public string GetGameResult(TennisPlayer player1, TennisPlayer player2)
        {
            if (player1.Score == 0 && player1.Score == player2.Score)
            {
                return "Love All";
            }
            else if (player1.Score == 1 && player2.Score == 0)
            {
                return "15 Love";
            }
            else
            {
                return "";
            }
        }
    }

    public class TennisPlayer
    {
        public int Score { get; }

        public TennisPlayer(int score)
        {
            this.Score = score;
        }
    }
}