using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class PlayerAction : MonoBehaviour
    {
        public event Action<string> Activated;
        
        protected void InvokeActivated()
        {
            Activated?.Invoke(GetType().Name);
        }
    }
}