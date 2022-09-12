using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using ProjectGame2.Inputs;
using ProjectGame2.Abstracts.Inputs;
using ProjectGame2.Movements;
using ProjectGame2.Animations;
using ProjectGame2.Combats;
using ProjectGame2.Uis;
using ProjectGame2.ExtentionMethods;



namespace ProjectGame2.Controllers
{

    public class PlayerController : MonoBehaviour
    {

        float _horizontal;
        float _vertical;
        bool _isJump;

        PlayerAnimation _playeranimation;
        IPlayerInput _input;
        Mover _mover;
        Jump _jumpaction;
        FlipPlayer _flipplayer;
        OnGround _onGround;
        Climbing _climbing;
        Health _health;
        Damage _damage;
        AudioSource _audioSource;

        [SerializeField] AudioClip deadClip;
        public static event Action<AudioClip> OnPlayerDead;
        
        private void Awake()
        {
            _playeranimation = GetComponent<PlayerAnimation>();
            _mover = GetComponent<Mover>();
            _input = new PcInput();
            _jumpaction = GetComponent<Jump>();
            _flipplayer = GetComponent<FlipPlayer>();
            _onGround = GetComponent<OnGround>();
            _climbing = GetComponent<Climbing>();
            _health = GetComponent<Health>();
            _damage = GetComponent<Damage>();
            _audioSource = GetComponent<AudioSource>();
            
        }

        private void OnEnable()
        {

            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();

            if (gameCanvas != null)
            {

                _health.OnDead += gameCanvas.ShowGameOverPanel;

                //Health Bar event ekleme islemleri
                DisplayHealth displayHealth = gameCanvas.GetComponentInChildren<DisplayHealth>();
                _health.OnHealthChanged += displayHealth.HealthBar;
                
            }

            _health.OnHealthChanged += PlayerOnHit;
            _health.OnDead += () => OnPlayerDead.Invoke(deadClip);
            //Yukarıdaki işlemde bir event diğer bir eventi çalıştırıyor, böylece OnDead eventinin parametresini değiştirmeden işlemimizi tamamlıyoruz.
        }

        private void Update()
        {

            if (_health.IsDead) return;

            _horizontal = _input.Horizontal;
            _vertical = _input.Vertical;

            if (_input.IsJumpButton && _onGround.IsOnGround && !_climbing.IsClimbing)
            {
                _isJump = true;
            }

            _playeranimation.MoveAnimation(_horizontal);
            _playeranimation.JumpAnimation(!_onGround.IsOnGround && _jumpaction.IsJump);
            _playeranimation.ClimbAnimation(_climbing.IsClimbing);

        }

        private void FixedUpdate()
        {
            _climbing.ClimbAction(_vertical);
            _mover.HorizontalMove(_horizontal);
            _flipplayer.Flip(_horizontal);

            if (_isJump)
            {
                _jumpaction.JumpAction();
                _isJump = false;
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            
            //Enemynin health compenantını alıp oraya hasar gönderiyor
            Health health = collision.ObjectHealth();

            if (health != null && collision.WasHitTopSide())
            {
                
                health.TakeHit(_damage);
                _jumpaction.JumpAction();

            }

        }


        private void PlayerOnHit(int currentHealth, int maxHealth)
        {
            
            if(currentHealth == maxHealth) return;

            _audioSource.Play();

        }

    }

}

