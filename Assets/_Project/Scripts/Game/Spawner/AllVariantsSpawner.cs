using Suli.Asteroids.Pool;

namespace Suli.Asteroids.Spawners
{
    public sealed class AllVariantsSpawner<TObj, TConfig> 
        where TObj : class, IPooledObject<TObj, TConfig> where TConfig : IConfig
    {
        private readonly Spawner<TObj, TConfig> _spawner;

        public AllVariantsSpawner(Spawner<TObj, TConfig> spawner)
        {
            _spawner = spawner;
        }

        public void Spawn(IPositioner positioner)
        {
            for (int i = 0; i < _spawner.Configs.Count; i++)
            {
                _spawner.SpawnObject(positioner, i);
            }
        }
    }
}