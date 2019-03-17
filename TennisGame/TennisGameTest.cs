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
                new TennisPlayer(){Score = 0},
                new TennisPlayer(){Score = 0}
            };

            GameResultShouldBe("Love All", players);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_1_Player_score_0()
        {
            var players = new List<TennisPlayer>()
            {
                new TennisPlayer(){Score = 1},
                new TennisPlayer(){Score = 0}
            };

            GameResultShouldBe("15 Love", players);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_2_Player_score_0()
        {
            var players = new List<TennisPlayer>()
            {
                new TennisPlayer(){Score = 2},
                new TennisPlayer(){Score = 0}
            };

            GameResultShouldBe("30 Love", players);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_3_Player_score_0()
        {
            var players = new List<TennisPlayer>()
            {
                new TennisPlayer(){Score = 3},
                new TennisPlayer(){Score = 0}
            };

            GameResultShouldBe("40 Love", players);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player_score_0_Result_Player1_win()
        {
            var players = new List<TennisPlayer>()
            {
                new TennisPlayer(){Score = 4, Name = "Player1"},
                new TennisPlayer(){Score = 0, Name = "Player2"}
            };

            GameResultShouldBe("Player1 Win", players);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player_score_3_Result_Player1_Deuce1()
        {
            var players = new List<TennisPlayer>()
            {
                new TennisPlayer(){Score = 4, Name = "Player1"},
                new TennisPlayer(){Score = 3, Name = "Player2"}
            };

            GameResultShouldBe("Player1 Deuce1", players);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_1_Player2_score_1()
        {
            var players = new List<TennisPlayer>()
            {
                new TennisPlayer(){Score = 1},
                new TennisPlayer(){Score = 1}
            };

            GameResultShouldBe("15 15", players);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_2_Player2_score_2()
        {
            var players = new List<TennisPlayer>()
            {
                new TennisPlayer(){Score = 2},
                new TennisPlayer(){Score = 2}
            };

            GameResultShouldBe("30 30", players);
        }

        [TestMethod]
        public void GetHighestScore_Player1_score_2_Player_score_0()
        {
            var players = new List<TennisPlayer>()
            {
                new TennisPlayer(){Score = 2},
                new TennisPlayer(){Score = 0}
            };

            var gameScoreboard = new GameScoreboard();
            var highestScorePlayer = gameScoreboard.GetHighestScorePlayer(players);

            Assert.AreEqual(2, highestScorePlayer.Score);
        }

        [TestMethod]
        public void GetLowestScore_Player1_score_2_Player_score_0()
        {
            var players = new List<TennisPlayer>()
            {
                new TennisPlayer(){Score = 2},
                new TennisPlayer(){Score = 0}
            };

            var gameScoreboard = new GameScoreboard();
            var lowestScorePlayer = gameScoreboard.GetLowestScorePlayer(players);

            Assert.AreEqual(0, lowestScorePlayer.Score);
        }

        private static void GameResultShouldBe(string expected, List<TennisPlayer> players)
        {
            var gameScoreboard = new GameScoreboard();

            // act
            var gameResult = gameScoreboard.GetGameResult(players);

            // assert
            Assert.AreEqual(expected, gameResult);
        }
    }
}