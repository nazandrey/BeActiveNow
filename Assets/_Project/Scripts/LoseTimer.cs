using System;
using System.Collections;
using UnityEngine;

namespace _Project.Scripts
{
    public class LoseTimer : MonoBehaviour
    {
        public float loseTimeout;
        public Moveable player;

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
        }

        private void StartTimer()
        {
            _timer = StartCoroutine(TimerCoroutine());
        }

        private IEnumerator TimerCoroutine()
        {
            yield return new WaitForSeconds(loseTimeout);
            print("Lose");
            SceneLoader.Instance.LoadFirstLevel();
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