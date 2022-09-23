using TMPro;
using UnityEngine;

namespace BhTest.UI.Lobby
{
    public class ErrorView : View
    {
        [SerializeField] private TMP_Text _body;

        public void SetMessage(string body)
        {
            _body.text = body;
        }

        public void Close()
        {
            Hide();
            ViewSystem.ShowView<MainMenuView>();
        }
    }
}
