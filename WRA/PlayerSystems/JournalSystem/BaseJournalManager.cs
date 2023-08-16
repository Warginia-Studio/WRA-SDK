using System.Collections.Generic;
using WRA.General.Patterns;

namespace WRA.PlayerSystems.JournalSystem
{
    public class BaseJournalManager<T> : MonoBehaviourSingletonAutoCreate<BaseJournalManager<T>> where T : JournalEntry
    {
        private List<T> entries = new List<T>();
    
        public void AddNewEntry(T entry)
        {
            entries.Add(entry);
        }
    }
}
