using BhTest.Collision;
using BhTest.GameplyActions;
using BhTest.Movement;
using System.Collections;
using UnityEngine;

namespace BhTest.Player
{
    [CreateAssetMenu(menuName = "ScriptableObject/DashAction")]
    public class DashAction : GameplayAction
    {
        private MovementSystem _movement;
        private Coroutine _dashCoroutine;
        private ICollisionSource _collision;
        private PlayerFacade _playerFacade;

        [field: SerializeField] public float DashDistance { get; private set; }
        [field: SerializeField] public float DashDuration { get; private set; }

        public override void Init(PlayerController playerController)
        {
            base.Init(playerController);

            _playerFacade = playerController.GetComponent<PlayerFacade>();
            _movement = _playerFacade.Movement;
            _collision = playerController.GetComponent<ICollisionSource>();
        }

        public override void PerformAction()
        {
            if (!_movement.IsMoving || _dashCoroutine != null) return;

            StartDash();
            _dashCoroutine = _movement.StartCoroutine(DashCoroutine());
        }

        private IEnumerator DashCoroutine()
        {
            float startTime = Time.time;
            var startPos = _movement.transform.position;

            while (ShouldDash(startTime, startPos))
            {
                yield return null;
            }

            EndDash();
        }

        private void StartDash()
        {
            if (_movement == null) return;

            float targetSpeed = DashDistance / DashDuration;
            _movement.AddSpeedMultiplier(nameof(DashAction), targetSpeed / _movement.MoveSpeed);
            _playerController.Disable(nameof(DashAction));
            _playerFacade.Fx.IsLineEmitting = true;
            _movement.IsMoving = true;
            _collision.CollisionHit += OnCollisionHitHandler;
        }

        private void EndDash()
        {
            _collision.CollisionHit -= OnCollisionHitHandler;
            _movement.RemoveSpeedMultiplier(nameof(DashAction));
            _playerController.Enable(nameof(DashAction));
            _playerFacade.Fx.IsLineEmitting = false;
            _dashCoroutine = null;
        }

        private bool ShouldDash(float startTime, Vector3 startPos)
        {
            return Vector3.Distance(startPos, _movement.transform.position) < DashDistance
                    && (Time.time - startTime) < DashDuration;
        }

        private void OnCollisionHitHandler(GameObject other)
        {
            if (other.TryGetComponent(out IHitSource collision))
            {
                if (collision.OnHit())
                {
                    _playerFacade.AddPoint();
                }
            }
        }
    }
}
