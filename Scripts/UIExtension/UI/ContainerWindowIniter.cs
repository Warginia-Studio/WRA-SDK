using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Container;
using UIExtension.Managers;
using Unity.VisualScripting;
using UnityEngine;
using Utility;

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

        private void Update()
        {
            if (transform.childCount != childCount)
            {
                GetDropable();   
            }
        }
        
        public void OpenContainer(Container.Container container)
        {
            this.container = container;
            container.OnContainerChanged.AddListener(UpdateInventory);
            GetDropable();
            UpdateInventory();
            for (int i = 0; i < dropables.Count; i++)
            {
                dropables[i].InitContainerHolder(container, null);
            }
        }
        public void CloseContainer()
        {
            container = null;
            container.OnContainerChanged.RemoveListener(UpdateInventory);
        }
        
        private void GetDropable()
        {
            dropables = GetComponentsInChildren<Dropable>().ToList();
            childCount = transform.childCount;
            UpdateSlots();
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
                var dragable = Resources.LoadAll<Dragable>("")[0];
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
                spawnedDragable[i].gameObject.SetActive(true);
                spawnedDragable[i].InitContainerHolder(container, slots[i]);
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
