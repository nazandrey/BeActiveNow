using System.Collections;
using _Project.Scripts.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class LevelUpTimer : Timer
    {
        public LevelUpSlider slider;

        protected override void Awake()
        {
            timerConfig = DifficultySetter.Instance.GetCurrLevelUpTimeConfig(PlayerLevel.Instance.CurrLevel);
            base.Awake();
        }

        protected override void Start()
        {
            slider.Init(timerConfig.timeout);
            base.Start();
        }
        
        protected override IEnumerator TimerCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(timerConfig.timeout);
                if (PlayerLevel.Instance.IsMaxLevel)
                {
                    GameOverEventRaiser.Instance.InvokeGameOver(true);
                }
                else
                {
                    PlayerLevel.Instance.UpLevel();
                    timerConfig = DifficultySetter.Instance.GetCurrLevelUpTimeConfig(PlayerLevel.Instance.CurrLevel);
                    slider.Init(timerConfig.timeout);
                }
            }
        }
    }
}