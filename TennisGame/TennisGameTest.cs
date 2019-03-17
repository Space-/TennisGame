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

    public class ScoreMappingDictionarySingleton
    {
        private static Dictionary<int, string> _scoreMapping;
        private static ScoreMappingDictionarySingleton _instance = null;

        private ScoreMappingDictionarySingleton()
        {
            _scoreMapping = _scoreMapping ?? GetRoundScoreMapping();
        }

        private static class ScoreMappingDictionarySingletonHolder
        {
            internal static ScoreMappingDictionarySingleton Instance = _instance ?? new ScoreMappingDictionarySingleton();

            static ScoreMappingDictionarySingletonHolder()
            {
            }
        }

        public static ScoreMappingDictionarySingleton Instance
        {
            get { return ScoreMappingDictionarySingletonHolder.Instance; }
        }

        private Dictionary<int, string> GetRoundScoreMapping()
        {
            var dictionary = new Dictionary<int, string>();
            int[] scores = { 0, 1, 2, 3 };
            string[] roundScoreResult = { "Love", "15", "30", "40" };

            for (var i = 0; i < scores.Length; i++)
            {
                dictionary.Add(scores[i], roundScoreResult[i]);
            }

            return dictionary;
        }

        // 查字典 // find specific value
        public string GetValInDictionary(int key)
        {
            string value;
            value = _scoreMapping.ContainsKey(key) ? _scoreMapping[key] : "Not Found";

            return value;
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
                ScoreMappingDictionarySingleton scoreMapping = ScoreMappingDictionarySingleton.Instance;
                string thisRoundScore = "0";

                var p1ScoreStr = scoreMapping.GetValInDictionary(firstPlayer.Score);
                var p2ScoreStr = scoreMapping.GetValInDictionary(secondPlayer.Score);

                var resultStr = $"{p1ScoreStr} {p2ScoreStr}";

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