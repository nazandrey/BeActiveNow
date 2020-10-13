using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class Moveable : PlayerAction
    {
        public float speed;
        public float moveThreshold;

        private void FixedUpdate()
        {
            var translation = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
            
            if (Math.Abs(translation) > moveThreshold)
            {
                InvokeActivated();
                transform.Translate(translation, 0, 0);
            }
        }
    }
}