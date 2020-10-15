using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    [RequireComponent(typeof(Slider))]
    public class LevelUpSlider : MonoBehaviour
    {
        private Slider _slider;
        private float _progressTimeout;
        private float _currProgress;
        
        public void Init(float progressTimeout)
        {
            _currProgress = 0;
            _progressTimeout = progressTimeout;
        }

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }
        
        private void Update()
        {
            if (_currProgress < _progressTimeout)
            {
                _currProgress += Time.deltaTime;
                _slider.value = _currProgress / _progressTimeout;
            }
        }
    }
}