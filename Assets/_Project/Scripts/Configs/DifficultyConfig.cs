using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "DifficultyConfig", menuName = "DifficultyConfig", order = 0)]
    public class DifficultyConfig : ScriptableObject
    {
        public TimerConfig loseTimerConfig;
        public TimerConfig levelUpConfig;
    }
}