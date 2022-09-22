using BhTest.GameplyActions;
using BhTest.Infrastructure;
using BhTest.Movement;
using Mirror;
using System.Collections.Generic;
using UnityEngine;

namespace BhTest.Player
{
    [RequireComponent(typeof(MovementSystem), typeof(NetworkTransform))]
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField] private GameplayAction _primaryAction;
        private MovementSystem _movement;
        private RoundsSystem _rounds;
        private List<string> _disableSources = new List<string>();

        public override void OnStartServer()
        {
            _movement = GetComponent<MovementSystem>();
            _primaryAction = Instantiate(_primaryAction);
            _primaryAction.Init(this);

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
        public void PrimaryAction() => CmdPrimaryAction();
        public void SetMovementDirection(Vector3 direction) => CmdSetMovementDirection(direction);
        public void SetIsMoving(bool isMoving) => CmdSetIsMoving(isMoving);

        private void UpdateIsDisabled()
        {
            enabled = _disableSources.Count == 0;
        }

        [Command]
        private void CmdPrimaryAction()
        {
            if (!enabled) return;
            _primaryAction?.PerformAction();
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