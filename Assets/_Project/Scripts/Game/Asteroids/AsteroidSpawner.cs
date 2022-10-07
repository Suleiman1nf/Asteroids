using System.Collections.Generic;
using Suli.Asteroids.Pool;
using Suli.Asteroids.Spawners;

namespace Suli.Asteroids
{
    public class AsteroidSpawner : Spawner<Asteroid, AsteroidConfig>
    {
        public AsteroidSpawner(List<AsteroidConfig> configs, IPool<Asteroid> pool) 
            : base(configs, pool)
        {
        }
    }
}