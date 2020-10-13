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
        public GameObject gameOverUi;
        public Button gameOverButton;

        private Dictionary<string, bool> ResetConditionMet = new Dictionary<string, bool>();

        private List<PlayerAction> PlayerActionsToUnsubscribe = new List<PlayerAction>();

        protected override void OnDestroy()
        {
            base.OnDestroy();

            UnsubscribePlayerActions();
            
            gameOverButton.onClick.RemoveListener(SceneLoader.Instance.LoadFirstLevel);
        }

        protected override void OnGameOver(bool isWin)
        {
            base.OnGameOver(isWin);
            UnsubscribePlayerActions();
        }

        private void UnsubscribePlayerActions()
        {
            foreach (var playerAction in PlayerActionsToUnsubscribe)
                playerAction.Activated -= OnPlayerActionActivated;
        }

        protected override IEnumerator TimerCoroutine()
        {
            yield return new WaitForSeconds(timerConfig.timeout);
            Debug.Log("Lose");
            gameOverUi.SetActive(true);
            gameOverButton.onClick.AddListener(SceneLoader.Instance.LoadFirstLevel);
            GameOverEventRaiser.Instance.InvokeGameOver(false);
        }

        private void ResetTimer()
        {
            DestroyCurrTimer();
            StartTimer();
        }

        public void AddLoseResetCondition(PlayerAction playerAction)
        {
            var playerActionName = playerAction.GetType().Name;
            playerAction.Activated += OnPlayerActionActivated;
            PlayerActionsToUnsubscribe.Add(playerAction);
            ResetConditionMet.Add(playerActionName, false);
        }

        private void OnPlayerActionActivated(string playerActionName)
        {
            ResetConditionMet[playerActionName] = true;
            if (ResetConditionMet.All(x => x.Value))
            {
                ResetConditionMet = ResetConditionMet
                    .ToDictionary(x => x.Key, x => false);
                ResetTimer();
            }
        }
    }
}