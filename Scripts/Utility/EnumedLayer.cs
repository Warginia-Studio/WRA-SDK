using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumedLayer : MonoBehaviour
{
    public EnumedLayers Layer => layer;
    [SerializeField] private EnumedLayers layer;
    
    private void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("EnumLayer");
    }

}
