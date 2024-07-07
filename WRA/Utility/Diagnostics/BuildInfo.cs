using TMPro;
using UnityEngine;

namespace WRA.Utility.Diagnostics
{
    public class BuildInfo : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        private string message;

        private void Awake()
        {
            message= $"{Application.productName} {Application.version} created by {Application.companyName}";
            text.text = message;
        }
    }
}
