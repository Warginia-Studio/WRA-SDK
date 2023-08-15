using UnityEngine;
using WRA.CharacterSystems.InventorySystem.Items;
using WRA.CharacterSystems.SkillsSystem;

namespace WRA.CharacterSystems.InventorySystem
{
    public class Skill : ContainerItem, IUseableItem
    {
        public ActionBase ActionBase => actionBase;
        
        [SerializeField] private ActionBase actionBase;
    
        public ActionBase GetActionReference()
        {
            return actionBase;
        }
    }
}
