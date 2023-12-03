using UnityEngine;

namespace WRA.General.ApplicationEvents
{
    public class ExitApplicationEvent : MonoBehaviour
    {
        public void Exit()
        {
            Application.Quit();
        }
    }
}
