using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Container;
using UnityEngine;

namespace UIExtension.UI
{
    [ExecuteInEditMode]
    public class ContainerWindowIniter : MonoBehaviour
    {
        [SerializeField] private Transform dragableParrent;
        private Container.Container container;

        private int childCount = 0;
        
        private List<Dropable> dropables = new List<Dropable>();
        private List<Dragable> spawnedDragable = new List<Dragable>();
        private void Awake()
        {
            
        }

        private void Update()
        {
            if (transform.childCount != childCount)
            {
                dropables = GetComponentsInChildren<Dropable>().ToList();
                childCount = transform.childCount;
                UpdateSlots();
            }
        }
        

        public void OpenContainer(Container.Container container)
        {
            this.container = container;
            container.OnContainerChanged.AddListener(UpdateInventory);
            UpdateInventory();
        }

        public void CloseContainer()
        {
            container = null;
            container.OnContainerChanged.RemoveListener(UpdateInventory);
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
                dropables[i].gameObject.name = $"Dropable(ID: {i})(POS: {dropables[i].SlotPosition})";
            }
        }

        private void UpdateInventory()
        {
            var slots = container.GetSlots();
            int difference = spawnedDragable.Count - slots.Length;
            if (difference < 0)
            {
                var dragable = Resources.FindObjectsOfTypeAll<Dragable>()[0];
                for (int i = 0; i < Math.Abs(difference); i++)
                {
                    spawnedDragable.Add(Instantiate(dragable.gameObject, dragableParrent).GetComponent<Dragable>());
                }
            }

            if (difference > 0)
            {
                for (int i = spawnedDragable.Count - difference; i < spawnedDragable.Count; i++)
                {
                    spawnedDragable[i].gameObject.SetActive(false);
                }
            }

            for (int i = 0; i < slots.Length; i++)
            {
                spawnedDragable[i].ContainerItem = slots[i].Item;
                spawnedDragable[i].Stacked = slots[i].stack;
            }
        }

        private Vector2Int TranslatePosition(int index)
        {
            int x = index % container.containerSize.x;
            int y = index / container.containerSize.x;
            return new Vector2Int( x, y);
        }
    }
}
