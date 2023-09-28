using UnityEngine;

namespace WRA.General.Callers
{
    public class ExitApplicationEvent : MonoBehaviour
    {
        public void Exit()
        {
            Application.Quit();
        }
    }
}
