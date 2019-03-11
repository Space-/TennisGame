using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisGame
{
    [TestClass]
    public class TennisGameTest
    {
        [TestMethod]
        public void GetTennisResult_Player1_score_0_Player2_score_0()
        {
            // arrange
            var player1 = new TennisPlayer(0);
            var player2 = new TennisPlayer(0);
            var scoreboard = new GameScoreboard();
            const string expected = "Love All";

            // act
            var gameResult = scoreboard.GetGameResult(player1, player2);

            // assert
            Assert.AreEqual(expected, gameResult);
        }

        [TestMethod]
        public void GetTennisResult_Player1_score_1_Player_score_0()
        {
            var player1 = new TennisPlayer(1);
            var player2 = new TennisPlayer(0);
            var scoreboard = new GameScoreboard();
            const string expected = "15 Love";

            var gameResult = scoreboard.GetGameResult(player1, player2);

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

        //        public TennisPlayer() { }

        public TennisPlayer(int score)
        {
            this.Score = score;
        }
    }
}