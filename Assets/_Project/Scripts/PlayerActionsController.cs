using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class PlayerActionsController : MonoBehaviour
    {
        public PlayerAction[] PlayerActions;
        public LoseTimer loseTimer;
        
        private void Awake()
        {
            PlayerLevel.Instance.Reset();
            PlayerLevel.Instance.SetMaxLevel(PlayerActions.Length - 1);
            PlayerLevel.Instance.LevelUp += OnLevelUp;
        }

        private void Start()
        {
            ApplyLevel(PlayerLevel.Instance.CurrLevel);
        }

        private void OnDestroy()
        {
            PlayerLevel.Instance.LevelUp -= OnLevelUp;
        }

        private void OnLevelUp(int currLevel)
        {
            ApplyLevel(currLevel);
        }

        private void ApplyLevel(int currLevel)
        {
            loseTimer.AddLoseResetCondition(PlayerActions[currLevel]);
        }
    }
}