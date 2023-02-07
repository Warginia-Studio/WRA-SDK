using UnityEngine;

namespace WRACore.DependentObjects.ScriptableObjects
{
    public abstract class ContainerItem : ScriptableObject
    {
        public int ID;
        public Vector2Int Size;
        public Sprite Icon;

        public bool Stacking;
        public int MaxStack;

        public abstract string GetDescription(Transform parrent);

        public abstract float GetCooldown(Transform parrent);
    }
}
