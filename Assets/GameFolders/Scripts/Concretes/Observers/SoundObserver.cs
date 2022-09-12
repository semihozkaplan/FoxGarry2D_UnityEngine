using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame2.Combats;
using ProjectGame2.Controllers;

namespace ProjectGame2.Observers
{

    public class SoundObserver : MonoBehaviour
    {

        AudioSource _audioSource;

        private void Awake()
        {

            _audioSource = GetComponent<AudioSource>();

        }

        private void OnEnable()
        {

            PlayerController.OnPlayerDead += PlaySoundOneShot;
            EnemyController.OnEnemyDead += PlaySoundOneShot;
            GemController.OnScoreSound += PlaySoundOneShot;

        }

        private void OnDisable()
        {

            PlayerController.OnPlayerDead -= PlaySoundOneShot;
            EnemyController.OnEnemyDead -= PlaySoundOneShot;
            GemController.OnScoreSound -= PlaySoundOneShot;

        }

        private void PlaySoundOneShot(AudioClip clip)
        {
            //PlayOneShot tek oynatmalık klipler için kullanılan bir fonksiyondur.
            _audioSource.PlayOneShot(clip);

        }

    }


}

