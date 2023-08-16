using UnityEngine;

namespace WRA.General
{
    [CreateAssetMenu(menuName = "thief01/WRA-SDK/Profiles/Application Profile", fileName = "Application Profile")]
    public class ApplicationProfile : Patterns.ScriptableSingleton<ApplicationProfile>
    {
        public string Language = "pl";
        public bool CustomConsole = false;

    }
}
