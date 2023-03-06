using UnityEngine;
using UnityEngine.UI;

namespace SceneManagment
{
    public class ExitButton : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(Exit);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
