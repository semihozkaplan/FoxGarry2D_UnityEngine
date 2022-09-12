using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame2.Movements
{

    public class FlipPlayer : MonoBehaviour
    {
        //Karakter yön değiştirme işlemi 
        public void Flip(float horizontal)
        {

            if (horizontal != 0)
            {

                float mathfValue = Mathf.Sign(horizontal);
                
                if (transform.localScale.x == mathfValue) return;

                //Mathf.sign methodu bize pozitif veya negatif int değerler döner.
                transform.localScale = new Vector2(mathfValue, 1f);

            }

        }
    }

}


