using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame2.Movements
{

    [RequireComponent(typeof(Rigidbody2D))]

    public class Jump : MonoBehaviour
    {
        Rigidbody2D _rigidbody2D;
        [SerializeField] float jumpForce = 300f;
        public bool IsJump => _rigidbody2D.velocity !=  Vector2.zero;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void JumpAction()
        {

            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * jumpForce);

        }

    }


}

