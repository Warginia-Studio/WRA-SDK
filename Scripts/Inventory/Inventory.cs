using WRACore.DependentObjects.ScriptableObjects;

namespace WRACore.Inventory
{
    public class Inventory : Container.Container
    {
        private void Awake()
        {
            holdingType = typeof(Item);
        }
    }
}
