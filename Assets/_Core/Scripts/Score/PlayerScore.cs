using BhTest.Infrastructure;
using Mirror;
using System;
using UnityEngine;

namespace BhTest.Score
{
    public class PlayerScore : NetworkBehaviour
    {
        public event Action<int> ScoreChanged;

        private ScoreSystem _scoreSystem;
        [field: SyncVar(hook = nameof(OnScoreChanged))] public int Score { get; private set; }

        public override void OnStartServer()
        {
            _scoreSystem = SystemsFacade.Instance.Score;
            RegisterEventHandlers();
            UpdateScore();
        }

        public override void OnStopServer()
        {
            UnregisterEventHandlers();
        }

        private void RegisterEventHandlers()
        {
            if (_scoreSystem != null)
            {
                _scoreSystem.ScoreChanged += UpdateScore;
            }
        }

        private void UnregisterEventHandlers()
        {
            if (_scoreSystem != null)
            {
                _scoreSystem.ScoreChanged -= UpdateScore;
            }
        }

        private void UpdateScore()
        {
            Score = _scoreSystem.GetScore(netId);
        }

        [Client]
        private void OnScoreChanged(int old, int current)
        {
            Debug.Log($"OnScoreChanged {current}");
            ScoreChanged?.Invoke(current);
        }
    }
}
