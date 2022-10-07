using System.Collections.Generic;
using UnityEngine;
using Suli.Asteroids.Spawners;

namespace Suli.Asteroids
{
    [CreateAssetMenu(menuName = "Asteroids/Create GameConfig", fileName = "GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private ShipConfig _shipConfig;
        [SerializeField] private Vector2 _startPosition;
        [SerializeField] private Asteroid _asteroidPrefab;
        [SerializeField] private List<AsteroidConfig> _bigAsteroidConfig;
        [SerializeField] private List<AsteroidConfig> _smallAsteroidConfig;
        [SerializeField] private TimedSpawner<Asteroid,AsteroidConfig>.Settings _asteroidSpawnerSettings;
        [SerializeField] private UFO _ufoPrefab;
        [SerializeField] private List<UFOConfig> _ufoConfig;
        [SerializeField] private TimedSpawner<UFO,UFOConfig>.Settings _ufoSpawnerSettings;
        [SerializeField] private EconomyConfig _economyConfig;

        public ShipConfig ShipConfig => _shipConfig;
        public Vector2 StartPosition => _startPosition;

        public Asteroid AsteroidPrefab => _asteroidPrefab;

        public List<AsteroidConfig> BigAsteroidConfig => _bigAsteroidConfig;

        public List<AsteroidConfig> SmallAsteroidConfig => _smallAsteroidConfig;

        public TimedSpawner<Asteroid,AsteroidConfig>.Settings AsteroidSpawnerSettings => _asteroidSpawnerSettings;

        public TimedSpawner<UFO, UFOConfig>.Settings UfoSpawnerSettings => _ufoSpawnerSettings;

        public List<UFOConfig> UfoConfig => _ufoConfig;

        public UFO UFOprefab => _ufoPrefab;

        public EconomyConfig EconomyConfig => _economyConfig;
    }
}
