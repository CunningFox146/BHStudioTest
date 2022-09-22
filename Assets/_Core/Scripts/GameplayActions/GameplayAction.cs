using BhTest.Player;
using UnityEngine;

namespace BhTest.GameplyActions
{
    public abstract class GameplayAction : ScriptableObject
    {
        protected PlayerController _playerController;

        public virtual void Init(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public abstract void PerformAction();
    }
}
