using UnityEngine;
using UnityEngine.UI;
using WRA.CharacterSystems.InventorySystem;
using WRA.UI.DragDropSystem.Dragables;

namespace WRA.UI.Controls.Containers
{
    public class DragableItemRare : MonoBehaviour
    {
        private ItemDragable itemDragable;
        [SerializeField] private Image image;
        private void Awake()
        {
            itemDragable = GetComponent<ItemDragable>();
        }

        private void Start()
        {
            if (itemDragable != null && itemDragable.HoldingItem != null)
            {
                var ddProf = DragDropProfile.Instance;
                if (ddProf.UseColors)
                {
                    image.color = ddProf.GetColorForValueOfItem(itemDragable.HoldingItem.ValueType);
                }

                if (ddProf.UseSprites)
                {
                    image.sprite = ddProf.GetSpriteForValueOfItem(itemDragable.HoldingItem.ValueType);
                }

                if (!ddProf.UseSprites && !ddProf.UseColors)
                {
                    image.color = Color.clear;
                }

                if (ddProf.UseSprites && !ddProf.UseColors)
                {
                    image.color = Color.white;
                }
            }
        }
    }
}
