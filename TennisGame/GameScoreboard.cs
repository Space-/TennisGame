using System;
using System.Collections.Generic;
using System.Linq;

namespace TennisGame
{
    public class GameScoreboard
    {
        public static int DeuceCnt;

        public GameScoreboard()
        {
            InitGameScoreBoard();
        }

        public void InitGameScoreBoard()
        {
            DeuceCnt = 0;
        }

        public TennisPlayer GetHighestScorePlayer(List<TennisPlayer> players)
        {
            return players.Aggregate((scoreHighPlayer, scoreLowPlayer) => scoreHighPlayer.Score > scoreLowPlayer.Score ? scoreHighPlayer : scoreLowPlayer);
        }

        public TennisPlayer GetLowestScorePlayer(List<TennisPlayer> players)
        {
            return players.Aggregate((scoreLowPlayer, scoreHighPlayer) => scoreLowPlayer.Score < scoreHighPlayer.Score ? scoreLowPlayer : scoreHighPlayer);
        }

        public string GetGameResult(List<TennisPlayer> players)
        {
            var firstPlayer = players[0];
            var secondPlayer = players[1];
            var resultStr = "";
            var scoreMapping = ScoreMappingDictionarySingleton.Instance;
            var previousStr = scoreMapping.GetValInDictionary(firstPlayer.Score);
            var laterStr = scoreMapping.GetValInDictionary(secondPlayer.Score);
            const int lowestScoreToWinThisRound = 4;

            var highestScorePlayer = GetHighestScorePlayer(players);
            var lowestScorePlayer = GetLowestScorePlayer(players);
            var twoPlayerScoreDiffVal = Math.Abs(highestScorePlayer.Score - lowestScorePlayer.Score);

            switch (twoPlayerScoreDiffVal)
            {
                case 0 when highestScorePlayer.Score == 0:
                    resultStr = "Love All";
                    break;

                case 0 when highestScorePlayer.Score < lowestScoreToWinThisRound - 1:
                case 1 when highestScorePlayer.Score < 4:
                case 2 when highestScorePlayer.Score < 4:
                case 3 when highestScorePlayer.Score < 4:
                    {
                        var scoresVal = GetPlayerScoreVal(players, scoreMapping);
                        resultStr = GetGameResultStr(scoresVal[0], scoresVal[1]);
                        break;
                    }
                case 0 when highestScorePlayer.Score >= 3:
                    resultStr = "Deuce";
                    break;

                default:
                    {
                        GameScoreboard.DeuceCnt++;
                        var deuceMsg = "Deuce" + GameScoreboard.DeuceCnt;
                        previousStr = highestScorePlayer.Name;
                        laterStr = twoPlayerScoreDiffVal == 1 ? deuceMsg : "Win";

                        resultStr = GetGameResultStr(previousStr, laterStr);
                        break;
                    }
            }
            return resultStr;
        }

        private static List<string> GetPlayerScoreVal(List<TennisPlayer> players, ScoreMappingDictionarySingleton scoreMapping)
        {
            var scoresVal = new List<string>();
            foreach (var tennisPlayer in players)
            {
                var key = tennisPlayer.Score;
                var value = scoreMapping.GetValInDictionary(key);
                scoresVal.Add(value);
            }

            return scoresVal;
        }

        private static string GetGameResultStr(string previousStr, string laterStr)
        {
            return $"{previousStr} {laterStr}";
        }

        //        private static bool IsTwoPlayerSameScore(TennisPlayer highScorePlayer, TennisPlayer lowScorePlayer)
        //        {
        //            return highScorePlayer.Score == lowScorePlayer.Score;
        //        }
    }
}