using UnityEngine;

namespace UIExtension
{
    public class FollowMouse : MonoBehaviour
    {
        [Tooltip("If rect transform is null then will use self.")]
        [SerializeField] private RectTransform rectTransform;

        [SerializeField] private Vector3 offset;

        private void Awake()
        {
            if(rectTransform==null)
                rectTransform = GetComponent<RectTransform>();
        }

        void Update()
        {
            rectTransform.position = Input.mousePosition + offset;
        }
    }
}
