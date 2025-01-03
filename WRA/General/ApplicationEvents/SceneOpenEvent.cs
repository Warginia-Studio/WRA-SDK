using UnityEngine;
using WRA.General.SceneManagment;
using Zenject;

namespace WRA.General.ApplicationEvents
{
    public class SceneOpenEvent : MonoBehaviour
    {
        [Inject] private SceneManager sceneManager;
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
