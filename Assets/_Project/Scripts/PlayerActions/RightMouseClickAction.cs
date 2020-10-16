using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class RightMouseClickAction : PlayerAction
    {
        private void Update()
        {
            //Check that game is started
            if (Input.GetMouseButtonDown(1))
            {
                AudioManager.Instance.Play("Snap2");
                InvokeActivated();
            }
        }
    }
}