using System.Collections;
using _Project.Scripts.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class LevelUpTimer : Timer
    {
        public LevelUpSlider slider;
        
        protected override void Start()
        {
            base.Start();
            slider.Init(timerConfig.timeout);
        }
        
        protected override IEnumerator TimerCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(timerConfig.timeout);
                if (PlayerLevel.Instance.IsMaxLevel)
                {
                    //show win
                    Debug.Log("Win");
                    GameOverEventRaiser.Instance.InvokeGameOver(true);
                }
                else
                {
                    PlayerLevel.Instance.UpLevel();
                    slider.Init(timerConfig.timeout);
                }
            }
        }
    }
}