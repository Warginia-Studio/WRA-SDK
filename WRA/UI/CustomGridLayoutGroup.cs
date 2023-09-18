using UnityEngine;
using UnityEngine.UI;
using WRA.CharacterSystems.InventorySystem;

namespace WRA.UI
{
    public class CustomGridLayoutGroup : GridLayoutGroup
    {
        [Header("If you want change CellSize you need do it in DDP_Profile")]
        private int xd;
        protected override void Awake()
        {
            if (DragDropProfile.Instance != null)
            {
                cellSize = DragDropProfile.Instance.CellSize;
                spacing = DragDropProfile.Instance.Spacing;
            }
            else
            {
                cellSize = new Vector2(32, 32);
                spacing = new Vector2(0, 0);
            }
            base.Awake();
        }

        protected void Update()
        {
            if (DragDropProfile.Instance != null && (cellSize != DragDropProfile.Instance.CellSize || spacing!= DragDropProfile.Instance.Spacing))
            {
                cellSize = DragDropProfile.Instance.CellSize;
                spacing = DragDropProfile.Instance.Spacing;
            }
        }
    }
}
