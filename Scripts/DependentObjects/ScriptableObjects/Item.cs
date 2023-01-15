using UnityEngine;

namespace DependentObjects.ScriptableObjects
{
    [CreateAssetMenu(fileName ="Item", menuName = "thief01/Inventory/Item")]
    public class Item : ContainerItem
    {
        public override string GetDescription(Transform parrent)
        {
            throw new System.NotImplementedException();
        }

        public override float GetCooldown(Transform parrent)
        {
            throw new System.NotImplementedException();
        }
    }
}
