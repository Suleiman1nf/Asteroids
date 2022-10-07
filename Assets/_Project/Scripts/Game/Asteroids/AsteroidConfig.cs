using UnityEngine;
using Suli.Asteroids.Pool;

namespace Suli.Asteroids
{
    [CreateAssetMenu(menuName = "Asteroids/Create AsteroidConfig", fileName = "AsteroidConfig", order = 0)]
    public class AsteroidConfig : ScriptableObject, IConfig
    {
        [SerializeField] private float _radius;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;

        public float Radius => _radius;

        public Sprite Sprite => _sprite;

        public float MinSpeed => _minSpeed;

        public float MaxSpeed => _maxSpeed;
        
    }
}