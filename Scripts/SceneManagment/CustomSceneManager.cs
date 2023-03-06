using System.Collections;
using Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagment
{
    public class CustomSceneManager : MonoBehaviourSingletonAutoCreate<CustomSceneManager>
    {
        public float PercentOfLoad { get; private set; }
        public bool SceneIsReady { get; private set; } = false;

        private Scene nextScene;
        private string nextSceneName;
        private AsyncOperation asyncOperation;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    
        // TODO: UnloadingScenes

        public void ChangeScene(int buildId)
        {
            SceneIsReady = false;
            nextSceneName = SceneManager.GetSceneByBuildIndex(buildId).name;
            StartCoroutine(LoadingSceneOfLoading());
        }

        public void ChangeScene(string name)
        {
            SceneIsReady = false;
            nextSceneName = name;
            StartCoroutine(LoadingSceneOfLoading());
        }

        public void SetActiveNextScene()
        {
            // SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextSceneName));
            asyncOperation.allowSceneActivation = true;
            nextSceneName = null;
        }

        private IEnumerator LoadingSceneOfLoading()
        {
            var operation = SceneManager.LoadSceneAsync("LoadingScene");
            while (!operation.isDone)
            {
                yield return null;
            }

            StartCoroutine(LoadingScene());
        }


        private IEnumerator LoadingScene()
        {
            asyncOperation = SceneManager.LoadSceneAsync(nextSceneName);
            asyncOperation .allowSceneActivation = false;
            while (!asyncOperation .isDone)
            {
                if (!asyncOperation .allowSceneActivation && PercentOfLoad >= 0.85)
                {
                    SceneIsReady = true;
                }
                PercentOfLoad = asyncOperation .progress;
                yield return null;
            }
            SceneIsReady = true;
        }

    }
}
