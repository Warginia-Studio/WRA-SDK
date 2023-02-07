using UnityEngine;
using WRACore.UIExtension.Managers;

namespace WRACore.Tests
{
    public class DescriptionTest : MonoBehaviour
    {

        [SerializeField] private string description;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                DescriptionManager.Instance.ShowDescription(description);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                DescriptionManager.Instance.HideDescription();
            }
        }
    }
}
