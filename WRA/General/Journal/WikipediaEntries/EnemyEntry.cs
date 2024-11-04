using UnityEngine;

namespace WRA.PlayerSystems.JournalSystem.WikipediaEntries
{
    [CreateAssetMenu(menuName = Definitions.SCRIPTALBES_PATH+"Journal System/Wikipedia/Enemy Entry")]
    public class EnemyEntry : WikipediaEntry
    {
        public string enemyName;
        public string enemyHealth;
        public string enemyType;

        public override (string labelName, string labelText)[] GetLabels()
        {
            return new[] { ("enemyName", enemyName), ("enemyHealth", enemyHealth), ("enemyType", enemyType) };
        }
    }
}
