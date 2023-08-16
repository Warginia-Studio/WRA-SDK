using UnityEngine;

namespace WRA.PlayerSystems.JournalSystem
{
    [CreateAssetMenu(menuName = Definitions.SCRIPTALBES_PATH + "Journal System/Journal Entry")]
    public class JournalEntry : ScriptableObject
    {
        public string title;
        public string description;
    }
}
