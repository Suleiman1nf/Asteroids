using System;

namespace Suli.Asteroids
{
    public interface IShipInput
    {
        public event Action OnGunFire;
        public event Action OnUseLaser;

        public event Action<bool> OnMove;

        public float Rotation();
    }
}