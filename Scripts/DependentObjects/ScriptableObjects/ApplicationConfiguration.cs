using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "thief01/Configuration", fileName = "Configuration")]
public class ApplicationConfiguration : Patterns.ScriptableSingleton<ApplicationConfiguration>
{
    public string Language;
    
}
