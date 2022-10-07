using UnityEngine;

namespace Suli.Asteroids.Utils
{
    public class Cooldown
    {
        private float _lastTime;
        private readonly float _cooldown;
        private float CurrGameTime => Time.unscaledTime;

        public float GetRemainingTime() => (_lastTime + _cooldown - CurrGameTime) > 0 ? (_lastTime + _cooldown - CurrGameTime) : 0;

        public Cooldown(float cooldown)
        {
            _cooldown = cooldown;
            _lastTime = 0;
        }
        
        public void Reset()
        {
            _lastTime = CurrGameTime;
        }

        public bool IsCooldown()
        {
            return CurrGameTime < _cooldown + _lastTime;
        }
    }
}