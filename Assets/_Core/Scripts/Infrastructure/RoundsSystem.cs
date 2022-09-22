using BhTest.Utils;
using Mirror;
using System;
using UnityEngine;

namespace BhTest.Infrastructure
{
    public class RoundsSystem : NetworkBehaviour
    {
        public event Action GameRestart;
        public event Action GameStart;

        [field: SerializeField] public float RestartDelay { get; private set; }
        [field: SyncVar(hook = nameof(OnGameEnd))] public bool IsGameEnd { get; private set; }

        public void RestartGame()
        {
            if (IsGameEnd) return;
            IsGameEnd = true;
            this.DelayTask(RestartDelay, () => IsGameEnd = false);
        }

        private void OnGameEnd(bool old, bool current)
        {
            if (IsGameEnd)
            {
                GameRestart?.Invoke();
            }
            else
            {
                GameStart?.Invoke();
            }
        }
    }

}
