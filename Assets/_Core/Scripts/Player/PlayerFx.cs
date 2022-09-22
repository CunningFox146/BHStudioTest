using Mirror;
using UnityEngine;

namespace BhTest.Player
{
    public class PlayerFx : NetworkBehaviour
    {
        [SerializeField] private TrailRenderer _trail;
        [SerializeField] private GameObject _hitFx;
        private IHitSource _hitSource;

        [field: SyncVar(hook = nameof(OnLineEmittingChange))] public bool IsLineEmitting { get; set; }

        public override void OnStartServer()
        {
            _hitSource = GetComponent<IHitSource>();
            RegisterEventHandlers();
        }

        public override void OnStopServer()
        {
            UnregisterEventHandlers();
        }

        private void OnLineEmittingChange(bool old, bool current)
        {
            _trail.emitting = current;
        }
        private void RegisterEventHandlers()
        {
            _hitSource.GotHit += OnGotHitHandler;
        }

        private void UnregisterEventHandlers()
        {
            _hitSource.GotHit -= OnGotHitHandler;
        }

        private void OnGotHitHandler()
        {
            var fx = Instantiate(_hitFx, transform.position, Quaternion.identity);
            NetworkServer.Spawn(fx);
        }
    }
}
