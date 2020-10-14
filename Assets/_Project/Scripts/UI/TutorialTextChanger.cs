using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class TutorialTextChanger : MonoBehaviour
    {
        public Text textPrefab;
        public Transform textsRoot;
        public GameObject connectorObject;

        private LoseTimer _loseTimer;
        
        private void Awake()
        {
            _loseTimer = FindObjectOfType<LoseTimer>();
            _loseTimer.LoseConditionAdded += OnLoseConditionAdded;
        }

        private void OnDestroy()
        {
            _loseTimer.LoseConditionAdded -= OnLoseConditionAdded;
        }

        private void OnLoseConditionAdded(string playerActionName)
        {
            var textObject = Instantiate(textPrefab, textsRoot, false);
            textObject.text = GetTutorialText(playerActionName);
            connectorObject.SetActive(textsRoot.childCount > 1);
        }

        private string GetTutorialText(string playerActionName)
        {
            switch (playerActionName)
            {
                case nameof(Moveable):
                    return "Move <= =>";
                case nameof(Jumpable):
                    return "Jump (space)";
                case nameof(LeftMouseClickAction):
                    return "Sing (LMB)";
                default:
                    throw new ArgumentException(playerActionName);
            }
        }
    }
}