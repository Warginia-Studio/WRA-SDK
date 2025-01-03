using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WRA.General
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
            if(cursors == null || cursors.Count == 0)
            {
                useCustomCursor=false;
                return;
            }
            
            if (useCustomCursor)
            {
                SetCursor(cursors.First().Name);
            }
        }

        public void SetCursor(string cursorName)
        {
            if (!useCustomCursor)
                return;
            CursorData cursor = cursors.Find(c => c.Name == cursorName);
            if (cursor.Texture != null)
            {
                UnityEngine.Cursor.SetCursor(cursor.Texture, cursor.HotSpot, CursorMode.Auto);
            }
        }

    }
}
