using System.Collections.Generic;

namespace WRA.Utility
{
    public class ListWithHistory<T> where T : new ()
    {
        public List<T> Objects { get; private set; }
        public List<T> LastRemovedObjects { get; private set; }
    
        public ListWithHistory()
        {
            Objects = new List<T>();
            LastRemovedObjects = new List<T>();
        }
    
        public void SetObjects(List<T> objects)
        {
            LastRemovedObjects = Objects.FindAll(ctg => !objects.Contains(ctg));
            Objects = objects;
        }
    }
}
