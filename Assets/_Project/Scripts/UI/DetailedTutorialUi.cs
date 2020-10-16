using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class DetailedTutorialUi : MonoBehaviour
    {
        public PauseSetter pauseSetter;
        public GameObject root;
        public Text text;

        private const string TutorialHidePrefsKey = nameof(TutorialHidePrefsKey);

        private void Awake()
        {
            PlayerLevel.Instance.LevelUp += OnLevelUp;
        }

        private void Start()
        {
            root.SetActive(false);
            if (PlayerLevel.Instance.CurrLevel == 0)
                ShowTutorialText(0);
        }

        private void OnDestroy()
        {
            PlayerLevel.Instance.LevelUp -= OnLevelUp;
        }

        private void OnLevelUp(int currLevel)
        {
            if (currLevel > 1)
                return;

            ShowTutorialText(currLevel);
        }

        private void ShowTutorialText(int currLevel)
        {
            if (PlayerPrefs.GetInt(TutorialHidePrefsKey) == 1)
                return;

            ShowTutorialTextOnly(currLevel);
                
            pauseSetter.Pause();
            pauseSetter.gameObject.SetActive(false);
        }
        
        private void ShowTutorialTextOnly(int currLevel)
        {
            if (currLevel == 0)
            {
                text.text =
                    "Do action above to avoid deep thinking and to seize the day";
            }
            else if (currLevel == 1)
            {
                text.text =
                    "Now you need to do ALL actions above (it has reset timer) to seize the day";
            }

            text.text += "\n\nNod if you understand";
            root.SetActive(true);
        }
        
        public void ToggleTutorial(bool isShow)
        {
            PlayerPrefs.SetInt(TutorialHidePrefsKey, isShow ? 0 : 1);
            PlayerPrefs.Save();
        }

        public void OnTutorialCompleted()
        {
            pauseSetter.gameObject.SetActive(true);
            pauseSetter.Unpause();
            root.SetActive(false);
        }
    }
}