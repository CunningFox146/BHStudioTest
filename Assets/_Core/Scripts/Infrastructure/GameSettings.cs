using UnityEngine;

namespace BhTest.Infrastructure
{
    public static class GameSettings
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        public static void Quit()
        {
            Application.Quit();
        }
    }
}
