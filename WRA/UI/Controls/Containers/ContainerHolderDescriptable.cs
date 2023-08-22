using UnityEngine;
using UnityEngine.EventSystems;
using WRA.CharacterSystems.InventorySystem;
using WRA.UI.Managers;

namespace WRA.UI.Controls.Containers
{
    public class ContainerHolderDescriptable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private ContainerItem containerItem;
        // private ContainerHolder containerHolder;
        private void Start()
        {
            // containerHolder = GetComponent<ContainerHolder>();
            // containerItem = containerHolder.HoldingItem;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            // DescriptionManager.Instance.ShowDescription(containerItem.GetDescription(containerHolder.Container.transform));
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            DescriptionManager.Instance.HideDescription();
        }
    }
}
