using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame2.Managers;

namespace ProjectGame2.Uis
{

    public class LoadingCanvas : MonoBehaviour
    {
        private void Start()
        {

            GameManager.Instance.LoadMenuAndUi(5f);

        }
    }

}


