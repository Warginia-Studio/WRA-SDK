#if UNITY_EDITOR

using UnityEditor;

namespace WRA.CharacterSystems.InventorySystem.Editor
{
    [CustomEditor(typeof(Item))]
    public class ItemEditor : ContainerItemEditor
    {
    
    }
}

#endif