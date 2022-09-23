using BhTest.Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BhTest.UI.Lobby
{
    public class ChangeNameView : View
    {
        [SerializeField] private TMP_InputField _nameInput;
        [SerializeField] private Button _applyButton;

        public override void Show()
        {
            base.Show();
            _nameInput.text = PersistentData.PlayerName;
            ValidateName(_nameInput.text);
        }

        private void OnEnable()
        {
            _nameInput.onValueChanged.AddListener(ValidateName);
        }

        private void OnDisable()
        {
            _nameInput.onValueChanged.RemoveListener(ValidateName);
        }

        private void ValidateName(string name)
        {
            _applyButton.interactable = !string.IsNullOrEmpty(name);
        }

        public void ChangeName()
        {
            PersistentData.PlayerName = _nameInput.text;
            Back();
        }

        public void Back()
        {
            Hide();
            ViewSystem.ShowView<MainMenuView>();
        }
    }
}