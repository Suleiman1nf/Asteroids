using System;
using Suli.Asteroids.Utils;
using Suli.Asteroids.Pool;

namespace Suli.Asteroids.Spawners
{
    public sealed class TimedSpawner<TObj, TConfig> where TObj : class, 
        IPooledObject<TObj, TConfig> where TConfig : IConfig
    {
        private readonly Spawner<TObj, TConfig> _spawner;
        private readonly Cooldown _cooldown;
        private readonly Settings _settings;
        private readonly IPositioner _positioner;
        
        
        public TimedSpawner(Settings settings, Spawner<TObj, TConfig> spawner, IPositioner positioner)
        {
            _spawner = spawner;
            _settings = settings;
            _positioner = positioner;
            _cooldown = new Cooldown(settings.Cooldown);
        }

        public void Update(float dt)
        {
            if (!_cooldown.IsCooldown() && _spawner.Pool.ObjectPool.CountActive < _settings.MaxCount)
            {
                _spawner.SpawnObject(_positioner);
                
                _cooldown.Reset();
            }
        }
        

        [Serializable]
        public class Settings
        {
            public float Cooldown;
            public int MaxCount;
        }
    }
}