using BhTest.Utils;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BhTest.Infrastructure
{
    public class SceneSystem : MonoBehaviour
    {
        public static event Action<SceneBuildIndex> SceneLoadStart;
        public static event Action<SceneBuildIndex> SceneLoadEnd;

        public static float LoadingProgress { get; private set; }
        public static SceneBuildIndex CurrentScene { get; private set; }
        public static SceneSystem Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(this);
        }

        public static void LoadGameplay() => LoadScene(SceneBuildIndex.Gameplay);
        public static void LoadLobby() => LoadScene(SceneBuildIndex.Lobby);

        public static void LoadScene(SceneBuildIndex scene)
        {
            var operation = SceneManager.LoadSceneAsync((int)scene);
            Instance?.StartCoroutine(SceneLoadingCoroutine(operation, scene));
            SceneLoadStart?.Invoke(scene);
        }

        private static IEnumerator SceneLoadingCoroutine(AsyncOperation operation, SceneBuildIndex scene)
        {
            while (!operation.isDone)
            {
                LoadingProgress = operation.progress;
                yield return null;
            }

            LoadingProgress = 1f;
            CurrentScene = scene;
            SceneLoadEnd?.Invoke(scene);
        }
    }
}
