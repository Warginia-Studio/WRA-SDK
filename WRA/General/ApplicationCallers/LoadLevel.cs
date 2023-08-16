using UnityEngine;
using UnityEngine.SceneManagement;
using WRA.General.SceneManagment;

namespace WRA.General.ApplicationCallers
{
    public class LoadLevel : MonoBehaviour
    {
        [SerializeField] private string levelName;
        [SerializeField] private bool useLoaderScene;

        public void Startlevel()
        {
            if (useLoaderScene)
            {
                CustomSceneManager.Instance.ChangeScene(levelName);
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
                CustomSceneManager.Instance.ChangeScene(levelName);
            }
            else
            {
                SceneManager.LoadSceneAsync(levelName);
            }
        }
    }
}
