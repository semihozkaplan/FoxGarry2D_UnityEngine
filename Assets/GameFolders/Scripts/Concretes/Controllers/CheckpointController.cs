using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame2.Controllers
{

    public class CheckpointController : MonoBehaviour
    {
        
        bool _isPassed = false;

        public bool IsPassed => _isPassed;

        private void OnTriggerEnter2D(Collider2D collision) {
            
            PlayerController player = collision.GetComponent<PlayerController>();

            if(player != null){

                _isPassed = true;

            }

        }

    }


}

