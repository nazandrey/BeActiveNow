using UnityEngine;

namespace _Project.Scripts
{
    public class PlaySound : MonoBehaviour
    {
        public void Play(string soundName)
        {
            AudioManager.Instance.Play(soundName);
        }
    }
}