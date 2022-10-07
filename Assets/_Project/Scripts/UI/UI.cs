using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suli.Asteroids
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private StatusPanelUI _statusPanelUI;
        [SerializeField] private EndScreenUI _endScreenUI;
        public StatusPanelUI StatusPanelUI => _statusPanelUI;

        public EndScreenUI EndScreenUI => _endScreenUI;
    }   
}
