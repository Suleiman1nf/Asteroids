using System;
using UnityEngine;

namespace Suli.Asteroids
{
    public class Bullet : MonoBehaviour, IDamageDealer
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        private BulletMovement _movement;
        private Action<Bullet> _onDestroy;
        
        public Target DamageTarget { get; set; }

        public void Init(Target unitTarget, Vector3 startPosition, Vector3 angle, float speed, Action<Bullet> onDestroy)
        {
            DamageTarget = unitTarget;
            transform.localPosition = startPosition;
            transform.localEulerAngles = angle;
            _onDestroy = onDestroy;
            _movement = new BulletMovement(_rigidbody2D, speed, DestroySelf);
        }

        private void DestroySelf()
        {
            if(gameObject.activeSelf)
                _onDestroy?.Invoke(this);
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent<ITarget>(out var target))
            {
                if(target.Target == DamageTarget)
                    DestroySelf();
            }
        }

        public void FixedUpdate()
        {
            _movement.Update(Time.fixedDeltaTime);
        }
    }
}