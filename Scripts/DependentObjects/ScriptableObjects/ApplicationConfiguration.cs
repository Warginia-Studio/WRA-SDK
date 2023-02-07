using UnityEngine;

namespace WRACore.DependentObjects.ScriptableObjects
{
    [CreateAssetMenu(menuName = "thief01/Configuration", fileName = "Configuration")]
    public class ApplicationConfiguration : Patterns.ScriptableSingleton<ApplicationConfiguration>
    {
        public string Language;
    
    }
}
