using TMPro;
using UnityEngine;

namespace Suli.Asteroids
{
    public class EndScreenUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreTMPText;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void SetScore(int value)
        {
            scoreTMPText.SetText(value.ToString());
        }
    }
}