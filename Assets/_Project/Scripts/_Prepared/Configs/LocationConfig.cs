using UnityEngine;

namespace _Project.Scripts
{
    [CreateAssetMenu(fileName = "LocationConfig", menuName = "LocationConfig", order = 0)]
    public class LocationConfig : ScriptableObject
    {
        public string upSceneName;
        public string rightSceneName;
        public string downSceneName;
        public string leftSceneName;
    }
}