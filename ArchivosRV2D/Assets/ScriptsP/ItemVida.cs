using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVida : MonoBehaviour
{

    public float vidaDada;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<VidaJugador>().vida += vidaDada;
            AudioManager.instance.PlayAudio(AudioManager.instance.cura);
            Destroy(gameObject);
        }
    }
}
