using System.Collections.Generic;
using WRA.General.Patterns;

namespace WRA.PlayerSystems.JournalSystem
{
    public class BaseJournalManager<T> : MonoBehaviourSingletonAutoCreate<BaseJournalManager<T>> where T : JournalEntry
    {
        protected List<T> entries = new List<T>();
    
        public void AddNewEntry(T entry)
        {
            entries.Add(entry);
        }

        public List<T> GetEntries()
        {
            return entries;
        }

        protected override void OnCreate()
        {
            throw new System.NotImplementedException();
        }
    }
}
