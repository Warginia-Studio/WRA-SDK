using System;
using UnityEngine;
using WRA.General.Patterns.Singletons;

namespace WRA.General
{
    public class CursorManager : MonoBehaviourSingletonAutoCreate<CursorManager>
    {
        private CursorData cursorData;
        
        protected override void OnCreate()
        {
            Cursor.visible = false;
            cursorData = ApplicationProfile.Instance.CursorData;
            SetCursor(CursorType.defaultCursor);
        }
        
        public void SetCursor(CursorType cursorType)
        {
            Cursor.SetCursor(cursorData.GetCursor(cursorType).Texture, cursorData.GetCursor(cursorType).HotSpot, CursorMode.Auto);
        }

    }
}
