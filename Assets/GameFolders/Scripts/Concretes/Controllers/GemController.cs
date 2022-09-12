using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using ProjectGame2.Managers;

namespace ProjectGame2.Controllers
{

    public class GemController : MonoBehaviour
    {

        [SerializeField] int score = 1;
        [SerializeField] AudioClip scoreClip;

        public static event Action<AudioClip> OnScoreSound;

        private void OnTriggerEnter2D(Collider2D collision) {
            
            PlayerController player = collision.GetComponent<PlayerController>();

            if(player != null){
                
                GameManager.Instance.IncreaseScore(score);
                OnScoreSound.Invoke(scoreClip);
                Destroy(this.gameObject);

            }

        }

    }

}


