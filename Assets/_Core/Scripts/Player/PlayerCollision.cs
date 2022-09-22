using BhTest.Collision;
using System;
using System.Collections;
using UnityEngine;

namespace BhTest.Player
{
    public class PlayerCollision : MonoBehaviour, ICollisionSource, IHitSource
    {
        public event Action<GameObject> CollisionHit;
        public event Action GotHit;

        [SerializeField] private float _hitCd;
        [SerializeField] PlayerColor _color;
        [SerializeField] Color _hitColor;

        private Coroutine _hitCdCoroutine;
        private WaitForSeconds _hitCdWait;

        public bool IsOnCd => _hitCdCoroutine != null;

        private void Awake()
        {
            _hitCdWait = new WaitForSeconds(_hitCd);
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            CollisionHit?.Invoke(hit.gameObject);
        }

        public void OnHit()
        {
            if (IsOnCd) return;
            GotHit?.Invoke();
            _hitCdCoroutine = StartCoroutine(HitCdCoroutine());
        }

        private IEnumerator HitCdCoroutine()
        {
            var startColor = _color.MeshColor;
            _color.MeshColor = _hitColor;

            yield return _hitCdWait;

            _color.MeshColor = startColor;
            _hitCdCoroutine = null;
        }
    }
}
