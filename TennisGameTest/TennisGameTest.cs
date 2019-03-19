using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisGame;

namespace TennisGameTest
{
    [TestClass]
    public class TennisGameTest
    {
        private TennisPlayer _firstPlayer = new TennisPlayer();
        private TennisPlayer _secondPlayer = new TennisPlayer();

        [TestMethod]
        public void GetTennisResult_Player1_score_0_Player2_score_0()
        {
            AddTwoPlayers(0, 0);
            GameResultShouldBe("Love All", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_1_Player_score_0()
        {
            AddTwoPlayers(1, 0);
            GameResultShouldBe("15 Love", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_0_Player2_score_1()
        {
            AddTwoPlayers(0, 1);
            GameResultShouldBe("Love 15", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_2_Player_score_0()
        {
            AddTwoPlayers(2, 0);
            GameResultShouldBe("30 Love", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_0_Player_score_2()
        {
            AddTwoPlayers(0, 2);
            GameResultShouldBe("Love 30", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_3_Player_score_0()
        {
            AddTwoPlayers(3, 0);
            GameResultShouldBe("40 Love", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_0_Player_score_3()
        {
            AddTwoPlayers(0, 3);
            GameResultShouldBe("Love 40", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player_score_0_Result_Player1_Win()
        {
            AddTwoPlayers(4, 0, "Player1", "Player2");
            GameResultShouldBe("Player1 Win", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_0_Player_score_4_Result_Player2_Win()
        {
            AddTwoPlayers(0, 4, "Player1", "Player2");
            GameResultShouldBe("Player2 Win", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player_score_1_Result_Player1_Win()
        {
            AddTwoPlayers(4, 1, "Player1", "Player2");
            GameResultShouldBe("Player1 Win", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_1_Player_score_4_Result_Player2_Win()
        {
            AddTwoPlayers(1, 4, "Player1", "Player2");
            GameResultShouldBe("Player2 Win", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player_score_2_Result_Player1_Win()
        {
            AddTwoPlayers(4, 2, "Player1", "Player2");
            GameResultShouldBe("Player1 Win", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_2_Player_score_4_Result_Player2_Win()
        {
            AddTwoPlayers(2, 4, "Player1", "Player2");
            GameResultShouldBe("Player2 Win", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player_score_3_Result_Player1_Deuce1()
        {
            AddTwoPlayers(4, 3, "Player1", "Player2");
            GameResultShouldBe("Player1 Deuce1", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player_score_5_Result_Player2_Deuce2()
        {
            AddTwoPlayers(4, 3, "Player1", "Player2");

            var gameScoreboard = new GameScoreBoard(_firstPlayer, _secondPlayer);

            // Deuce1
            var gameResult = gameScoreboard.GetGameResult();

            _secondPlayer.Score = _secondPlayer.Score + 2;

            // Deuce2
            gameResult = gameScoreboard.GetGameResult();

            // assert
            Assert.AreEqual("Player2 Deuce2", gameResult);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_5_Player_score_4_Result_Player1_Deuce2()
        {
            AddTwoPlayers(3, 4, "Player1", "Player2");

            var gameScoreboard = new GameScoreBoard(_firstPlayer, _secondPlayer);

            // Deuce1
            var gameResult = gameScoreboard.GetGameResult();

            _firstPlayer.Score = _firstPlayer.Score + 2;

            // Deuce2
            gameResult = gameScoreboard.GetGameResult();

            // assert
            Assert.AreEqual("Player1 Deuce2", gameResult);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player_score_6_Result_Player2_Win()
        {
            AddTwoPlayers(4, 6, "Player1", "Player2");
            GameResultShouldBe("Player2 Win", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_1_Player2_score_1()
        {
            AddTwoPlayers(1, 1, "Player1", "Player2");
            GameResultShouldBe("15 15", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_2_Player2_score_2()
        {
            AddTwoPlayers(2, 2, "Player1", "Player2");
            GameResultShouldBe("30 30", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_3_Player2_score_3_Result_Deuce()
        {
            AddTwoPlayers(3, 3, "Player1", "Player2");
            GameResultShouldBe("Deuce", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_4_Player2_score_4_Result_Deuce()
        {
            AddTwoPlayers(4, 4, "Player1", "Player2");
            GameResultShouldBe("Deuce", _firstPlayer, _secondPlayer);
        }

        [TestMethod]
        public void GetHighestScore_Player1_score_2_Player_score_0()
        {
            AddTwoPlayers(2, 0, "Player1", "Player2");

            var gameScoreboard = new GameScoreBoard(_firstPlayer, _secondPlayer);
            var highestScorePlayer = gameScoreboard.GetHighestScorePlayer();

            Assert.AreEqual(2, highestScorePlayer.Score);
        }

        private static void GameResultShouldBe(string expected, TennisPlayer _firstPlayer, TennisPlayer _secondPlayer)
        {
            var gameScoreboard = new GameScoreBoard(_firstPlayer, _secondPlayer);

            // act
            var gameResult = gameScoreboard.GetGameResult();

            // assert
            Assert.AreEqual(expected, gameResult);
        }

        private void AddTwoPlayers(int player1Score, int player2Score, string player1Name = "", string player2Name = "")
        {
            _firstPlayer = new TennisPlayer() { Score = player1Score, Name = player1Name };
            _secondPlayer = new TennisPlayer() { Score = player2Score, Name = player2Name };
        }
    }
}