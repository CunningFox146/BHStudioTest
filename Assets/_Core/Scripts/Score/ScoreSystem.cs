using System;
using System.Collections.Generic;
using UnityEngine;

namespace BhTest.Score
{
    public class ScoreSystem : MonoBehaviour
    {
        public event Action ScoreChanged;
        private Dictionary<uint, int> _scores = new Dictionary<uint, int>();

        [field: SerializeField] public int WinScore { get; private set; }

        public void AddScore(uint id, int score)
        {
            if (!_scores.ContainsKey(id))
            {
                _scores[id] = 0;
            }
            _scores[id] += score;

            ScoreChanged?.Invoke();

            if (_scores[id] >= WinScore)
            {
                Debug.Log($"{id} won");
            }
        }

        public int GetScore(uint id)
        {
            if (_scores.TryGetValue(id, out int score))
            {
                return score;
            }
            return 0;
        }
    }
}
