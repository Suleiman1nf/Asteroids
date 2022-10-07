using UnityEngine;

namespace Suli.Asteroids
{
    public interface IRotationAdapter
    {
        public Vector3 EulerAngle { get; set; }
    }
    
    public sealed class Rotation
    {
        private readonly float _rotationSpeed;
        private Transform _transform;

        public float RotationDirection { get; set; }

        public Rotation(Settings config, Transform transform)
        {
            _transform = transform;
            _rotationSpeed = config.RotationSpeed;
        }
        
        private void Rotate(float dt)
        {
            var angle = _transform.localEulerAngles;
            angle.z -= RotationDirection * _rotationSpeed * dt;
            _transform.localEulerAngles = angle;
        }
        
        

        public void Update(float dt)
        {
            Rotate(dt);
        }
        

        [System.Serializable]
        public class Settings
        {
            public float RotationSpeed;
        }
    }
}