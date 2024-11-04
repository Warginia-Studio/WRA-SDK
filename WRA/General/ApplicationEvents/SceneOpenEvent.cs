using UnityEngine;
using Zenject;

namespace WRA.General.SceneManagment
{
    public class SceneOpenEvent : MonoBehaviour
    {
        [Inject] private ILoadingScene sceneManager;
        public void OpenScene(string sceneName)
        {
            var scene = sceneManager as SceneManager;
            scene.LoadScene(sceneName);
        }
    
        public void OpenScene(int sceneIndex)
        {
            var scene = sceneManager as SceneManager;
            scene.LoadScene(sceneIndex);
        }
    }
}
