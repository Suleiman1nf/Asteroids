using UnityEngine;

namespace Suli.Asteroids
{
    public static class Borders
    {
        public static Vector2 Min;
        public static Vector2 Max;

        public static void SetBorders(float width, float height)
        {
            Min = new Vector2(-width / 2, -height / 2);
            Max = new Vector2(width / 2, height / 2);
        }

        public static bool IsInBorder(Vector3 position)
        {
            if (position.x > Min.x && position.x < Max.x)
            {
                if (position.y > Min.y && position.y < Max.y)
                {
                    return true;   
                }
            }

            return false;
        }
        
        public static Vector3 GetNextPosition(Vector3 position, float radius)
        {
            Vector3 nextPosition = position;
            
            if (position.x + radius < Min.x)
            {
                nextPosition.x = Max.x + radius;
            }
            if (position.x - radius > Max.x)
            {
                nextPosition.x = Min.x - radius;
            }

            if (position.y + radius < Min.y)
            {
                nextPosition.y = Max.y + radius;
            }
            if (position.y - radius > Max.y)
            {
                nextPosition.y = Min.y - radius;
            }

            return nextPosition;
        }
    }
}