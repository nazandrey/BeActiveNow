using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class LevelUpSlider : MonoBehaviour
    {
        public Color fromColor;
        public Color toColor;
        public Image fillImage;
        public RectTransform handle;
        
        private float _progressTimeout;
        private float _currProgress;
        
        public void Init(float progressTimeout)
        {
            _currProgress = 0;
            _progressTimeout = progressTimeout;
        }
        
        private void Update()
        {
            if (_currProgress < _progressTimeout)
            {
                _currProgress += Time.deltaTime;
                var progressNormalized = _currProgress / _progressTimeout;
                fillImage.fillAmount = progressNormalized;
                fillImage.color = Color.LerpUnclamped(fromColor, toColor, progressNormalized);
                handle.anchorMin = new Vector2(progressNormalized, handle.anchorMin.y);
                handle.anchorMax = new Vector2(progressNormalized, handle.anchorMax.y);
            }
        }
    }
}