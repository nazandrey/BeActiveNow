using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class PlayerAction : MonoBehaviour
    {
        public static event Action<string> Activated;

        public string GetName()
        {
            return GetType().Name;
        }
        
        protected void InvokeActivated()
        {
            Activated?.Invoke(GetName());
        }
    }
}