using UnityEngine;
using UnityEngine.UI;
using WRA.CharacterSystems.InventorySystem;

namespace WRA.UI.Controls.DD
{
    [RequireComponent(typeof(Image))]
    public class SlotStatusManager : MonoBehaviour
    {
        private Image image;
        private RectTransform rectTransform;
        private void Awake()
        {
            image = GetComponent<Image>();
            rectTransform = GetComponent<RectTransform>();
        }

        public void SetStatus(Vector3 position, Vector2 size, DragDropProfile.Status status)
        {
            rectTransform.position = position;
            rectTransform.sizeDelta = new Vector2(size.y, size.x);
            image.color = DragDropProfile.Instance.GetFinalColorOfDropStatus(status);
        }
    }
}
