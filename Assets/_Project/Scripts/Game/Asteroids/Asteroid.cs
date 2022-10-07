using System;
using UnityEngine;
using Random = UnityEngine.Random;
using Suli.Asteroids.Pool;

namespace Suli.Asteroids
{

    [RequireComponent(typeof(CircleCollider2D))]
    public class Asteroid : MonoBehaviour, IPooledObject<Asteroid, AsteroidConfig>, IDamageDealer, ITarget
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private Movement _movement;
        private event Action<Asteroid> _onDestroy;

        public Target DamageTarget { get; set; } = Target.Player;
        public Target Target { get; set; } = Target.Enemy;

        public void Init(AsteroidConfig config, IPositioner positioner, Action<Asteroid> onDestroy)
        {
            _spriteRenderer.sprite = config.Sprite;
            GetComponent<CircleCollider2D>().radius = config.Radius;
            transform.localPosition = positioner.GetPosition();
            transform.localEulerAngles = new Vector3(0, 0, new RandomRotation().GetRotation());
            _movement = new Movement(new Movement.Settings
            {
                ObjectRadius = config.Radius,
                Acceleration = 0,
                Friction = 0,
                StartSpeed = Random.Range(config.MinSpeed, config.MaxSpeed)
            }, transform);
            
            _onDestroy = onDestroy;
        }

        public void Update()
        {
            _movement?.Update(Time.deltaTime);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<IDamageDealer>(out var damageDealer))
            {
                if(damageDealer.DamageTarget == Target)
                {
                    DestroySelf();
                }
            }
        }

        public void DestroySelf()
        {
            if(gameObject.activeSelf)
                _onDestroy?.Invoke(this);
        }
        
    }
}