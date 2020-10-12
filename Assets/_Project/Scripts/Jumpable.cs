using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace _Project.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))] 
    public class Jumpable : MonoBehaviour
    {
        public float jumpSpeed;
        
        private Rigidbody2D _rigidbody;
        private bool _isGrounded;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            //mb will work bad with touching other platforms from aside
            if (other.gameObject.layer == LayerMask.NameToLayer("Floor"))
                _isGrounded = true;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _isGrounded = false;
                _rigidbody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            }
        }
    }
}