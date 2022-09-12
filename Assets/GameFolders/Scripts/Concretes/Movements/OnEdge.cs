using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame2.Movements
{

    [RequireComponent(typeof(Collider2D))]

    public class OnEdge : MonoBehaviour
    {

        [SerializeField] LayerMask _layerMask;
        Collider2D _collider2D;
        [SerializeField] float distance = 0.1f;

        float _xDirection;

        private void Awake()
        {

            _collider2D = GetComponent<Collider2D>();
            _xDirection = 1f;

        }

        public bool ReachedEdge()
        {

            float x = GetForwardXPosition();
            float y = _collider2D.bounds.min.y;

            Vector2 origin = new Vector2(x, y);
            
            Debug.DrawRay(origin, Vector2.down * distance, Color.red);
            
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, distance, _layerMask);


            if (hit.collider != null)
            {

                return false;

            }

            SwitchControlDirection();
            return true;

        }

        //Önce colliderın sol altına ışın çek sonra sağ alt tarafına ışın çek diyip tek tek check etmiş olduk.
        private float GetForwardXPosition()
        {

            return _xDirection == -1f ? _collider2D.bounds.min.x - distance : _collider2D.bounds.max.x + distance;

        }

        private void SwitchControlDirection()
        {

            _xDirection *= -1;

        }

    }


}

