using UnityEngine;

namespace Container
{
    [CreateAssetMenu(fileName = "Container Item", menuName = "thief01/Container/Container Item")]
    public class ContainerItem : ScriptableObject
    {
        public int ID;
        public Vector2Int Size;
        public Sprite Icon;

        public bool Stacking;
        public int MaxStack;
    }
}
