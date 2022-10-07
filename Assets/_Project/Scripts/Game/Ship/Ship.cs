using System;
using UnityEngine;

namespace Suli.Asteroids
{
    public class Ship : MonoBehaviour, ITarget
    {
        private Movement _movement;
        private Rotation _rotation;
        private Gun _gun;
        private Laser _laser;
        private IShipInput _shipInput;
        private bool _isInit;
        private Action _onDead;
        private ShipStatusProvider _shipStatusProvider;

        public ShipStatusProvider ShipStatusProvider => _shipStatusProvider;

        public Target Target { get; set; } = Target.Player;

        private void Init(ShipConfig shipConfig, IShipInput shipInput, BulletPool pool, Action onDead)
        {
            _shipInput = shipInput;
            _movement = new Movement(shipConfig.MovementSettings, transform);
            _movement.SetAccelerationState(false);
            _rotation = new Rotation(shipConfig.RotationSettings, transform);
            _gun = new Gun(shipConfig.GunSettings, Target.Enemy, transform, pool);
            _laser = new Laser(shipConfig.LaserSettings, transform);

            _shipStatusProvider = new ShipStatusProvider(transform, _movement, _laser);
            _onDead = onDead;

            InitializeInput();
            
            _isInit = true;
        }

        private void InitializeInput()
        {
            _shipInput.OnMove += _movement.SetAccelerationState;
            _shipInput.OnGunFire += _gun.Fire;
            _shipInput.OnUseLaser += _laser.Fire;
        }

        public void Update()
        {
            if(!_isInit)
                throw new Exception("Create Ship from factory!");
            
            float rotation = _shipInput.Rotation();
            _rotation.RotationDirection = rotation;
            _rotation.Update(Time.deltaTime);
            _movement.Update(Time.deltaTime);
            _shipStatusProvider.Update();
        }
        
        public void DestroySelf()
        {
            _shipInput.OnMove -= _movement.SetAccelerationState;
            _shipInput.OnGunFire -= _gun.Fire;
            _shipInput.OnUseLaser -= _laser.Fire;
            
            _onDead?.Invoke();
        }

        public void OnRestart()
        {
            InitializeInput();
            _movement.SetAccelerationState(false);
            _movement.SetZeroSpeed();
            _laser.Restart();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<IDamageDealer>(out var damageDealer))
            {
                if (damageDealer.DamageTarget == Target)
                    DestroySelf();
            }
        }

        public void FixedUpdate()
        {
            _laser.Update(Time.fixedDeltaTime);
        }

        [Serializable]
        public class ShipFactory
        {
            [SerializeField] private Transform parent;

            public Ship Create(ShipConfig shipConfig, Vector2 position, BulletPool pool, Action onDead)
            {
                var go = Instantiate(shipConfig.ShipPrefab, position, Quaternion.identity, parent);
                go.Init(shipConfig, new ShipInputSystem(), pool, onDead);
                return go;
            }   
        }
    }
}