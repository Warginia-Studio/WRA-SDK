using Character;
using UnityEngine;

namespace DependentObjects.ScriptableObjects
{
    public abstract class ContainerItem : ScriptableObject
    {
        public int ID;
        public Vector2Int Size;
        public Sprite Icon;
        public string Description;

        public bool Stacking;
        public int MaxStack;

        public virtual string GetDescription(Transform parrent)
        {
            return Description;
        }
    }
}
