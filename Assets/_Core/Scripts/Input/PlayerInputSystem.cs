using BhTest.Input;
using Mirror;
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
            _inputActions.Player.PrimaryAction.performed += OnPrimaryActionHandler;
            _inputActions.Player.ExitGame.performed += OnExitGameHandler; ;
        }

        private void OnEnable()
        {
            DisableInput();
        }

        private void OnDisable()
        {
            EnableSystem();
        }

        private void Update()
        {
            _controller.SetIsMoving(IsMoving);
            _controller.SetMovementDirection(GetMovementDirection());
            _controller.SetViewDirection(GetViewDirection());
        }

        private Vector3 GetMovementDirection()
        {
            return new Vector3(VerticalAxis, 0f, HorizontalAxis);
        }

        private Vector3 GetViewDirection()
        {
            if (Camera == null) return Vector3.forward;

            var viewDir = transform.position - Camera.position;
            viewDir.y = 0;
            viewDir.Normalize();
            return viewDir;
        }

        private void DisableInput()
        {
            _inputActions.Player.Enable();
        }

        private void EnableSystem()
        {
            _inputActions.Player.Disable();
        }

        private void OnPrimaryActionHandler(InputAction.CallbackContext _)
        {
            _controller.PrimaryAction();
        }

        private void OnExitGameHandler(InputAction.CallbackContext _)
        {
            var manager = NetworkManager.singleton;
            if (NetworkServer.active && NetworkClient.isConnected)
            {
                manager.StopHost();
            }
            else if (NetworkClient.isConnected)
            {
                manager.StopClient();
            }
            else if (NetworkServer.active)
            {
                manager.StopServer();
            }
        }
    }
}
