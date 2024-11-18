using UnityEngine;

namespace WRA.General
{
    public class OpenLink : MonoBehaviour
    {
        [SerializeField] private string link;

        public void OnOpenLink()
        {
            Application.OpenURL(link);
        }
    }
}
