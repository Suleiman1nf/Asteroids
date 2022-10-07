using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Suli.Asteroids.Pool
{
    public abstract class GameObjectPool<T> : IPool<T> where T : MonoBehaviour
    {
        [SerializeField] private Transform container;

        private T _prefab;
        private ObjectPool<T> _pool;
        private bool _isInit = false;

        public ObjectPool<T> ObjectPool => _pool;

        public void Init(T prefab)
        {
            _prefab = prefab;
            _pool = new ObjectPool<T>(Create, OnGet, OnRelease);
            _isInit = true;
        }
        
        public void ReleaseObject(T asteroid)
        {
            if (!_isInit)
                throw new Exception("Pool isn't init");
            _pool.Release(asteroid);
        }

        public int Count()
        {
            return _pool.CountActive;
        }

        public T GetObject()
        {
            if (!_isInit)
                throw new Exception("Pool isn't init");
            return _pool.Get();
        }

        private void OnGet(T asteroid)
        {
            asteroid.gameObject.SetActive(true);
        }

        private void OnRelease(T asteroid)
        {
            asteroid.gameObject.SetActive(false);
        }

        private T Create()
        {
            var go = GameObject.Instantiate(_prefab, container);
            return go;
        }
    }
}