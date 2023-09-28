using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using WRA.General.Patterns;

namespace WRA.General.SceneManagment
{
    public static class CustomSceneManager
    {
        public static float PercentOfLoad => asyncOperation?.progress ?? 0;
        public static bool SceneIsReady => asyncOperation?.isDone ?? false;

        private static Scene nextScene;
        private static string nextSceneName;
        private static AsyncOperation asyncOperation;

        public static void ChangeScene(int buildId, bool autoChangeScene = false)
        {
            nextSceneName = SceneManager.GetSceneByBuildIndex(buildId).name;
            CreateLoadingProcess();
        }

        public static void ChangeScene(string name, bool autoChangeScene = false)
        {
            nextSceneName = name;
            CreateLoadingProcess();
        }

        public static void SetActiveNextScene()
        {
            asyncOperation.allowSceneActivation = true;
            nextSceneName = null;
        }

        private static void CreateLoadingProcess(bool autoChangeScene = false)
        {
            asyncOperation = SceneManager.LoadSceneAsync(nextSceneName);
            asyncOperation.allowSceneActivation = autoChangeScene;
        }
    }
}
