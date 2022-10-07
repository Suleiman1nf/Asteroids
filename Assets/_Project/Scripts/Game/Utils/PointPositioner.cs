using UnityEngine;
using Suli.Asteroids.Pool;

namespace Suli.Asteroids
{
    public class PointPositioner : IPositioner
    {
        private readonly Vector3 _position;
        
        public PointPositioner(Vector3 position)
        {
            _position = position;
        }
        
        public Vector3 GetPosition()
        {
            return _position;
        }
    }
}