using UnityEngine;

namespace Suli.Asteroids
{
    public sealed class Movement
    {
        private readonly float _friction;
        private readonly Transform _transform;
        private readonly float _objectRadius;
        private readonly float _startAcceleration;
        private readonly float _startSpeed;

        private Vector3 _speedVector;
        private float _acceleration;

        public Vector3 SpeedVector => _speedVector;

        public Movement(Settings settings, Transform transform)
        {
            _acceleration = settings.Acceleration;
            _friction = settings.Friction;
            _transform = transform;
            _startAcceleration = settings.Acceleration;
            _objectRadius = settings.ObjectRadius;
            _speedVector = transform.up * settings.StartSpeed;
            _startSpeed = settings.StartSpeed;
        }

        public void Update(float dt)
        {
            Accelerate(dt);
            ApplyFriction(dt);
            Move(dt);
            CheckBorders();
        }

        public void SetZeroSpeed()
        {
            _speedVector = Vector3.zero;
        }

        private void CheckBorders()
        {
            var localPosition = _transform.localPosition;
            _transform.localPosition = Borders.GetNextPosition(localPosition, _objectRadius);
        }

        public void SetAccelerationState(bool enable)
        {
            if(enable)
                _acceleration = _startAcceleration;
            else
                _acceleration = 0;    
        }
        

        private void Accelerate(float dt)
        {
            _speedVector += _transform.up * (_acceleration * dt);
        }

        public void UpdateSpeedVectorDirection()
        {
            _speedVector = _transform.up * _startSpeed;
        }

        private void ApplyFriction(float dt)
        {
            _speedVector -= _speedVector.normalized * (_friction * dt);
        }

        private void Move(float dt)
        {
            _transform.localPosition += _speedVector * dt;
        }

        [System.Serializable]
        public class Settings
        {
            public float ObjectRadius;
            public float Friction;
            public float Acceleration;
            public float StartSpeed;
        }
    }
}