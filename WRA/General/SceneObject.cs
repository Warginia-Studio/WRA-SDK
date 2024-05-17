using UnityEngine;

namespace WRA.General
{
    public class SceneObject : MonoBehaviour
    {
        public static SceneObject Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
                return;
            Instance = this;
        }
    }
}
