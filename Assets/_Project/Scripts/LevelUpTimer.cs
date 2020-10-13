using System.Collections;
using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts
{
    public class LevelUpTimer : Timer
    {
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
                }
            }
        }
    }
}