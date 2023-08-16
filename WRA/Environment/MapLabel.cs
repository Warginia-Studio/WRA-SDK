using TMPro;
using UnityEngine;

namespace WRA.Environment
{
    public class MapLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshPro text;
        public void SetLabel(string text)
        {
            this.text.text = text;
        }

        public void CloseLabel()
        {
            gameObject.SetActive(false);
        }
    }
}
