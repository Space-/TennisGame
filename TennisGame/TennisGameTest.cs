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
    }

    public class GameScoreboard
    {
        public string GetGameResult(TennisPlayer player1, TennisPlayer player2)
        {
            return player1.Score == 0 && player1.Score == player2.Score ? "Love All" : "";
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