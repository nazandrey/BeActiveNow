using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class YAction : PlayerAction
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                AudioManager.Instance.PlaySing();
                InvokeActivated();
            }
        }
    }
}