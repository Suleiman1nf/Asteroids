using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suli.Asteroids
{
    [CreateAssetMenu(menuName = "Asteroids/Create ShipConfig", fileName = "ShipConfig", order = 0)]
    public class ShipConfig : ScriptableObject
    {
        [SerializeField] private Ship _shipPrefab;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Movement.Settings _movementSettings;
        [SerializeField] private Rotation.Settings _rotationSettings;
        [SerializeField] private Gun.Settings _gunSettings;
        [SerializeField] private Laser.Settings _laserSettings;

        public Ship ShipPrefab => _shipPrefab;

        public Bullet BulletPrefab => _bulletPrefab;
        
        public Movement.Settings MovementSettings => _movementSettings;

        public Rotation.Settings RotationSettings => _rotationSettings;

        public Gun.Settings GunSettings => _gunSettings;

        public Laser.Settings LaserSettings => _laserSettings;
    }
}
