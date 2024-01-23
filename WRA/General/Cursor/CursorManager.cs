using UnityEngine;
using WRA.General.Patterns.Singletons;

namespace WRA.General.Cursor
{
    public class CursorManager : MonoBehaviourSingletonAutoCreate<CursorManager>
    {
        private CursorData cursorData;
        
        protected override void OnCreate()
        {
            UnityEngine.Cursor.visible = false;
            cursorData = ApplicationProfile.Instance.CursorData;
            SetCursor(CursorType.defaultCursor);
        }
        
        public void SetCursor(CursorType cursorType)
        {
            UnityEngine.Cursor.SetCursor(cursorData.GetCursor(cursorType).Texture, cursorData.GetCursor(cursorType).HotSpot, CursorMode.Auto);
        }

    }
}
