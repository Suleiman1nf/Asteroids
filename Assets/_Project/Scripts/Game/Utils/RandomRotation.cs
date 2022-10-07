using UnityEngine;

namespace Suli.Asteroids
{
    public class RandomRotation
    {
        public float GetRotation()
        {
            return Random.Range(0, 360);
        }
    }
}