using UnityEngine;
using Suli.Asteroids.Pool;

namespace Suli.Asteroids
{
    [CreateAssetMenu(menuName = "Asteroids/Create UFOConfig", fileName = "UFOConfig", order = 0)]
    public class UFOConfig : ScriptableObject, IConfig
    {
        [SerializeField] private float _radius;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private Gun.Settings _gunSetings;

        public Transform FollowTransform { get; set; }
        public BulletPool BulletPool { get; set; }

        public float Radius => _radius;

        public Sprite Sprite => _sprite;

        public float MinSpeed => _minSpeed;

        public float MaxSpeed => _maxSpeed;

        public float RotationSpeed => _rotationSpeed;

        public Gun.Settings GunSettings => _gunSetings;
    }
}