using Character;
using DependentObjects.Enums;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DependentObjects.ScriptableObjects
{
    [CreateAssetMenu(fileName ="Item", menuName = "thief01/Inventory/Item")]
    public class Item : ContainerItem
    {
        public ValueOfItem ValueType;
        
        public virtual ItemType GetItemType()
        {
            if (this.GetType() == typeof(ArmableItem))
            {
                
            }
            
            
            // switch (GetType())
            // {
            //     case var ctg when ctg == typeof(ArmableItem):
            //         return ItemType.armable;
            //     case var ctg when ctg == typeof(UseableItem):
            //         return ItemType.useable;
            // }

            return ItemType.defaultItem;
        }
    }
}
