using BhTest.Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BhTest.UI.Lobby
{
    public class ServerView : View
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Button _acceptButton;
        [SerializeField] private TMP_InputField _ip;
        [SerializeField] private TMP_InputField _port;

        private bool _isHostMode;

        private void OnEnable()
        {
            _acceptButton.onClick.AddListener(OnAcceptButtonClick);
        }

        private void OnDisable()
        {
            _acceptButton.onClick.RemoveListener(OnAcceptButtonClick);
        }

        public override void Show()
        {
            base.Show();

            _ip.text = SaveSystem.ServerIp;
            _port.text = SaveSystem.ServerPort;
        }

        public void SetupHost()
        {
            _title.text = "Host Game";
            _isHostMode = true;
        }

        public void SetupJoin()
        {
            _title.text = "Join Game";
            _isHostMode = false;
        }

        public void OnAcceptButtonClick()
        {
            SaveSystem.ServerIp = _ip.text;
            SaveSystem.ServerPort = _port.text;
            SaveSystem.IsHosting = _isHostMode;
            SceneSystem.LoadGameplay();
        }

        public void Back()
        {
            Hide();
            ViewSystem.ShowView<MainMenuView>();
        }

    }
}