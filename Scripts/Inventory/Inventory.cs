using DependentObjects.ScriptableObjects;

namespace Inventory
{
    public class Inventory : Container.Container
    {
        private void Awake()
        {
            holdingType = typeof(Item);
        }
    }
}
