using BhTest.Infrastructure;
using BhTest.UI.Gameplay;
using Mirror;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace BhTest.Player
{
    [RequireComponent(typeof(PlayerInputSystem), typeof(PlayerController))]
    public class PlayerFacade : NetworkBehaviour
    {
        private ScoreSystem _scoreSystem;
        private HUD _hud;

        [field: SyncVar] public string PlayerName { get; set; }
        public PlayerInputSystem InputSystem { get; private set; }
        public PlayerController Controller { get; private set; }
        public PlayerFx Fx { get; private set; }
        public Camera PlayerCamera { get; private set; }

        private void Awake()
        {
            Controller = GetComponent<PlayerController>();
            InputSystem = GetComponent<PlayerInputSystem>();
            Fx = GetComponent<PlayerFx>();
            PlayerCamera = GetComponentInChildren<Camera>(true);
        }

        public override void OnStartClient()
        {
            PlayerCamera.gameObject.SetActive(isLocalPlayer);
            InputSystem.Camera = PlayerCamera.transform;
            InputSystem.enabled = isLocalPlayer;

            _hud = SystemsFacade.Instance.Hud;

            if (isLocalPlayer)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = false;
                _hud.RegisterLocalPlayer(this);
                CmdSetName(SaveSystem.PlayerName);
            }
        }

        public override void OnStopClient()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public override void OnStartServer()
        {
            _scoreSystem = SystemsFacade.Instance.Score;
        }

        public void AddPoint()
        {
            _scoreSystem.AddScore(this, 1);
        }

        public void RegisterCamera(Camera uiCamera)
        {
            var cameraData = PlayerCamera.GetUniversalAdditionalCameraData();
            cameraData.cameraStack.Add(uiCamera);
        }

        [Command]
        private void CmdSetName(string name)
        {
            PlayerName = name;
        }
    }
}
