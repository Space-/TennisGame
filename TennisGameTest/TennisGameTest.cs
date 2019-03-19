using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisGame;

namespace TennisGameTest
{
    [TestClass]
    public class TennisGameTest
    {
        [TestMethod]
        public void GetTennisResult_Player1_score_0_Player2_score_0()
        {
            var firstPlayer = new TennisPlayer() { Score = 0 };
            var secondPlayer = new TennisPlayer() { Score = 0 };

            GameResultShouldBe("Love All", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_1_Player_score_0()
        {
            var firstPlayer = new TennisPlayer() { Score = 1 };
            var secondPlayer = new TennisPlayer() { Score = 0 };

            GameResultShouldBe("15 Love", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_0_Player2_score_1()
        {
            var firstPlayer = new TennisPlayer() { Score = 0 };
            var secondPlayer = new TennisPlayer() { Score = 1 };

            GameResultShouldBe("Love 15", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_2_Player_score_0()
        {
            var firstPlayer = new TennisPlayer() { Score = 2 };
            var secondPlayer = new TennisPlayer() { Score = 0 };

            GameResultShouldBe("30 Love", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_0_Player_score_2()
        {
            var firstPlayer = new TennisPlayer() { Score = 0 };
            var secondPlayer = new TennisPlayer() { Score = 2 };

            GameResultShouldBe("Love 30", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_3_Player_score_0()
        {
            var firstPlayer = new TennisPlayer() { Score = 3 };
            var secondPlayer = new TennisPlayer() { Score = 0 };

            GameResultShouldBe("40 Love", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_0_Player_score_3()
        {
            var firstPlayer = new TennisPlayer() { Score = 0 };
            var secondPlayer = new TennisPlayer() { Score = 3 };

            GameResultShouldBe("Love 40", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player_score_0_Result_Player1_Win()
        {
            var firstPlayer = new TennisPlayer() { Score = 4, Name = "Player1" };
            var secondPlayer = new TennisPlayer() { Score = 0, Name = "Player2" };

            GameResultShouldBe("Player1 Win", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_0_Player_score_4_Result_Player2_Win()
        {
            var firstPlayer = new TennisPlayer() { Score = 0, Name = "Player1" };
            var secondPlayer = new TennisPlayer() { Score = 4, Name = "Player2" };

            GameResultShouldBe("Player2 Win", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player_score_1_Result_Player1_Win()
        {
            var firstPlayer = new TennisPlayer() { Score = 4, Name = "Player1" };
            var secondPlayer = new TennisPlayer() { Score = 1, Name = "Player2" };

            GameResultShouldBe("Player1 Win", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_1_Player_score_4_Result_Player2_Win()
        {
            var firstPlayer = new TennisPlayer() { Score = 1, Name = "Player1" };
            var secondPlayer = new TennisPlayer() { Score = 4, Name = "Player2" };

            GameResultShouldBe("Player2 Win", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player_score_2_Result_Player1_Win()
        {
            var firstPlayer = new TennisPlayer() { Score = 4, Name = "Player1" };
            var secondPlayer = new TennisPlayer() { Score = 2, Name = "Player2" };

            GameResultShouldBe("Player1 Win", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_2_Player_score_4_Result_Player2_Win()
        {
            var firstPlayer = new TennisPlayer() { Score = 2, Name = "Player1" };
            var secondPlayer = new TennisPlayer() { Score = 4, Name = "Player2" };

            GameResultShouldBe("Player2 Win", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player_score_3_Result_Player1_Deuce1()
        {
            var firstPlayer = new TennisPlayer() { Score = 4, Name = "Player1" };
            var secondPlayer = new TennisPlayer() { Score = 3, Name = "Player2" };

            GameResultShouldBe("Player1 Deuce1", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player_score_5_Result_Player2_Deuce2()
        {
            // Deuce1
            var firstPlayer = new TennisPlayer() { Score = 4, Name = "Player1" };
            var secondPlayer = new TennisPlayer() { Score = 3, Name = "Player2" };

            var gameScoreboard = new GameScoreBoard(firstPlayer, secondPlayer);

            var gameResult = gameScoreboard.GetGameResult();

            // Deuce2
            secondPlayer.Score = secondPlayer.Score + 2;

            gameResult = gameScoreboard.GetGameResult();

            // assert
            Assert.AreEqual("Player2 Deuce2", gameResult);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_5_Player_score_4_Result_Player1_Deuce2()
        {
            // Deuce1
            var firstPlayer = new TennisPlayer() { Score = 3, Name = "Player1" };
            var secondPlayer = new TennisPlayer() { Score = 4, Name = "Player2" };

            var gameScoreboard = new GameScoreBoard(firstPlayer, secondPlayer);

            var gameResult = gameScoreboard.GetGameResult();

            // Deuce2
            firstPlayer.Score = firstPlayer.Score + 2;

            gameResult = gameScoreboard.GetGameResult();

            // assert
            Assert.AreEqual("Player1 Deuce2", gameResult);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player_score_6_Result_Player2_Win()
        {
            var firstPlayer = new TennisPlayer() { Score = 4, Name = "Player1" };
            var secondPlayer = new TennisPlayer() { Score = 6, Name = "Player2" };

            GameResultShouldBe("Player2 Win", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_1_Player2_score_1()
        {
            var firstPlayer = new TennisPlayer() { Score = 1, Name = "Player1" };
            var secondPlayer = new TennisPlayer() { Score = 1, Name = "Player2" };

            GameResultShouldBe("15 15", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_2_Player2_score_2()
        {
            var firstPlayer = new TennisPlayer() { Score = 2 };
            var secondPlayer = new TennisPlayer() { Score = 2 };

            GameResultShouldBe("30 30", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_3_Player2_score_3_Result_Deuce()
        {
            var firstPlayer = new TennisPlayer() { Score = 3 };
            var secondPlayer = new TennisPlayer() { Score = 3 };

            GameResultShouldBe("Deuce", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player2_score_4_Result_Deuce()
        {
            var firstPlayer = new TennisPlayer() { Score = 4 };
            var secondPlayer = new TennisPlayer() { Score = 4 };

            GameResultShouldBe("Deuce", firstPlayer, secondPlayer);
        }

        [TestMethod]
        public void GetHighestScore_Player1_score_2_Player_score_0()
        {
            var firstPlayer = new TennisPlayer() { Score = 2 };
            var secondPlayer = new TennisPlayer() { Score = 0 };

            var gameScoreboard = new GameScoreBoard(firstPlayer, secondPlayer);
            var highestScorePlayer = gameScoreboard.GetHighestScorePlayer();

            Assert.AreEqual(2, highestScorePlayer.Score);
        }

        private static void GameResultShouldBe(string expected, TennisPlayer firstPlayer, TennisPlayer secondPlayer)
        {
            var gameScoreboard = new GameScoreBoard(firstPlayer, secondPlayer);

            // act
            var gameResult = gameScoreboard.GetGameResult();

            // assert
            Assert.AreEqual(expected, gameResult);
        }
    }
}