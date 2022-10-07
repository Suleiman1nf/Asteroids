using System;

namespace Suli.Asteroids
{
    public class Score
    {
        private int _count;
        public event Action<int> OnChanged;

        public int Count
        {
            get => _count;
            private set
            {
                _count = value;
                OnChanged?.Invoke(_count);
            }
        }

        public void AddScore(int value)
        {
            Count+=value;
        }

        public void Reset()
        {
            Count = 0;
        }

        public override string ToString()
        {
            return _count.ToString();
        }
    }
}