using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame2.Movements
{

    public class Climbing : MonoBehaviour
    {
        [SerializeField] float climbSpeed = 5f;
        Rigidbody2D _rigidbody2D;
        public Rigidbody2D Rigidbody => _rigidbody2D;
        public bool IsClimbing { get; set; }

        private void Awake()
        {

            _rigidbody2D = GetComponent<Rigidbody2D>();

        }

        public void ClimbAction(float vertical)
        {

            if (IsClimbing)
            {
                transform.Translate(Vector2.up * vertical * Time.deltaTime * climbSpeed);
            }

        }

    }


}

