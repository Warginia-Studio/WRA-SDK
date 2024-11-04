using UnityEngine;
using UnityEngine.SceneManagement;
using WRA.General.SceneManagment;
using WRA.UI.PanelsSystem;
using Zenject;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

namespace WRA.General.ApplicationEvents
{
    public class LoadLevelEvent : MonoBehaviour
    {
        [SerializeField] private string levelName;
        [Inject] private WRA.General.SceneManagment.SceneManager customSceneManager;

        public void Startlevel()
        {
            customSceneManager.LoadScene(levelName);
        }

        public void StartLevel(string levelName)
        {
            customSceneManager.LoadScene(levelName);
        }
    }
}
