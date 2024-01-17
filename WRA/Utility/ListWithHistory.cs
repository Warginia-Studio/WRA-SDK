using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace WRA.Utility
{
    public class ListWithHistory<T> where T : Object
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
        
        public void SetObjects(T[] objects)
        {
            LastRemovedObjects = Objects.FindAll(ctg => Array.IndexOf(objects, ctg) == -1);
            Objects = new List<T>(objects);
        }
    }
}
