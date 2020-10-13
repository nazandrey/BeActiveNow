using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class LoseTimer : Timer
    {
        private Dictionary<string, bool> ResetConditionMet = new Dictionary<string, bool>();

        protected override void Awake()
        {
            base.Awake();
            PlayerAction.Activated += OnPlayerActionActivated;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            UnsubscribePlayerActions();
        }

        protected override void OnGameOver(bool isWin)
        {
            base.OnGameOver(isWin);
            UnsubscribePlayerActions();
        }

        private void UnsubscribePlayerActions()
        {
            PlayerAction.Activated -= OnPlayerActionActivated;
        }

        protected override IEnumerator TimerCoroutine()
        {
            yield return new WaitForSeconds(timerConfig.timeout);
            Debug.Log("Lose");
            GameOverEventRaiser.Instance.InvokeGameOver(false);
        }

        private void ResetTimer()
        {
            DestroyCurrTimer();
            StartTimer();
        }

        public void AddLoseResetCondition(PlayerAction playerAction)
        {
            var playerActionName = playerAction.GetName();
            ResetConditions();
            ResetConditionMet.Add(playerActionName, false);
        }

        private void OnPlayerActionActivated(string playerActionName)
        {
            if (!ResetConditionMet.ContainsKey(playerActionName))
                return;
            
            ResetConditionMet[playerActionName] = true;
            if (ResetConditionMet.All(x => x.Value))
            {
                ResetConditions();
                ResetTimer();
            }
        }

        private void ResetConditions()
        {
            ResetConditionMet = ResetConditionMet
                .ToDictionary(x => x.Key, x => false);
        }
    }
}