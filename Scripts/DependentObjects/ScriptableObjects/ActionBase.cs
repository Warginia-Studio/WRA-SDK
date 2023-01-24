using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class ActionBase : ScriptableObject
{
    public string ActionName;
    
    protected ActionController ActionController;
    
    public abstract string GetDescription(ActionController owner);
    
    public abstract IEnumerator ActionEngine(ActionController owner);
}
