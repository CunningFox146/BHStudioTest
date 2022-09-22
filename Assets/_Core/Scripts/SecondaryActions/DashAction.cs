using BhTest.Collision;
using BhTest.Movement;
using BhTest.SecondaryActions;
using System.Collections;
using UnityEngine;

namespace BhTest.Player
{
    [CreateAssetMenu(menuName = "ScriptableObject/DashAction")]
    public class DashAction : SecondaryAction
    {
        private MovementSystem _movement;
        private Coroutine _dashCoroutine;
        private ICollisionSource _collision;
        private PlayerFacade _playerSystem;

        [field: SerializeField] public float DashDistance { get; private set; }
        [field: SerializeField] public float DashDuration { get; private set; }

        public override void Init(PlayerController playerController)
        {
            base.Init(playerController);

            _movement = playerController.GetComponent<MovementSystem>();
            _collision = playerController.GetComponent<ICollisionSource>();
            _playerSystem = playerController.GetComponent<PlayerFacade>();
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
            float targetSpeed = DashDistance / DashDuration;
            _movement.AddSpeedMultiplier(nameof(DashAction), targetSpeed / _movement.MoveSpeed);
            _playerController.enabled = false;
            _movement.IsMoving = true;
            _collision.CollisionHit += OnCollisionHitHandler;
        }

        private void EndDash()
        {
            _collision.CollisionHit -= OnCollisionHitHandler;
            _movement.RemoveSpeedMultiplier(nameof(DashAction));
            _playerController.enabled = true;
            _dashCoroutine = null;
        }

        private bool ShouldDash(float startTime, Vector3 startPos)
        {
            return Vector3.Distance(startPos, _movement.transform.position) < DashDistance
                    && (Time.time - startTime) < DashDuration;
        }

        private void OnCollisionHitHandler(GameObject other)
        {
            if (other.TryGetComponent(out PlayerCollision collision) && !collision.IsOnCd)
            {
                collision.OnHit();
                _playerSystem.AddPoint();
            }
        }
    }
}
