using UnityEngine;
using UnityEngine.Serialization;
using WRA.CharacterSystems.InteractionsSystem;
using WRA.CharacterSystems.InventorySystem.Managment;
using WRA.CharacterSystems.StatisticsSystem;

namespace WRA.CharacterSystems
{
    public class CharacterSystemsProvider : MonoBehaviour
    {
        public Inventory Inventory { get; }
        public StatisticsControler StatisticsControler { get; }
        public InteractionControlerBase InteractionControlerBase { get; }

        [SerializeField] private Inventory inventory;
        [SerializeField] private StatisticsControler statisticsControler;
        [SerializeField] private InteractionControlerBase interactionControlerBase;
    
        private void Awake()
        {
        
        }
    }
}
