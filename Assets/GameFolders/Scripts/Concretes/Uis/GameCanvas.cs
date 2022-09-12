using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame2.Managers;
using System;

namespace ProjectGame2.Uis
{

    public class GameCanvas : MonoBehaviour
    {

        [SerializeField] GameObject gameplayObject;
        [SerializeField] GameOverPanel gameOverPanel;

        private void OnEnable()
        {
            GameManager.Instance.OnSceneChanged += HandleGameSceneChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnSceneChanged -= HandleGameSceneChanged;
        }


        private void HandleGameSceneChanged(bool isActive)
        {
            if (!isActive == gameplayObject.gameObject.activeSelf) return;

            gameplayObject.gameObject.SetActive(!isActive);

        }

        public void ShowGameOverPanel()
        {

            gameOverPanel.gameObject.SetActive(true);

        }


    }

}


