using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace ProjectGame2.Managers
{

    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance { get; private set; }

        [SerializeField] float delayLevelTime = 1f;

        public event Action<bool> OnSceneChanged;

        public event Action<int> OnScoreChanged;

        [SerializeField] int score;

        private void Awake()
        {

            SingletonObject();

        }

        private void SingletonObject()
        {

            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }

            else
            {
                Destroy(this.gameObject);
            }

        }


        public void LoadScene(int levelIndex = 0)
        {

                StartCoroutine(LoadSceneAsync(levelIndex));   

        }

        private IEnumerator LoadSceneAsync(int levelIndex)
        {

            yield return new WaitForSeconds(delayLevelTime);

            int buildIndex = SceneManager.GetActiveScene().buildIndex;

            yield return SceneManager.UnloadSceneAsync(buildIndex);

            SceneManager.LoadSceneAsync(buildIndex + levelIndex, LoadSceneMode.Additive).completed += (AsyncOperation obj) =>
            {

                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));

            };
            
            OnSceneChanged?.Invoke(false);
            IncreaseScore();

        }

        public void ExitGame()
        {

            Application.Quit();

        }


        public void LoadMenuAndUi(float delayLoading)
        {

            StartCoroutine(LoadMenuAndUiAsync(delayLoading));

        }

        private IEnumerator LoadMenuAndUiAsync(float delayLoading)
        {

            yield return new WaitForSeconds(delayLoading);
            yield return SceneManager.LoadSceneAsync("MenuScene");
            yield return SceneManager.LoadSceneAsync("Ui", LoadSceneMode.Additive);

            OnSceneChanged?.Invoke(true);
            
        }
    
        public void IncreaseScore(int score = 0){

            this.score += score;
            OnScoreChanged?.Invoke(this.score);

        }

    }


}

