using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame2.Managers;

namespace ProjectGame2.Uis
{

    public class MenuPanel : MonoBehaviour
    {

        public void StartButton()
        {

            GameManager.Instance.LoadScene(1);

        }


        public void ExitButton()
        {

            GameManager.Instance.ExitGame();

        }

    }

}


