using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class LeftMouseClickAction : PlayerAction
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                InvokeActivated();
            }
        }
    }
}