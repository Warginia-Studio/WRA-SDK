using DependentObjects.ScriptableObjects;

namespace DependentObjects.Interfaces.Items
{
    public interface IUseableItem
    {
        ActionBase ActionBase { get; }
        ActionBase GetActionReference();
    }
}
