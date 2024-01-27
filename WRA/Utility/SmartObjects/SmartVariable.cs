using UnityEngine;

namespace WRA.Utility.SmartObjects
{
    [System.Serializable]
    public class SmartVariable<T> where T : new()
    {
        public T Value => value;

        [SerializeField] private int xd;
        [SerializeField] private T value;
    
        public SmartVariable(T value)
        {
            this.value = value;
        }
    
        /// <summary>
        /// return true if changed
        /// </summary>
        /// <param name="value"></param>
        /// <returns>return true if changed</returns>
        public bool SetValue(T value)
        {
            if (this.value.Equals(value))
                return false;
            this.value = value;
            return true;
        }
    }
}
