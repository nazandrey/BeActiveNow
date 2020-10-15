using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class LeftMouseClickAction : PlayerAction
    {
        private void Update()
        {
            //Check that game is started
            if (Input.GetMouseButtonDown(0))
            {
                AudioManager.Instance.PlaySing();
                InvokeActivated();
            }
        }
    }
}