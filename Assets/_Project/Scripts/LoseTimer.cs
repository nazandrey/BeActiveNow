using System;
using System.Collections;
using _Project.Scripts.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class LoseTimer : MonoBehaviour
    {
        public LoseTimerConfig loseTimerConfig;
        public Moveable player;
        public GameObject gameOverUi;
        public Button gameOverButton;

        private Coroutine _timer;

        private void Start()
        {
            StartTimer();
        }

        private void Update()
        {
            if (player.IsMoving)
                ResetTimer();
        }

        private void OnDestroy()
        {
            if (_timer != null)
            {
                DestroyCurrTimer();
            }
            gameOverButton.onClick.RemoveListener(SceneLoader.Instance.LoadFirstLevel);
        }

        private void StartTimer()
        {
            _timer = StartCoroutine(TimerCoroutine());
        }

        private IEnumerator TimerCoroutine()
        {
            yield return new WaitForSeconds(loseTimerConfig.loseTimeout);
            print("Lose");
            gameOverUi.SetActive(true);
            gameOverButton.onClick.AddListener(SceneLoader.Instance.LoadFirstLevel);
        }

        private void ResetTimer()
        {
            DestroyCurrTimer();
            StartTimer();
        }

        private void DestroyCurrTimer()
        {
            StopCoroutine(_timer);
            _timer = null;
        }
    }
}