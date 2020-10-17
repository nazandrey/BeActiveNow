using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class TutorialTextChanger : MonoBehaviour
    {
        public TutorialActionContainerUi tutorialActionContainerUi;
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
            var tutorialActionContainerUiObject = Instantiate(tutorialActionContainerUi, textsRoot, false);
            tutorialActionContainerUiObject.Init(GetTutorialText(playerActionName), _loseTimer.timerConfig.timeout - 0.1f, playerActionName);
            connectorObject.SetActive(textsRoot.childCount > 1);
        }

        private string GetTutorialText(string playerActionName)
        {
            switch (playerActionName)
            {
                case nameof(Moveable):
                    return "Move (<- ->)";
                case nameof(Jumpable):
                    return "Jump (space)";
                case nameof(LeftMouseClickAction):
                    return "Snap (click)";
                case nameof(YAction):
                    return "Na-na-na (Press Y)";
                case nameof(KeyPressAction):
                    return "Push (Press P)";
                default:
                    throw new ArgumentException(playerActionName);
            }
        }
    }
}