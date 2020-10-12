using System;
using _Project.Scripts.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField] 
        private LocationConfig locationConfig;
        
        [SerializeField] 
        private Button upButton;
        [SerializeField] 
        private Button rightButton;
        [SerializeField] 
        private Button downButton;
        [SerializeField] 
        private Button leftButton;

        private void Start()
        {
            upButton.gameObject.SetActive(locationConfig.upSceneName.NotEmpty());
            rightButton.gameObject.SetActive(locationConfig.rightSceneName.NotEmpty());
            downButton.gameObject.SetActive(locationConfig.downSceneName.NotEmpty());
            leftButton.gameObject.SetActive(locationConfig.leftSceneName.NotEmpty());
            if (locationConfig.upSceneName.NotEmpty())
                BindButton(upButton, locationConfig.upSceneName);
            if (locationConfig.rightSceneName.NotEmpty())
                BindButton(rightButton, locationConfig.rightSceneName);
            if (locationConfig.downSceneName.NotEmpty())
                BindButton(downButton, locationConfig.downSceneName);
            if (locationConfig.leftSceneName.NotEmpty())
                BindButton(leftButton, locationConfig.leftSceneName);
        }

        private void BindButton(Button button, string sceneName)
        {
            button.onClick.AddListener(() =>
            {
                SceneLoader.Instance.LoadScene(sceneName);
            });
        }
    }
}