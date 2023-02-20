using System.Collections.Generic;
using System.Linq;
using UIExtension.Controls.Dragables;
using UnityEngine;

namespace UIExtension.Controls.Containers
{
    [ExecuteInEditMode]
    public class ContainerWindowIniterGenerated : MonoBehaviour
    {
        [SerializeField] private Vector2Int inventorySize;
        [SerializeField] private Vector2Int slotSize;
        [SerializeField] private Transform debugParrent;
        [SerializeField] private bool debug;
        
        private Container.Container container;

        private int childCount = 0;
        
        private List<DropableContainerItem> dropables = new List<DropableContainerItem>();
        private void Awake()
        {
            
        }

        private void Update()
        {
            if (transform.childCount != childCount)
            {
                dropables = GetComponentsInChildren<DropableContainerItem>().ToList();
                childCount = transform.childCount;
                UpdateSlots();
            }
        }
        


        public void InitContainer(Container.Container container)
        {
            this.container = container;
        }

        private void UpdateSlots()
        {
            if (container == null)
            {
                container = FindObjectOfType<Container.Container>();
                if (container == null)
                {
                    return;
                }
            }
            for (int i = 0; i < dropables.Count; i++)
            {
                dropables[i].SlotPosition = TranslatePosition(i);
            }
        }

        private Vector2Int TranslatePosition(int index)
        {
            // int x = index % container.containerSize.x;
            // int y = index / container.containerSize.x;
            // return new Vector2Int( x, y);
            return Vector2Int.zero;
        }
    }
}
