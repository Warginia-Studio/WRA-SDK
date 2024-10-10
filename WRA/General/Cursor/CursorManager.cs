using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WRA.General.Patterns.Singletons;

namespace WRA.General.Cursor
{
    public class CursorManager : MonoBehaviour
    {
        [System.Serializable]
        private struct CursorData
        {
            public Texture2D Texture;
            public Vector2 HotSpot;
            public string Name;
        }
        
        [SerializeField] private List<CursorData> cursors;
        [SerializeField] private bool useCustomCursor = true;

        private void Start()
        {
            if (useCustomCursor)
            {
                UnityEngine.Cursor.visible = false;
                SetCursor(cursors.First().Name);
            }
        }

        public void SetCursor(string cursorName)
        {
            CursorData cursor = cursors.Find(c => c.Name == cursorName);
            if (cursor.Texture != null)
            {
                UnityEngine.Cursor.SetCursor(cursor.Texture, cursor.HotSpot, CursorMode.Auto);
            }
        }

    }
}
