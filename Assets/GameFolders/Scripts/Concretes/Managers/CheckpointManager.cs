using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame2.Controllers;
using ProjectGame2.Combats;
using System.Linq;

namespace ProjectGame2.Managers
{

    public class CheckpointManager : MonoBehaviour
    {

        [SerializeField] CheckpointController[] _checkpointControllers;
        Health _health;

        private void Awake()
        {
            _checkpointControllers = GetComponentsInChildren<CheckpointController>();
            _health = FindObjectOfType<PlayerController>().GetComponent<Health>();
        }

        private void Start()
        {

            _health.OnHealthChanged += HandleHealthChange;

        }

        private void HandleHealthChange(int currentHealth, int maxHealth)
        {
            
                _health.transform.position = _checkpointControllers.LastOrDefault(x => x.IsPassed).transform.position;
                //En son triggerlanan checkpoint noktasının transform.position bilgisini bana değer olarak dön demiş olduk.

        }
    }


}

