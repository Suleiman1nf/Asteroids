using System.Collections;
using UnityEngine;
using Suli.Utils;

namespace Suli.Asteroids
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private UI _ui;
        [SerializeField] private GameConfig _config;
        [SerializeField] private Ship.ShipFactory _shipFactory;
        [SerializeField] private PoolsContainer _pools;

        private SpawnersContainer _spawners;

        private readonly Score _score = new Score();
        
        private Camera _cam;
        private Ship _ship;
        private ShipUI _shipUI;
        
        private void Start()
        {
            SetWorldBorders();
            InitShip();
            _pools.Init(_config.ShipConfig.BulletPrefab, _config.UFOprefab, _config.AsteroidPrefab);
            _spawners = new SpawnersContainer(_config, _pools, _ship.transform);
            InitUI();
            SetGameLogic();
        }

        private void SetGameLogic()
        {
            SetSmallAsteroidsSpawnLogic();
            SetEconomyLogic();
        }

        private void SetSmallAsteroidsSpawnLogic()
        {
            _spawners.BigAsteroidsSpawner.OnDestroyObject += (asteroid)=>_spawners.SmallAsteroidsSpawnLogic.Spawn(new PointPositioner(asteroid.transform.localPosition));
        }

        private void SetEconomyLogic()
        {
            _spawners.SmallAsteroidsSpawner.OnDestroyObject += (_)=>AddScore(_config.EconomyConfig.SmallAsteroidCoins);
            _spawners.BigAsteroidsSpawner.OnDestroyObject += (_)=>AddScore(_config.EconomyConfig.BigAsteroidCoins);
            _spawners.UfoSpawner.OnDestroyObject += (_)=>AddScore(_config.EconomyConfig.UfoCoins);
        }

        private void InitShip()
        {
            _ship = _shipFactory.Create(
                position: _config.StartPosition,
                shipConfig: _config.ShipConfig,
                pool: _pools.BulletPool,
                onDead: () => { StartCoroutine(LoseGame());}
            );
        }

        private void InitUI()
        {
            _shipUI = new ShipUI(_ship.ShipStatusProvider, _ui.StatusPanelUI);
        }

        private void SetWorldBorders()
        {
            _cam = Camera.main;
            Vector2 screenSize = Utility.GetScreenSizeInWorldSpace(_cam);
            Borders.SetBorders(screenSize.x, screenSize.y);
        }

        private IEnumerator LoseGame()
        {
            _ui.EndScreenUI.Show();
            _ship.gameObject.SetActive(false);
            _ui.EndScreenUI.SetScore(_score.Count);
            yield return new WaitWhile(()=>_ui.EndScreenUI.gameObject.activeSelf);
            _ship.OnRestart();
            _ship.transform.localPosition = _config.StartPosition;
            _score.Reset();
            _ship.gameObject.SetActive(true);
        }

        private void AddScore(int value)
        {
            _score.AddScore(value);
        }

        private void Update()
        {
            _spawners.BigAsteroidsSpawnLogic.Update(Time.deltaTime);
            _spawners.TimedUFOSpawner.Update(Time.deltaTime);
            _shipUI.Update(Time.deltaTime);
        }
    }
}
