using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using Suli.Asteroids.Pool;

namespace Suli.Asteroids.Spawners
{
    public abstract class Spawner<TObj, TConfig> where TObj : class, IPooledObject<TObj, TConfig> where TConfig : IConfig
    {
        private readonly IPool<TObj> _pool;
        private readonly List<TConfig> _configs;
        public event Action<TObj> OnDestroyObject;

        public List<TConfig> Configs => _configs;

        public IPool<TObj> Pool => _pool;

        protected Spawner(List<TConfig> configs, IPool<TObj> pool)
        {
            _configs = configs;
            _pool = pool;
            if (configs == null || configs.Count <= 0)
                throw new Exception("Config isn't defined");
        }

        public TObj SpawnObject(IPositioner positioner, int index = -1)
        {
            var obj = _pool.GetObject();
            TConfig config;
            if(index <= 0 || index >= _configs.Count)
                config = _configs[Random.Range(0, _configs.Count)];
            else
            {
                config = _configs[index];
            }
            obj.Init(config, positioner, Release);
            return obj;
        }

        public void Release(TObj obj)
        {
            OnDestroyObject?.Invoke(obj);
            _pool.ReleaseObject(obj);
        }
    }
}