using System;
using Suli.Asteroids.Utils;
using UnityEngine;

namespace Suli.Asteroids
{
    public class Gun
    {
        private readonly float _speed;
        private readonly Cooldown _cooldown;
        private readonly Transform _transform;
        private readonly BulletPool _pool;
        private readonly Target _damageTarget;

        public Gun(Settings settings, Target damageTarget, Transform transform, BulletPool pool)
        {
            _damageTarget = damageTarget;
            _speed = settings.Speed;
            _pool = pool;
            _transform = transform;
            _cooldown = new Cooldown(settings.Cooldown);
        }

        public void Fire()
        {
            if (!_cooldown.IsCooldown())
            {
                Bullet bullet = _pool.GetObject();

                bullet.Init(_damageTarget, _transform.localPosition, _transform.localEulerAngles, _speed, (obj)=>
                {
                    _pool.ReleaseObject(obj);
                });
                _cooldown.Reset();    
            }
        }

        [Serializable]
        public class Settings
        {
            public float Cooldown;
            public float Speed;
        }
    }
    
}