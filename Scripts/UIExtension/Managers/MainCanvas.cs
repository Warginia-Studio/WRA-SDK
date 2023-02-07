using Patterns;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UIExtension.Managers
{
    public class MainCanvas : MonoBehaviour
    {
        public static Transform TheMainCanvas;

        private void Awake()
        {
            if (TheMainCanvas == null)
                TheMainCanvas = transform;
            else
                Destroy(gameObject);
        }
    }
}
