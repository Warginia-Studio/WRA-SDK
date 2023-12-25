using UnityEngine;

namespace WRA.General.Cursor
{
    [CreateAssetMenu(menuName = "thief01/WRA-SDK/Profiles/Cursor Data", fileName = "Cursor Data")]
    public class CursorData : ScriptableObject
    {
        [SerializeField] private SimpleCursor defaultCursor;
        [SerializeField] private SimpleCursor overCursor;
        [SerializeField] private SimpleCursor moveCursor;
        [SerializeField] private SimpleCursor selectCursor;
    
        public SimpleCursor GetCursor(CursorType cursorType)
        {
            switch (cursorType)
            {
                case CursorType.defaultCursor:
                    return defaultCursor;
                case CursorType.overCursor:
                    return overCursor;
                case CursorType.moveCursor:
                    return moveCursor;
                case CursorType.selectCursor:
                    return selectCursor;
                default:
                    return defaultCursor;
            }
        }
    }
}
