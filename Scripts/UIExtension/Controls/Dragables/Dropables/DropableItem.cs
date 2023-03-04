using DependentObjects.Classes.Slots;
using DependentObjects.ScriptableObjects.Managment;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIExtension.Controls.Dragables.Dropables
{
    public class DropableItem : BaseDropable<InventorySlot, Item>
    {
        [SerializeField] private Vector2Int position;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void InitId(Vector2Int position)
        {
            gameObject.name = "InventoryDropable_" + position;
            this.position = position;
        }

        public override bool IsValid()
        {
            return false;
        }

        public override void OnDrop(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
