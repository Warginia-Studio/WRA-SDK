using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace WRA.General.SceneManagment
{
    [RequireComponent(typeof(Button))]
    public class StartLevelButton : MonoBehaviour
    {

        [SerializeField] private string levelName;
        [SerializeField] private bool useLoaderScene;

        private void Awake()
        {
            var button = GetComponent<Button>();
        
            button.onClick.AddListener(Startlevel);
            // button.onClick.AddListener(Startlevel);
        }

        private void Startlevel()
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
