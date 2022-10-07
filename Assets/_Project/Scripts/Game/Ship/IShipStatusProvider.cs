using System;
using UnityEngine;

namespace Suli.Asteroids
{
    public interface IShipStatusProvider
    {
        public Vector2 Position { get; set; }
        public float Angle { get; set; }
        public float Speed { get; set; }
        public float ChargesCooldown { get; set; }

        public int ChargesCount { get; set; }

        public event Action<int> OnChargesCountChanged;
    }
}