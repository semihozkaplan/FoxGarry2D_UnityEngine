using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame2.Controllers;
using ProjectGame2.Combats;
using ProjectGame2.Movements;
using ProjectGame2.Animations;
using ProjectGame2.ExtentionMethods;


namespace ProjectGame2.Controllers
{

    public class EnemyController : MonoBehaviour
    {

        Mover _mover;
        PlayerAnimation _playerAnimation;
        Health _health;
        FlipPlayer _flipplayer;
        OnEdge _onedge;
        Damage _damage;
        AudioSource _audioSource;
    
        [SerializeField] AudioClip enemyDeadClip;
        public static event Action<AudioClip> OnEnemyDead;

        float _direction;

        private void Awake()
        {

            _mover = GetComponent<Mover>();
            _playerAnimation = GetComponent<PlayerAnimation>();
            _health = GetComponent<Health>();
            _flipplayer = GetComponent<FlipPlayer>();
            _onedge = GetComponent<OnEdge>();
            _damage = GetComponent<Damage>();
            _audioSource = GetComponent<AudioSource>();
            _direction = 1f;
        }

        private void OnEnable()
        {
            _health.OnDead += DeadAction;
            _health.OnDead += () => OnEnemyDead.Invoke(enemyDeadClip);
        }

        private void FixedUpdate()
        {

            if (_health.IsDead) return;

            _mover.HorizontalMove(_direction);
            _playerAnimation.MoveAnimation(_direction);

        }

        private void LateUpdate()
        {

            if (_onedge.ReachedEdge())
            {

                _direction *= -1f;
                _flipplayer.Flip(_direction);

            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //Playerin health compenantını alıp oraya hasar gönderiyor
            Health health = collision.ObjectHealth();

            if (health != null && collision.WasHitLeftOrRightSide())
            {

                health.TakeHit(_damage);

            }
        }
        private void DeadAction()
        {

            StartCoroutine(DeadActionAsync());

        }


        private IEnumerator DeadActionAsync()
        {

            _playerAnimation.DeadAnimation();
            yield return new WaitForSeconds(0.5f);
            Destroy(this.gameObject);

        }


        


    }

}


