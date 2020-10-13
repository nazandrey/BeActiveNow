using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class GameOverEventRaiser
    {
        public static event Action<bool> GameOver;
            
        public static GameOverEventRaiser Instance = new GameOverEventRaiser();

        public void InvokeGameOver(bool isWin)
        {
            GameOver?.Invoke(isWin);
        }
    }
}