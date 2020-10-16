using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts
{
    public class DifficultySetter : SingletonDestroyable<DifficultySetter>
    {
        public DifficultyConfig[] difficultyConfigs;

        private int _difficulty;
        
        public void SetDifficulty(int difficulty)
        {
            _difficulty = difficulty;
        }

        public TimerConfig GetCurrLoseTimeConfig()
        {
            return difficultyConfigs[_difficulty].loseTimerConfig;
        }
        
        public TimerConfig GetCurrLevelUpTimeConfig(int level)
        {
            if (_difficulty == 1 && level < 2)
            {
                return difficultyConfigs[_difficulty - 1].levelUpConfig;
            } 
            else if (_difficulty == 2 && level < 3)
            {
                return difficultyConfigs[_difficulty - 2].levelUpConfig;
            }
            return difficultyConfigs[_difficulty].levelUpConfig;
        }
    }
}