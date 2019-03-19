using System.Collections.Generic;

namespace TennisGameTest
{
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
            var dictionary = new Dictionary<int, string>()
            {
                {0, "Love"},
                {1, "15"},
                {2, "30"},
                {3, "40"}
            };

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
}