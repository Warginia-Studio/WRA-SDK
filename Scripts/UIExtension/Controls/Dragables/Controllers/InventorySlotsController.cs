using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using Managment;
using UIExtension.Controls.Dragables.Dropables;
using UnityEngine;

namespace UIExtension.Controls.Dragables.Controllers
{
    public class InventorySlotsController : BaseSlotsController<InventorySlot, Item>
    {
        private RectTransform rectTransform;
        private CustomGridLayoutGroup customGridLayoutGroup;

        protected void Awake()
        {
            GetComponents();
        
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public override void Open(Container<InventorySlot, Item> container)
        {
            HoldingContainer = container;
            container.OnContainerChanged.AddListener(OnContainerChanged);
        }

        public override void Close()
        {
            HoldingContainer.OnContainerChanged.RemoveListener(OnContainerChanged);
        }

        public override void InitSlots()
        {
            if (rectTransform == null || customGridLayoutGroup == null)
                GetComponents();
            
            var newDropables = transform.GetComponentsInChildren<DropableItem>();
            if (Dropables.Length != newDropables.Length)
                Dropables = newDropables;

            int x = 0;
            int y = 0;

            int inRow = (int)(rectTransform.sizeDelta.x / customGridLayoutGroup.cellSize.x);
        
            for (int i = 0; i < Dropables.Length; i++)
            {
                x = i % inRow;
                y = i / inRow;
                (Dropables[i] as DropableItem).InitId(new Vector2Int(x,y));
            }
        }

        protected override void OnContainerChanged()
        {
        
        }

        private void GetComponents()
        {
            rectTransform = GetComponent<RectTransform>();
            customGridLayoutGroup = GetComponent<CustomGridLayoutGroup>();
        }
    }
}
