using System.Collections;
using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts
{
    public abstract class Timer : MonoBehaviour
    {
        public TimerConfig timerConfig;

        private Coroutine _timer;

        protected virtual void Awake()
        {
            GameOverEventRaiser.GameOver += OnGameOver;
        }
        
        protected virtual void Start()
        {
            StartTimer();
        }

        protected virtual void OnDestroy()
        {
            if (_timer != null)
                DestroyCurrTimer();
            GameOverEventRaiser.GameOver -= OnGameOver;
        }

        protected virtual void OnGameOver(bool isWin)
        {
            DestroyCurrTimer();
        }

        protected void StartTimer()
        {
            _timer = StartCoroutine(TimerCoroutine());
        }

        protected abstract IEnumerator TimerCoroutine();

        protected void DestroyCurrTimer()
        {
            StopCoroutine(_timer);
            _timer = null;
        }
    }
}