using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.General.Patterns;
using WRA.UI.TextControl;

[RequireComponent(typeof(TextControlerByWritting))]
public class FadeTextWriterProviderManager : MonoBehaviourSingletonMustExist<FadeTextWriterProviderManager>
{
    public TextControlerByWritting TextControlerByWritting => textControlerByWritting; 
    [SerializeField] private TextControlerByWritting textControlerByWritting;

    private void Awake()
    {
        textControlerByWritting = GetComponent<TextControlerByWritting>();
    }
}
