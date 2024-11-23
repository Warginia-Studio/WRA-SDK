using UnityEngine;

namespace WRA.General
{
    public class OpenLink : MonoBehaviour
    {
        [SerializeField] private string link;

        public void OpenURL()
        {
            Debug.Log("Open link: " + link);
            Application.OpenURL(link);
        }
    }
}