using UnityEngine;
using Random = UnityEngine.Random;

namespace BhTest.Infrastructure
{
    public static class SaveSystem
    {
        public static string PlayerName { get; set; }
        public static string ServerIp { get; set; }
        public static string ServerPort { get; set; }
        public static bool IsHosting { get; set; }

        static SaveSystem()
        {
            LoadSave();
            SceneSystem.SceneLoadStart += (_) => Save();
        }

        public static void LoadSave()
        {
            PlayerName = LoadKey(nameof(PlayerName), $"Player {Random.Range(0, 9999)}");
            ServerIp = LoadKey(nameof(ServerIp), "localhost");
            ServerPort = LoadKey(nameof(ServerPort), "7777");
        }

        private static string LoadKey(string key, string defaultValue)
        {
            if (!PlayerPrefs.HasKey(key)) return defaultValue;
            return PlayerPrefs.GetString(key);
        }

        public static void Save()
        {
            PlayerPrefs.SetString(nameof(PlayerName), PlayerName);
            PlayerPrefs.SetString(nameof(ServerIp), ServerIp);
            PlayerPrefs.SetString(nameof(ServerPort), ServerPort);
            PlayerPrefs.Save();
        }
    }
}
