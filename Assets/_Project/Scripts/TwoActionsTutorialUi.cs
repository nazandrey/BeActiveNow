using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class TwoActionsTutorialUi : MonoBehaviour
    {
        public PauseSetter pauseSetter;
        public GameObject root;
        
        private void Awake()
        {
            PlayerLevel.Instance.LevelUp += OnLevelUp;
        }

        private void Start()
        {
            root.SetActive(false);
        }

        private void OnDestroy()
        {
            PlayerLevel.Instance.LevelUp -= OnLevelUp;
        }

        private void OnLevelUp(int currLevel)
        {
            if (currLevel == 1)
            {
                pauseSetter.Pause();
                root.SetActive(true);
            }
        }
        
        public void OnTutorialCompleted()
        {
            pauseSetter.Unpause();
            root.SetActive(false);
        }
    }
}