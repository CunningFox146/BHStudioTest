using UnityEngine;

namespace BhTest.UI.Lobby
{
    public class MainMenuView : View
    {
        public void ShowJoinServerMenu()
        {
            Hide();
            var view = ViewSystem.GetView<ServerView>();
            view.SetupJoin();
            ViewSystem.ShowView(view);
        }

        public void ShowHostServerMenu()
        {
            Hide();
            var view = ViewSystem.GetView<ServerView>();
            view.SetupHost();
            ViewSystem.ShowView(view);
        }

        public void ShowChangeNameMenu()
        {
            Hide();
            ViewSystem.ShowView<ChangeNameView>();
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
