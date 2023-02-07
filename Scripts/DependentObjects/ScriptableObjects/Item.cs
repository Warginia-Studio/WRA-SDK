using UnityEngine;
using WRACore.DependentObjects.Enums;

namespace WRACore.DependentObjects.ScriptableObjects
{
    [CreateAssetMenu(fileName ="Item", menuName = "thief01/Inventory/Item")]
    public class Item : ContainerItem
    {
        public ValueOfItem ValueType;
        
        public override string GetDescription(Transform parrent)
        {
            return "NO DESCRIPTION FOR NOW";
        }

        public override float GetCooldown(Transform parrent)
        {
            return 1;
        }

        public virtual ItemType GetItemType()
        {
            if (this.GetType() == typeof(ArmableItem))
            {
                
            }
            
            
            switch (GetType())
            {
                case var ctg when ctg == typeof(ArmableItem):
                    return ItemType.armable;
                case var ctg when ctg == typeof(UseableItem):
                    return ItemType.useable;
            }

            return ItemType.defaultItem;
        }
    }
}
