using WRA.CharacterSystems.SkillsSystem;

namespace WRA.CharacterSystems.InventorySystem.Items
{
    public interface IUseableItem
    {
        ActionBase ActionBase { get; }
        ActionBase GetActionReference();
    }
}
