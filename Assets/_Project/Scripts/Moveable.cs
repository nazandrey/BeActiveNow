using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class Moveable : MonoBehaviour
    {
        public float speed;
        public float moveThreshold;

        public bool IsMoving { get; private set; }

        private void FixedUpdate()
        {
            var translation = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
            
            if (Math.Abs(translation) > moveThreshold)
            {
                IsMoving = true;
                transform.Translate(translation, 0, 0);
            }
            else
            {
                IsMoving = false;
            }
        }
    }
}