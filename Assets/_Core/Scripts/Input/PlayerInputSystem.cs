using BhTest.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BhTest.Player
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerInputSystem : MonoBehaviour
    {
        private PlayerController _controller;
        private PlayerInputActions _inputActions;

        private float HorizontalAxis => _inputActions.Player.HorizontalAxis.ReadValue<float>();
        private float VerticalAxis => _inputActions.Player.VerticalAxis.ReadValue<float>();
        private bool IsMoving => !Mathf.Approximately(HorizontalAxis, 0f) || !Mathf.Approximately(VerticalAxis, 0f);

        public Transform Camera { get; set; }

        private void Awake()
        {
            _controller = GetComponent<PlayerController>();

            _inputActions = new PlayerInputActions();
            _inputActions.Player.SecondaryAction.performed += OnSecondaryActionHandler;
        }

        private void OnEnable()
        {
            _inputActions.Player.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Player.Disable();
        }

        private void Update()
        {
            _controller.SetIsMoving(IsMoving);
            if (Camera != null)
            {
                _controller.SetViewDirection(GetViewDirection());
            }
            _controller.SetMovementDirection(GetMovementDirection());
        }

        private Vector3 GetMovementDirection()
        {
            return new Vector3(VerticalAxis, 0f, HorizontalAxis);
        }

        private Vector3 GetViewDirection()
        {
            var viewDir = transform.position - Camera.position;
            viewDir.y = 0;
            viewDir.Normalize();
            return viewDir;
        }

        private void OnSecondaryActionHandler(InputAction.CallbackContext _)
        {
            Debug.Log($"OnSecondaryActionHandler{gameObject.name}");
            _controller.SecondaryAction();
        }
    }
}
