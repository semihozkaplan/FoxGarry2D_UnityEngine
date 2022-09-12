using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame2.Managers;


namespace ProjectGame2.Uis
{

    public class GameOverPanel : MonoBehaviour
    {

        public void YesButton()
        {

            GameManager.Instance.LoadScene();
            this.gameObject.SetActive(false);

        }

        public void NoButton()
        {

            GameManager.Instance.LoadMenuAndUi(3f);

        }

    }


}

