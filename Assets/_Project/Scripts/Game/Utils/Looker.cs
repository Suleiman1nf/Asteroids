using UnityEngine;

namespace Suli.Asteroids
{
    public class Looker
    {
        private readonly Transform _transform;
        private readonly Transform _lookTransform;
        private readonly float _speed;

        public Looker(Transform transform, Transform lookTransform, float speed)
        {
            _speed = speed;
            _transform = transform;
            _lookTransform = lookTransform;
        }

        public void Update(float dt)
        {
            _transform.up= Vector3.Lerp(_transform.up, (_lookTransform.position - _transform.position), _speed * dt);
        }
    }
}