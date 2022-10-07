using UnityEngine;

namespace Suli.Utils
{
    public static class Utility
    {

        public static Vector2 GetScreenSizeInWorldSpace(Camera cam)
        {
            var width = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - 0.5f);
            var height = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - 0.5f);
            return new Vector2(width, height);
        }
        
    }
}