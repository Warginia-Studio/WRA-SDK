using UnityEngine;

namespace WRACore.Utility.Math
{
    public class BoxMath
    {
        public static Vector2[] GetCorners(Vector2 position, Vector2 size)
        {
            return new[] { position, position+size- Vector2.one, new Vector2(position.x+size.x-1, position.y), new Vector2(position.x, position.y+size.y-1 ) };
        }
    
        public static bool InBox(Vector2 boxPosition, Vector2 boxSize, Vector2 point)
        {
            return boxPosition.x <= point.x  // left top: x
                   && boxPosition.y <= point.y  // left top: y
                   && boxPosition.x + boxSize.x > point.x  // right down: x 
                   && boxPosition.y + boxSize.y > point.y; // right down: y
        }
        

    }
}
