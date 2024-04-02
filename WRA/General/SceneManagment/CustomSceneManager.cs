using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using WRA.General.Patterns;
using WRA.UI.PanelsSystem;

namespace WRA.General.SceneManagment
{
    public static class CustomSceneManager
    {
        public static float PercentOfLoad => asyncOperation?.progress / 0.9f ?? 0;
        public static bool SceneIsReady => asyncOperation?.progress >= 0.9f;

        private static Scene nextScene;
        private static string nextSceneName;
        private static AsyncOperation asyncOperation;

        public static void ChangeScene(int buildId, bool autoChangeScene = false)
        {
            nextSceneName = SceneManager.GetSceneByBuildIndex(buildId).name;
            CreateLoadingProcess(autoChangeScene);
        }

        public static void ChangeScene(string name, bool autoChangeScene = false)
        {
            PanelManager.Instance.ShowPanel<ProgressPanel>(null, true);
            nextSceneName = name;
            CreateLoadingProcess(autoChangeScene);
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
