using System;
using System.Collections.Generic;
using System.Linq;

namespace TennisGame
{
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
            var firstPlayer = players[0];
            var secondPlayer = players[1];
            var resultStr = "";
            var scoreMapping = ScoreMappingDictionarySingleton.Instance;
            var previousStr = scoreMapping.GetValInDictionary(firstPlayer.Score);
            var laterStr = scoreMapping.GetValInDictionary(secondPlayer.Score);
            var lowestScoreToWinThisRound = 4;

            if (IsTwoPlayerSameScore(firstPlayer, secondPlayer))
            {
                switch (firstPlayer.Score)
                {
                    case 0:
                        resultStr = "Love All";
                        break;

                    case 1:
                    case 2:
                        resultStr = $"{previousStr} {laterStr}";
                        break;

                    default:
                        resultStr = "Deuce";
                        break;
                }
            }
            else
            {
                var highestScorePlayer = GetHighestScorePlayer(players);
                var lowestScorePlayer = GetLowestScorePlayer(players);
                var twoPlayerScoreDiffVal = Math.Abs(highestScorePlayer.Score - lowestScorePlayer.Score);

                if (highestScorePlayer.Score >= lowestScoreToWinThisRound)
                {
                    previousStr = highestScorePlayer.Name;
                    laterStr = twoPlayerScoreDiffVal == 1 ? "Deuce1" : "Win";
                }

                resultStr = $"{previousStr} {laterStr}";
            }

            return resultStr;
        }

        private bool IsTwoPlayerSameScore(TennisPlayer highScorePlayer, TennisPlayer lowScorePlayer)
        {
            return highScorePlayer.Score == lowScorePlayer.Score;
        }
    }
}