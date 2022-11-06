using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Container Item", menuName = "thief01/Container/Container Item")]
public class ContainerItem : ScriptableObject
{
    public int ID;
    public Vector2Int Size;

    public bool stacking;
    public int maxStack;
}
