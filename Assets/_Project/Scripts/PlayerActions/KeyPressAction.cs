using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace _Project.Scripts
{
    public class KeyPressAction : PlayerAction
    {
        public KeyCode keyCode;
        
        private void Update()
        {
            if (Input.GetKeyDown(keyCode))
            {
                AudioManager.Instance.Play("KeyPress");
                InvokeActivated();
            }
        }
    }
}