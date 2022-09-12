using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame2.Movements
{

    public class Mover : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 3f;

        public void HorizontalMove(float horizontal)
        {

            transform.Translate(Vector2.right * horizontal * Time.deltaTime * _moveSpeed);

        }
    }

}


