using UnityEngine;
using WRA.General.Patterns.Singletons;

namespace WRA.General
{
    [CreateAssetMenu(menuName = "thief01/WRA-SDK/Profiles/Application Profile", fileName = "Application Profile")]
    public class ApplicationProfile : ScriptableSingleton<ApplicationProfile>
    {
        public string Language = "pl";
        public bool CustomConsole = false;

        public CursorData CursorData;

    }
}
