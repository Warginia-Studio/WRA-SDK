using UnityEngine;

namespace DependentObjects.ScriptableObjects.Profiles
{
    [CreateAssetMenu(menuName = "thief01/WRA-SDK/Profiles/Application Profile", fileName = "Application Profile")]
    public class ApplicationProfile : Patterns.ScriptableSingleton<ApplicationProfile>
    {
        public string Language;
    
    }
}
