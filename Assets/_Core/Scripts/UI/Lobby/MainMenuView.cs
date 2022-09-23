using BhTest.Infrastructure;

namespace BhTest.UI.Lobby
{
    public class MainMenuView : View
    {
        private void Start()
        {
            string netError = NetworkSystem.NetworkError;
            if (!string.IsNullOrEmpty(netError))
            {
                Hide();
                var view = ViewSystem.GetView<ErrorView>();
                view.SetMessage(netError);
                ViewSystem.ShowView(view);
            }
        }

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
            GameSettings.Quit();
        }
    }
}
