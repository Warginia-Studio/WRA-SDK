using DependentObjects.ScriptableObjects;
using UIExtension.Controls.Dragables.Dragables;
using UnityEngine;
using UnityEngine.UI;
using Utility.CustomAttributes.CustomProperty;

namespace UIExtension.Controls.Dragables
{
    public class DragableItemRare : MonoBehaviour
    {
        private ItemDragable itemDragable;
        [SerializeField][CustomSerializedField(true)] private CustomObjectProperty<Image> image;
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
                    image.serializedProperty.color = ddProf.GetColorForValueOfItem(itemDragable.HoldingItem.ValueType);
                }

                if (ddProf.UseSprites)
                {
                    image.serializedProperty.sprite = ddProf.GetSpriteForValueOfItem(itemDragable.HoldingItem.ValueType);
                }

                if (!ddProf.UseSprites && !ddProf.UseColors)
                {
                    image.serializedProperty.color = Color.clear;
                }

                if (ddProf.UseSprites && !ddProf.UseColors)
                {
                    image.serializedProperty.color = Color.white;
                }
            }
        }
    }
}
