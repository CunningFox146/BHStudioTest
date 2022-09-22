using BhTest.Player;
using BhTest.Utils;
using System;
using UnityEngine;

namespace BhTest.Collision
{
    public class PlayerCollision : MonoBehaviour, ICollisionSource, IHitSource
    {
        public event Action<GameObject> CollisionHit;
        public event Action GotHit;

        [SerializeField] private float _hitCd;
        [SerializeField] PlayerColor _color;
        [SerializeField] Color _hitColor;

        private Coroutine _hitCdCoroutine;

        public bool IsOnCd => _hitCdCoroutine != null;

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            CollisionHit?.Invoke(hit.gameObject);
        }

        public bool OnHit()
        {
            if (IsOnCd) return false;
            GotHit?.Invoke();

            var startColor = _color.MeshColor;
            _color.MeshColor = _hitColor;
            _hitCdCoroutine = this.DelayTask(_hitCd, () => OnHitCd(startColor));

            return true;
        }

        private void OnHitCd(Color startColor)
        {
            _color.MeshColor = startColor;
            _hitCdCoroutine = null;
        }
    }
}
