using System;
using System.Collections.Generic;
using System.Linq;
using TennisGame;

namespace TennisGameTest
{
    public class GameScoreBoard
    {
        public static int DeuceCnt;
        public bool IsGameEnd { get; set; }

        public GameScoreBoard()
        {
            InitGameScoreBoard();
        }

        public void InitGameScoreBoard()
        {
            DeuceCnt = 0;
            IsGameEnd = false;
        }

        public TennisPlayer GetHighestScorePlayer(List<TennisPlayer> players)
        {
            return players.Aggregate((scoreHighPlayer, scoreLowPlayer) => scoreHighPlayer.Score > scoreLowPlayer.Score ? scoreHighPlayer : scoreLowPlayer);
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

            if (IsTwoPlayerSameScore(firstPlayer, secondPlayer))
            {
                switch (firstPlayer.Score)
                {
                    case 0:
                        resultStr = "Love All";
                        break;

                    case 1:
                    case 2:
                        resultStr = GetGameResultStr(previousStr, laterStr);
                        break;

                    default:
                        resultStr = "Deuce";
                        break;
                }
            }
            else
            {
                var highestScorePlayer = GetHighestScorePlayer(players);
                var twoPlayerScoreDiffVal = Math.Abs(firstPlayer.Score - secondPlayer.Score);

                if (highestScorePlayer.Score >= lowestScoreToWinThisRound)
                {
                    GameScoreBoard.DeuceCnt++;
                    var deuceMsg = "Deuce" + GameScoreBoard.DeuceCnt;
                    previousStr = highestScorePlayer.Name;
                    laterStr = twoPlayerScoreDiffVal == 1 ? deuceMsg : "Win";
                }

                if (laterStr.Equals("Win"))
                {
                    IsGameEnd = true;
                }

                resultStr = GetGameResultStr(previousStr, laterStr);
            }

            return resultStr;
        }

        //        private static List<string> GetPlayerScoreVal(List<TennisPlayer> players, ScoreMappingDictionarySingleton scoreMapping)
        //        {
        //            var scoresVal = new List<string>();
        //            foreach (var tennisPlayer in players) 
        //            {
        //                var key = tennisPlayer.Score;
        //                var value = scoreMapping.GetValInDictionary(key);
        //                scoresVal.Add(value);
        //            }
        //
        //            return scoresVal;
        //        }
        //
        private static string GetGameResultStr(string previousStr, string laterStr)
        {
            return $"{previousStr} {laterStr}";
        }

        private static bool IsTwoPlayerSameScore(TennisPlayer firstPlayer, TennisPlayer secondPlayer)
        {
            return firstPlayer.Score == secondPlayer.Score;
        }
    }
}