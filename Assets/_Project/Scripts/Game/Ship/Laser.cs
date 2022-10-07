using System;
using Suli.Asteroids.Utils;
using UnityEngine;

namespace Suli.Asteroids
{
    public class Laser
    {
        public Cooldown Cooldown => _cooldown;
        public Cooldown ChargerCooldown => _chargerCooldown;
        public int ChargesCount
        {
            get => _chargesCount;
            set
            {
                _chargesCount = value;
                OnChargesCountChanged?.Invoke(_chargesCount);
            }
        }
        public event Action<int> OnChargesCountChanged;
        
        private readonly Settings _settings;
        private readonly Cooldown _chargerCooldown;
        private readonly Cooldown _cooldown;
        private readonly Transform _transform;
        private readonly GameObject _laserVisual;
        private int _chargesCount;
        private bool _isOn = false;
        private float _currUsingTime = 0;

        public Laser(Settings settings, Transform transform)
        {
            _settings = settings;
            _transform = transform;
            _cooldown = new Cooldown(settings.Cooldown);
            _chargerCooldown = new Cooldown(settings.ChargerCooldown);
            ChargesCount = settings.ChargesCount;
            _laserVisual = CreateLaser(settings.Prefab);
        }

        public void Restart()
        {
            ChargesCount = _settings.ChargesCount;
            _laserVisual.SetActive(false);
            _chargerCooldown.Reset();
            _isOn = false;
            _currUsingTime = 0;
        }

        public void Fire()
        {
            if (ChargesCount <= 0)
                return;
            
            if (!_cooldown.IsCooldown())
            {
                _isOn = true;
                _laserVisual.SetActive(true);
                _cooldown.Reset();
                ChargesCount--;
            }
        }

        public void Update(float dt)
        {
            if (!_chargerCooldown.IsCooldown())
            {
                ChargesCount++;
                _chargerCooldown.Reset();
            }
            if (_isOn)
            {
                _currUsingTime += dt;
                if (_currUsingTime >= _settings.Duration)
                {
                    _isOn = false;
                    _currUsingTime = 0;
                    _laserVisual.SetActive(false);
                    return;
                }

                RaycastHit2D hit = Physics2D.Raycast(_transform.position, _transform.up, _settings.Distance);
            
                if (hit.collider != null)
                {
                    if (hit.collider.TryGetComponent<ITarget>(out var target))
                    {
                        if(target.Target == Target.Enemy) // it would be better if target set by constructor 
                            target.DestroySelf();
                    }
                }    
            }
        }

        private GameObject CreateLaser(GameObject prefab)
        {
            var laser = GameObject.Instantiate(prefab,_transform);
            laser.transform.localScale = new Vector3(_settings.Distance, laser.transform.localScale.y, 1);
            laser.SetActive(false);
            return laser;
        }

        [Serializable]
        public class Settings
        {
            public GameObject Prefab;
            public float Cooldown;
            public float Duration;
            public float ChargerCooldown;
            public int ChargesCount;
            public float Distance;
        }
    }
}