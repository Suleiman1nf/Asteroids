using System.Collections.Generic;
using Suli.Asteroids.Pool;
using Suli.Asteroids.Spawners;

namespace Suli.Asteroids
{
    public class UFOSpawner : Spawner<UFO, UFOConfig>
    {
        public UFOSpawner(List<UFOConfig> configs, IPool<UFO> pool) 
            : base(configs, pool)
        {
        }
    }
}