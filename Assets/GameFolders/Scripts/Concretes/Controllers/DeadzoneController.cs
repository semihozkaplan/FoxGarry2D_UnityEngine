using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame2.Combats;
using ProjectGame2.ExtentionMethods;

namespace ProjectGame2.Controllers
{

    public class DeadzoneController : MonoBehaviour
    {
        Damage _damage;
        private void Awake()
        {

            _damage = GetComponent<Damage>();

        }

        private void OnCollisionEnter2D(Collision2D collision) {
            //Hangi Obje temas ederse onun kompenantını alıp oraya hasar veriyor.
            Health health = collision.ObjectHealth();

            if(health != null){

               health.TakeHit(_damage); 

            }

        }
    }

}


