﻿using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class PlayerLevel
    {
        public static PlayerLevel Instance = new PlayerLevel();
        public event Action<int> LevelUp;

        public int CurrLevel { get; private set; } = 0;
        public int MaxLevel { get; private set; } = 1;
        public bool IsMaxLevel => CurrLevel == MaxLevel;

        private PlayerLevel(){}

        public void UpLevel()
        {
            Debug.Log("UpLevel from " + CurrLevel + " to " + (CurrLevel + 1));
            CurrLevel++;
            LevelUp?.Invoke(CurrLevel);
        }
        
        public void Reset()
        {
            CurrLevel = 0;
        }
    }
}