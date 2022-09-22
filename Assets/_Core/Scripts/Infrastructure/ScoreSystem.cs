using BhTest.Player;
using Mirror;
using System;
using UnityEngine;

namespace BhTest.Infrastructure
{
    public class ScoreSystem : NetworkBehaviour
    {
        public event Action ScoresChanged;

        private readonly SyncDictionary<uint, int> Scores = new SyncDictionary<uint, int>();
        private RoundsSystem _rounds;

        [field: SerializeField] public int WinScore { get; private set; }
        [field: SyncVar] public string Winner { get; private set; }

        public override void OnStartServer()
        {
            _rounds = SystemsFacade.Instance.Rounds;
            RegisterServerEventhandlers();
        }

        public override void OnStartClient()
        {
            RegisterClientEventHandlers();
        }

        public override void OnStopClient()
        {
            UnregisterClientEventHandlers();
        }
        public override void OnStopServer()
        {
            UnregisterServerEventHandlers();
        }

        public void AddScore(PlayerFacade player, int score)
        {
            uint id = player.netId;

            if (!Scores.ContainsKey(id))
            {
                Scores[id] = 0;
            }
            Scores[id] += score;

            if (Scores[id] >= WinScore)
            {
                Winner = player.PlayerName;
                _rounds.RestartGame();
            }
        }

        public int GetScore(uint id)
        {
            if (Scores.TryGetValue(id, out int score))
            {
                return score;
            }
            return 0;
        }

        private void OnScoresChanged(SyncIDictionary<uint, int>.Operation op, uint key, int item)
        {
            ScoresChanged?.Invoke();
        }

        private void OnGameStarthandler()
        {
            Scores.Clear();
        }
        private void RegisterClientEventHandlers()
        {
            Scores.Callback += OnScoresChanged;
        }
        private void RegisterServerEventhandlers()
        {
            _rounds.GameStart += OnGameStarthandler;
        }

        private void UnregisterClientEventHandlers()
        {
            Scores.Callback -= OnScoresChanged;
        }

        private void UnregisterServerEventHandlers()
        {
            _rounds.GameStart -= OnGameStarthandler;
        }
    }
}
