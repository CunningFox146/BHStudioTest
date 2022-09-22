using BhTest.Infrastructure;
using BhTest.Movement;
using BhTest.SecondaryActions;
using Mirror;
using System.Collections.Generic;
using UnityEngine;

namespace BhTest.Player
{
    [RequireComponent(typeof(MovementSystem), typeof(NetworkTransform))]
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField] private SecondaryAction _secondaryAction;
        private MovementSystem _movement;
        private RoundsSystem _rounds;
        private List<string> _disableSources = new List<string>();

        public override void OnStartServer()
        {
            _movement = GetComponent<MovementSystem>();
            _secondaryAction = Instantiate(_secondaryAction);
            _secondaryAction.Init(this);

            _rounds = SystemsFacade.Instance.Rounds;
            _rounds.GameStart += () => Enable(nameof(RoundsSystem));
            _rounds.GameRestart += () => Disable(nameof(RoundsSystem));
        }

        public void Disable(string source)
        {
            _disableSources.Add(source);
            UpdateIsDisabled();
        }

        public void Enable(string source)
        {
            _disableSources.Remove(source);
            UpdateIsDisabled();
        }

        public void SetViewDirection(Vector3 direction) => CmdSetViewDirection(direction);
        public void SecondaryAction() => CmdSecondaryAction();
        public void SetMovementDirection(Vector3 direction) => CmdSetMovementDirection(direction);
        public void SetIsMoving(bool isMoving) => CmdSetIsMoving(isMoving);

        private void UpdateIsDisabled()
        {
            enabled = _disableSources.Count == 0;
        }

        [Command]
        private void CmdSecondaryAction()
        {
            if (!enabled) return;
            _secondaryAction?.PerformAction();
        }

        [Command]
        private void CmdSetMovementDirection(Vector3 direction)
        {
            if (!enabled) return;
            _movement.MovementDirection = direction.normalized;
        }

        [Command]
        private void CmdSetIsMoving(bool isMoving)
        {
            if (!enabled) return;
            _movement.IsMoving = isMoving;
        }

        [Command]
        private void CmdSetViewDirection(Vector3 direction)
        {
            if (!enabled) return;
            transform.forward = direction;
        }
    }
}