using UnityEngine;

namespace DependentObjects.ScriptableObjects.Managment
{
    [System.Serializable]
    public abstract class ContainerItem : ScriptableObject
    {
        public int ID;
        public Vector2Int Size;
        public Sprite Icon;
        public string ItemName;
        [TextArea]
        public string Description;

        public bool Stacking;
        public int MaxStack;

        public virtual string GetDescription(Transform parrent)
        {
            return Description;
        }
    }
}
