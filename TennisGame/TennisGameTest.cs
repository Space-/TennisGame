using System.Collections.Generic;
using System.Linq;
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

    public class GameScoreboard
    {
        public TennisPlayer GetHighestScorePlayer(List<TennisPlayer> players)
        {
            return players.Aggregate((scoreHighPlayer, scoreLowPlayer) => scoreHighPlayer.Score > scoreLowPlayer.Score ? scoreHighPlayer : scoreLowPlayer);
        }

        public TennisPlayer GetLowestScorePlayer(List<TennisPlayer> players)
        {
            return players.Aggregate((scoreLowPlayer, scoreHighPlayer) => scoreLowPlayer.Score < scoreHighPlayer.Score ? scoreLowPlayer : scoreHighPlayer);
        }

        //        public string GetGameResult(List<TennisPlayer> players)
        //        {
        //            var highestScorePlayer = GetHighestScorePlayer(players);
        //            var LowestScorePlayer = GetLowestScorePlayer(players);
        //            var gameResult = GetGameResult(highestScorePlayer, LowestScorePlayer);
        //
        //            return gameResult;
        //        }

        public string GetGameResult(List<TennisPlayer> players)
        {
            //            var highestScorePlayer = GetHighestScorePlayer(players);
            //            var lowestScorePlayer = GetLowestScorePlayer(players);
            var firstPlayer = players[0];
            var secondPlayer = players[1];
            if (IsTwoPlayerSameScore(firstPlayer, secondPlayer))
            {
                if (firstPlayer.Score == 0)
                {
                    return "Love All";
                }
            }
            else if (firstPlayer.Score > secondPlayer.Score)
            {
                var thisRoundScore = 0;

                if (firstPlayer.Score == 1 && secondPlayer.Score == 0)
                {
                    thisRoundScore = 15;
                }
                else if (firstPlayer.Score == 2 && secondPlayer.Score == 0)
                {
                    thisRoundScore = 30;
                }
                else if (firstPlayer.Score == 3 && secondPlayer.Score == 0)
                {
                    thisRoundScore = 40;
                }

                var resultStr = thisRoundScore + " Love";

                if (firstPlayer.Score == 4 && secondPlayer.Score == 0)
                {
                    resultStr = firstPlayer.Name + " Win";
                }

                return resultStr;
            }
            else if (firstPlayer.Score < secondPlayer.Score)
            {
            }

            return "";
        }

        private bool IsTwoPlayerSameScore(TennisPlayer highScorePlayer, TennisPlayer lowScorePlayer)
        {
            return highScorePlayer.Score == lowScorePlayer.Score;
        }
    }

    public class TennisPlayer
    {
        public int Score { get; set; }
        public string Name { get; set; }
    }
}