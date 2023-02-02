using UnityEngine;

namespace UIExtension.Managers
{
    public class MainCanvas : MonoBehaviour
    {
        public static Transform mainCanvas;
        private void Awake()
        {
            mainCanvas = transform;
        }
    }
}
