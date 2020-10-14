using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class GameOverUi : MonoBehaviour
    {
        public GameObject root;
        public Button button;
        public Text text;

        private void Awake()
        {
            GameOverEventRaiser.GameOver += OnGameOver;
        }

        private void Start()
        {
            root.SetActive(false);
        }

        private void OnGameOver(bool isWin)
        {
            text.text = $"You {(isWin ? "won!" : "lose!")}";
            root.SetActive(true);
            button.onClick.AddListener(SceneLoader.Instance.LoadFirstLevel);
        }

        private void OnDestroy()
        {
            GameOverEventRaiser.GameOver -= OnGameOver;
            button.onClick.RemoveListener(SceneLoader.Instance.LoadFirstLevel);
        }
    }
}