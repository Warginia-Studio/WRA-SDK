using UnityEngine;

namespace WRA.PlayerSystems.JournalSystem
{
    [CreateAssetMenu(menuName = Definitions.SCRIPTALBES_PATH + "Journal/Journal Entry")]
    public class JournalEntry : ScriptableObject
    {
        public string title;
        public string description;
    }
}
