using System;
using UnityEngine;
using Suli.Asteroids.Pool;
using Random = UnityEngine.Random;

namespace Suli.Asteroids
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class UFO : MonoBehaviour, IPooledObject<UFO, UFOConfig>, IDamageDealer, ITarget
    {
        
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private event Action<UFO> _onDestroy;
        private Movement _movement;
        private Looker _looker;
        private Gun _gun;

        public Target DamageTarget { get; set; } = Target.Player;
        public Target Target { get; set; } = Target.Enemy;

        public void Init(UFOConfig config, IPositioner positioner, Action<UFO> onDestroy)
        {
            _gun = new Gun(config.GunSettings, Target.Player, transform, config.BulletPool);
            _spriteRenderer.sprite = config.Sprite;
            GetComponent<CircleCollider2D>().radius = config.Radius;
            transform.localPosition = positioner.GetPosition();
            var moveSettings = new Movement.Settings
            {
                ObjectRadius = config.Radius,
                Acceleration = 0,
                Friction = 0,
                StartSpeed = Random.Range(config.MinSpeed, config.MaxSpeed)
            };
            _movement = new Movement(moveSettings, transform);
            _looker = new Looker(transform, config.FollowTransform, config.RotationSpeed);
            _onDestroy = onDestroy;
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent<IDamageDealer>(out var damageDealer))
            {
                if(damageDealer.DamageTarget == Target)
                {
                    DestroySelf();
                }
            }
        }

        public void Update()
        {
            _gun.Fire();
            _looker.Update(Time.deltaTime);
            _movement.UpdateSpeedVectorDirection();
            _movement.Update(Time.deltaTime);
        }

        public void DestroySelf()
        {
            if(gameObject.activeSelf)
                _onDestroy?.Invoke(this);
        }
    }   
}
