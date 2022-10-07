using UnityEngine.Pool;

namespace Suli.Asteroids.Pool
{
    public interface IPool<T> where T : class
    {
        public void ReleaseObject(T obj);
        public T GetObject();

        public ObjectPool<T> ObjectPool { get; }
    }
}