using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

public enum TextType
{
    shaderStyle,
    
    
}

public class PopupTextManager : MonoBehaviourSingletonAutoCreateUI<PopupTextManager>
{
    public void ShowText(string text, TextType textType)
    {
        
    }
}
