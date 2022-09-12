using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ProjectGame2.Managers;

namespace ProjectGame2.Uis
{

    public class DisplayScore : MonoBehaviour
    {

        TextMeshProUGUI _scoretext;

        private void Awake()
        {

            _scoretext = GetComponent<TextMeshProUGUI>();

        }

        private void OnEnable()
        {
            GameManager.Instance.OnScoreChanged += ScoreBar;
        }   

        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= ScoreBar;
        }

        public void ScoreBar(int score){

            _scoretext.text = score.ToString();

        }

    }

}


