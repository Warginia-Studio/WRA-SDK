using UnityEngine;
using UnityEngine.UI;

namespace UIExtension.Controls.Buttons
{
    [RequireComponent(typeof(Button))]
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
