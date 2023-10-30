using UnityEngine;
using UnityEngine.SceneManagement;
using WRA.General.SceneManagment;

namespace WRA.General.Callers
{
    public class LoadLevelEvent : MonoBehaviour
    {
        [SerializeField] private string levelName;
        [SerializeField] private bool useLoaderScene;
        [SerializeField] private bool autoStartScene;

        public void Startlevel()
        {
            if (useLoaderScene)
            {
                CustomSceneManager.ChangeScene(levelName, autoStartScene);
            }
            else
            {
                SceneManager.LoadSceneAsync(levelName);
            }
        }
        
        public void StartLevel(string levelName)
        {
            if (useLoaderScene)
            {
                CustomSceneManager.ChangeScene(levelName, autoStartScene);
            }
            else
            {
                SceneManager.LoadSceneAsync(levelName);
            }
        }

        public void StartLevel(int id)
        {
            CustomSceneManager.ChangeScene(id, autoStartScene);
        }
    }
}
