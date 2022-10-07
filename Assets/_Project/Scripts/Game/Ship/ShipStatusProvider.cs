using System;
using UnityEngine;

namespace Suli.Asteroids
{
    public class ShipStatusProvider : IShipStatusProvider
    {
        public Vector2 Position { get; set; }
        public float Angle { get; set; }
        public float Speed { get; set; }
        public float ChargesCooldown { get; set; }
        
        public int ChargesCount { get; set; }
        public event Action<int> OnChargesCountChanged;

        private readonly Transform _transform;
        private readonly Movement _movement;
        private readonly Laser _laser;

        public ShipStatusProvider(Transform transform, Movement movement, Laser laser)
        {
            _transform = transform;
            _movement = movement;
            _laser = laser;
        }

        public void Update()
        {
            Position = _transform.localPosition;
            Speed = _movement.SpeedVector.magnitude; 
            Angle = _transform.localEulerAngles.z;
            ChargesCooldown = _laser.ChargerCooldown.GetRemainingTime();
            ChargesCount = _laser.ChargesCount;
            OnChargesCountChanged = OnChargesCountChanged;
        }
    }
}