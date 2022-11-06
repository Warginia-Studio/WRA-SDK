using UnityEngine;

namespace Utility
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
