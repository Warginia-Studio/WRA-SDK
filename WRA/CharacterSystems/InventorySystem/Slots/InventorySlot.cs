using UnityEngine;
using WRA.Utility.Math;

namespace WRA.CharacterSystems.InventorySystem.Slots
{
    public class InventorySlot : ContainerSlot<Item>
    {
        public Vector2Int Position;

        public InventorySlot(Item containerItem, Vector2Int position) : base(containerItem)
        {
            this.Position = position;
        }

        public bool IsInside(Vector2Int position, ContainerItem item)
        {
            if (item == Item)
                return false;
            // var corners = BoxMath.GetCorners(position, item.Size);
            
            for (int i = 0; i < item.Size.x; i++)
            {
                for (int j = 0; j < item.Size.y; j++)
                {
                    if (BoxMath.InBox(Position, Item.Size, position + new Vector2Int(i, j)))
                        return true;
                }
            }


            return false;
        }
    }
}
