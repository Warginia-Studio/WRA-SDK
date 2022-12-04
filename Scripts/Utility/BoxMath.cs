using UnityEngine;

namespace Utility
{
    public class BoxMath
    {
        public static Vector2[] GetCorners(Vector2 position, Vector2 size)
        {
            return new[] { position, position+size- Vector2.one, new Vector2(position.x+size.x-1, position.y), new Vector2(position.x, position.y+size.y-1 ) };
        }
    
        public static bool InBox(Vector2 boxPosition, Vector2 boxSize, Vector2 point)
        {
            point -= boxPosition;
            return 0 <= point.x && 0 <= point.y && boxSize.x > point.x && boxSize.y > point.y;
        }
    }
}
