using UnityEngine;
using Suli.Asteroids.Pool;

namespace Suli.Asteroids
{
    public class OutBordersPosition : IPositioner
    {
        public Vector3 GetPosition()
        {
            float xPos = Random.Range(0, 1f) > 0.5f ? Borders.Max.x : Borders.Min.x;
            float yPos = Random.Range(0, 1f) > 0.5f ? Borders.Max.y : Borders.Min.y;
            return new Vector3(xPos, yPos);
        }
    }
}