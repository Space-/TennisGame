using System;
using System.Collections.Generic;
using System.Linq;
using TennisGame;

namespace TennisGameTest
{
    public class GameScoreBoard
    {
        private TennisPlayer _firstPlayer;
        private TennisPlayer _secondPlayer;
        public static int DeuceCnt;
        public bool IsGameEnd { get; set; }

        public GameScoreBoard(TennisPlayer firstPlayer, TennisPlayer secondPlayer)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
            InitGameScoreBoard();
        }

        public void InitGameScoreBoard()
        {
            DeuceCnt = 0;
            IsGameEnd = false;
        }

        public TennisPlayer GetHighestScorePlayer()
        {
            var players = new List<TennisPlayer>() { _firstPlayer, _secondPlayer };
            return players.Aggregate((scoreHighPlayer, scoreLowPlayer) => scoreHighPlayer.Score > scoreLowPlayer.Score ? scoreHighPlayer : scoreLowPlayer);
        }

        public string GetGameResult()
        {
            var resultStr = "";
            var scoreMapping = ScoreMappingDictionarySingleton.Instance;
            var previousStr = scoreMapping.GetValInDictionary(_firstPlayer.Score);
            var laterStr = scoreMapping.GetValInDictionary(_secondPlayer.Score);
            const int lowestScoreToWinThisRound = 4;

            if (IsTwoPlayerSameScore(_firstPlayer, _secondPlayer))
            {
                switch (_firstPlayer.Score)
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
                var highestScorePlayer = GetHighestScorePlayer();
                var twoPlayerScoreDiffVal = Math.Abs(_firstPlayer.Score - _secondPlayer.Score);
                const string winnerMsg = "Win";

                if (highestScorePlayer.Score >= lowestScoreToWinThisRound)
                {
                    var deuceMsg = GetDeuceMsg();

                    previousStr = highestScorePlayer.Name;
                    laterStr = twoPlayerScoreDiffVal == 1 ? deuceMsg : winnerMsg;
                }

                if (laterStr.Equals(winnerMsg))
                {
                    IsGameEnd = true;
                }

                resultStr = GetGameResultStr(previousStr, laterStr);
            }

            return resultStr;
        }

        private static string GetDeuceMsg()
        {
            GameScoreBoard.DeuceCnt++;
            var deuceMsg = "Deuce" + GameScoreBoard.DeuceCnt;
            return deuceMsg;
        }

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