using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class TutorialActionContainerUi : MonoBehaviour
    {
        public Text text;
        public Image resetTimeoutUi;
        
        private float _resetTimeout;
        private float _currResetTime;
        private string _playerActionName;

        public void Init(string text, float resetTimeout, string playerActionName)
        {
            this.text.text = text;
            _resetTimeout = resetTimeout;
            _currResetTime = _resetTimeout;
            _playerActionName = playerActionName;
        }

        private void Start()
        {
            PlayerAction.Activated += OnPlayerActionActivated;
        }

        private void Update()
        {
            if (_currResetTime > 0)
            {
                _currResetTime -= Time.deltaTime;
                resetTimeoutUi.fillAmount = _currResetTime / _resetTimeout;
            }
        }

        private void OnDestroy()
        {
            PlayerAction.Activated -= OnPlayerActionActivated;
        }

        private void OnPlayerActionActivated(string playerActionName)
        {
            if (_playerActionName == playerActionName)
                _currResetTime = _resetTimeout;
        }
    }
}