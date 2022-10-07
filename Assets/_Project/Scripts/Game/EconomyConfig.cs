using UnityEngine;

namespace Suli.Asteroids
{
    [CreateAssetMenu(menuName = "Asteroids/Create EconomyConfig", fileName = "EconomyConfig", order = 0)]
    public class EconomyConfig : ScriptableObject
    {
        [Header("Economy")] 
        [SerializeField] private int smallAsteroidCoins;
        [SerializeField] private int bigAsteroidCoins;
        [SerializeField] private int ufoCoins;

        public int SmallAsteroidCoins => smallAsteroidCoins;

        public int BigAsteroidCoins => bigAsteroidCoins;

        public int UfoCoins => ufoCoins;
    }
}