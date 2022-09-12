using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ProjectGame2.Uis
{

    public class DisplayHealth : MonoBehaviour
    {

        TextMeshProUGUI _healthText;

        private void Awake()
        {

            _healthText = GetComponent<TextMeshProUGUI>();

        }

        public void HealthBar(int currentHealth, int maxHealth)
        {

            _healthText.text = currentHealth.ToString();

        }

    }

}


