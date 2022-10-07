using System;

namespace Suli.Asteroids.Pool
{
    public interface IPooledObject<out TObj, in TConfig> where TConfig : IConfig where TObj : class 
    {
        public void Init(TConfig config, IPositioner positioner, Action<TObj> onDestroy);
    }
}