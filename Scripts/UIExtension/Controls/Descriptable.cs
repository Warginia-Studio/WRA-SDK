using System.Collections;
using System.Collections.Generic;
using UIExtension.Popups;
using UnityEngine;

public class Descriptable : DescriptableBase
{
    [SerializeField][TextArea(15,20)] private string description;
    protected override string GetDescription()
    {
        return description;
    }
}
