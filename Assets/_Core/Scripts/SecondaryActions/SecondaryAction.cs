using BhTest.Player;
using UnityEngine;

namespace BhTest.SecondaryActions
{
    public abstract class SecondaryAction : ScriptableObject
    {
        protected PlayerController _playerController;

        public virtual void Init(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public abstract void PerformAction();
    }
}
