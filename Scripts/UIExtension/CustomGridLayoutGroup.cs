using DependentObjects.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace UIExtension
{
    public class CustomGridLayoutGroup : GridLayoutGroup
    {
        [Header("If you want change CellSize you need do it in DDP_Profile")]
        private int xd;
        protected void Awake()
        {
            if(DragDropProfile.Instance!=null)
                cellSize = DragDropProfile.Instance.CellSize;
            else
            {
                cellSize = new Vector2(32, 32);
            }
            base.Awake();
        }

        protected void Update()
        {
            if (DragDropProfile.Instance != null && cellSize != DragDropProfile.Instance.CellSize)
            {
                cellSize = DragDropProfile.Instance.CellSize;
            }
        }
    }
}
