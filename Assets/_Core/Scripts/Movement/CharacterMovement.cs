using UnityEngine;

namespace BhTest.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : MovementSystem
    {
        private CharacterController _controller;

        protected override void Awake()
        {
            base.Awake();
            _controller = GetComponent<CharacterController>();
        }

        protected override void UpdateMovement()
        {
            if (!IsMoving) return;
            var moveDirection = transform.forward * MovementDirection.x + transform.right * MovementDirection.z;
            _controller.Move(moveDirection * MoveSpeed * Time.deltaTime);
        }
    }
}
