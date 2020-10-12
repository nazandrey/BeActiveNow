using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "LoseTimerConfig", menuName = "LoseTimerConfig", order = 0)]
    public class LoseTimerConfig : ScriptableObject
    {
        public float loseTimeout;
    }
}