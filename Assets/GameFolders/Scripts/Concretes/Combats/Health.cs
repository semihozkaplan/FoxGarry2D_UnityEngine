using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ProjectGame2.Combats
{

    public class Health : MonoBehaviour
    {

        [SerializeField] int maxHealth = 3;
        [SerializeField] int currentHealth = 0;
        
        public bool IsDead => currentHealth < 1;
        public event Action<int,int> OnHealthChanged;
        public event Action OnDead;

        private void Awake()
        {

            currentHealth = maxHealth;

        }

        private void Start()
        {

            OnHealthChanged?.Invoke(currentHealth,maxHealth);

        }


        public void TakeHit(Damage damage)
        {


            if (!IsDead)
            {
                currentHealth -= damage.HitDamage;
            }


            if (IsDead)
            {

                OnDead?.Invoke();

            }

            else
            {

                OnHealthChanged?.Invoke(currentHealth,maxHealth);

            }

        }
    }


}

