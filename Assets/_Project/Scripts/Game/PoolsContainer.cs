using System;

namespace Suli.Asteroids
{
    [Serializable]
    public class PoolsContainer
    {
        public BulletPool BulletPool;
        public AsteroidsPool AsteroidsPool;
        public UFOPool UfoPool;

        public void Init(Bullet bulletPrefab, UFO ufoPrefab, Asteroid asteroidPrefab)
        {
            BulletPool.Init(bulletPrefab);
            UfoPool.Init(ufoPrefab);
            AsteroidsPool.Init(asteroidPrefab);
        }
    }
}