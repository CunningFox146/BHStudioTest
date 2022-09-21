using BhTest.Utils;
using UnityEngine;

namespace BhTest.Movement
{
    public abstract class MovementSystem : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        private SourceModifierList _speedModifier;

        public bool IsMoving { get; set; }
        public Vector3 MovementDirection { get; set; }
        public float MoveSpeed => _moveSpeed * _speedModifier.Modifier;

        protected virtual void Awake()
        {
            _speedModifier = new SourceModifierList();
        }

        protected virtual void Update()
        {
            UpdateMovement();
        }

        public void AddSpeedMultiplier(string key, float multiplier) => _speedModifier.AddModifier(key, multiplier);
        public void RemoveSpeedMultiplier(string key) => _speedModifier.RemoveModifier(key);

        protected abstract void UpdateMovement();
    }
}
