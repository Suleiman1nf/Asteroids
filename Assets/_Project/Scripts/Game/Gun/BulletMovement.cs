using System;
using UnityEngine;

namespace Suli.Asteroids
{
    public class BulletMovement
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;
        private readonly Action _onReachBounds;
        
        public BulletMovement(Rigidbody2D rb, float speed, Action onReachBounds)
        {
            _rigidbody = rb;
            _speed = speed;
            _onReachBounds = onReachBounds;
        }

        public void Update(float dt)
        {
            Vector2 moveVector = _rigidbody.transform.up * (_speed * dt);
            
            _rigidbody.MovePosition(_rigidbody.position + moveVector);

            if (!Borders.IsInBorder(_rigidbody.transform.localPosition))
            {
                _onReachBounds?.Invoke();
            }
        }
    }
}