using System.Collections;
using Patterns;
using UnityEngine.SceneManagement;

namespace SceneManagment
{
    public class CustomSceneManager : MonoBehaviourSingletonAutoCreate<CustomSceneManager>
    {
        public float PercentOfLoad { get; private set; }
        public bool SceneIsReady { get; private set; } = false;

        private Scene nextScene;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    
        // TODO: UnloadingScenes

        public void ChangeScene(int buildId)
        {
            SceneIsReady = false;
            nextScene = SceneManager.GetSceneByBuildIndex(buildId);
            StartCoroutine(LoadingSceneOfLoading());
        }

        public void ChangeScene(string name)
        {
            SceneIsReady = false;
            nextScene = SceneManager.GetSceneByName(name);
            StartCoroutine(LoadingSceneOfLoading());
        }

        public void SetActiveNextScene()
        {
            SceneManager.SetActiveScene(nextScene);
            nextScene = new Scene();
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
            var operation = SceneManager.LoadSceneAsync(nextScene.name);
            operation.allowSceneActivation = false;
            while (!operation.isDone)
            {
                PercentOfLoad = operation.progress;
                yield return null;
            }
            SceneIsReady = true;
        }

    }
}
