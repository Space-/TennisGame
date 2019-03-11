using System.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisGame
{
    [TestClass]
    public class TennisGameTest
    {
        [TestMethod]
        public void GetTennisResult_Player1_score_0_Player2_score_0_()
        {
            // arrange
            var player1 = new TennisPlayer(0);
            var player2 = new TennisPlayer(0);
            string expected = "Love All";

            // act

            // assert
        }
    }

    public class TennisPlayer
    {
        private int _score;

        public TennisPlayer(int score)
        {
            this._score = score;
        }
    }
}
