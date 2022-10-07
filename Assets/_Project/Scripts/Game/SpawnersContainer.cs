using System.Collections.Generic;
using Suli.Asteroids.Pool;
using UnityEngine;
using Suli.Asteroids.Spawners;

namespace Suli.Asteroids
{
    public class SpawnersContainer
    {

        public AsteroidSpawner BigAsteroidsSpawner { get; private set; }
        public AsteroidSpawner SmallAsteroidsSpawner { get; private set; }
        public UFOSpawner UfoSpawner { get; private set; }

        public TimedSpawner<Asteroid, AsteroidConfig> BigAsteroidsSpawnLogic { get; private set; }
        public AllVariantsSpawner<Asteroid, AsteroidConfig> SmallAsteroidsSpawnLogic { get; private set; }
        public TimedSpawner<UFO, UFOConfig> TimedUFOSpawner { get; private set; }

        public SpawnersContainer(GameConfig config, PoolsContainer pools, Transform ufoFollowTarget)
        {
            InitSmallAsteroidsSpawner(config.SmallAsteroidConfig, pools.AsteroidsPool);
            InitBigAsteroidsSpawner(config.BigAsteroidConfig, config.AsteroidSpawnerSettings, pools.AsteroidsPool);
            InitUFOSpawner(config.UfoConfig, config.UfoSpawnerSettings, ufoFollowTarget, pools);
        }
        
        private void InitSmallAsteroidsSpawner(List<AsteroidConfig> configs, AsteroidsPool pool)
        {
            SmallAsteroidsSpawner = new AsteroidSpawner(configs, pool);
            SmallAsteroidsSpawnLogic = new AllVariantsSpawner<Asteroid,AsteroidConfig>(SmallAsteroidsSpawner);
        }

        private void InitBigAsteroidsSpawner(List<AsteroidConfig> configs, TimedSpawner<Asteroid, AsteroidConfig>.Settings settings, AsteroidsPool pool)
        {
            BigAsteroidsSpawner = new AsteroidSpawner(configs, pool);
            BigAsteroidsSpawnLogic = new TimedSpawner<Asteroid,AsteroidConfig>(settings, BigAsteroidsSpawner, new OutBordersPosition());
        }
        
        private void InitUFOSpawner(List<UFOConfig> config, TimedSpawner<UFO, UFOConfig>.Settings spawnerSettings, Transform followTransform, PoolsContainer pools)
        {
            var ufoDataConfigs = config;
            foreach (var dataConfig in config)
            {
                dataConfig.FollowTransform = followTransform;
                dataConfig.BulletPool = pools.BulletPool;
            }
            
            UfoSpawner = new UFOSpawner(ufoDataConfigs, pools.UfoPool);
            TimedUFOSpawner = new TimedSpawner<UFO, UFOConfig>(spawnerSettings, UfoSpawner, new OutBordersPosition());
        }
        
    }
}