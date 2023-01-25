using System;
using System.Collections;
using System.Collections.Generic;
using DependentObjects.Enums;
using DependentObjects.ScriptableObjects;
using UIExtension.UI;
using UnityEngine;
using UnityEngine.UI;

public class ValueOfItemStatus : MonoBehaviour
{
    [SerializeField] private Image valuableStatus;
    [SerializeField] private Color[] colors = new Color[6];

    private ContainerHolder containerHolder;
    private Item holdingItem;
    private IEnumerator Start()
    {
        yield return null;
        containerHolder = GetComponent<ContainerHolder>();
        Debug.Log(containerHolder.HoldingItem.GetType());
        Debug.Log(typeof(Item));
        Debug.Log(containerHolder.HoldingItem.GetType() == typeof(Item));
        if (containerHolder.HoldingItem.GetType() == typeof(Item))
        {
            holdingItem = (Item)containerHolder.HoldingItem;
            valuableStatus.color = colors[(int)holdingItem.ValueType];
        }

        

    }
}
