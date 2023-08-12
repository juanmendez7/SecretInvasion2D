using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && transform.GetComponentInParent<ProyectilEnemigo>().vigilante == true)
        {
            transform.GetComponentInParent<ProyectilEnemigo>().Shoot2();
        }
    }
}
