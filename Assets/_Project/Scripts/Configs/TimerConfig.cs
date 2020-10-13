using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "TimerConfig", menuName = "TimerConfig", order = 0)]
    public class TimerConfig : ScriptableObject
    {
        public float timeout;
    }
}