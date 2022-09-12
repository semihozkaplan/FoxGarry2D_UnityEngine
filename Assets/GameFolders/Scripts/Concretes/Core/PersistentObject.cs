using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame2.Core
{

    public class PersistentObject : MonoBehaviour
    {

        [SerializeField] GameObject _persistentObject;
        static bool isFirstTime = true;

        private void Start()
        {

            if (isFirstTime)
            {

                SpawnPersistentObject();
                isFirstTime = false;

            }

        }

        private void SpawnPersistentObject()
        {

            GameObject persistentObject = Instantiate(_persistentObject);
            DontDestroyOnLoad(persistentObject);

        }

    }

}


