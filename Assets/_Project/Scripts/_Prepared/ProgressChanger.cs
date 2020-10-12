using System;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts
{
    public class ProgressChanger : SingletonUndestroyable<ProgressChanger>
    {
        private ProgressBox progressBox;
        
        private void Awake()
        {
            progressBox = FindObjectOfType<ProgressBox>();
        }
        
        private void Start()
        {
            /*var itemsCount = GameManager.Instance.currLevelConfig.FirstLocationItems.Length +
                             GameManager.Instance.currLevelConfig.SecondLocationItems.Length;
            progressBox.InitProgressAmount(itemsCount);*/
        }
    }
}