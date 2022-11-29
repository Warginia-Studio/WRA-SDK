using UnityEngine;
using Utility;

namespace Container
{
    public class ContainerSlot
    {
        public ContainerItem Item;
        public Vector2Int Position;
        public int stack;

        public ContainerSlot(ContainerItem containerItem, Vector2Int position)
        {
            Item = containerItem;
            Position = position;
        }

        public bool IsInside(Vector2 position, ContainerItem item)
        {
            if (item == Item)
                return false;
            var corners = BoxMath.GetCorners(position, item.Size);

            for (int i = 0; i < corners.Length; i++)
            {
                if (BoxMath.InBox(position, Item.Size, corners[i]))
                    return true;
            }
            return false;
        }

        public bool TryStack(ContainerItem containerItem)
        {
            if (Item.Stacking)
                return false;
            if (containerItem.ID != Item.ID)
                return false;
            if (stack - Item.MaxStack < 1)
                return false;

            stack++;
            return true;
        }

    }
}
