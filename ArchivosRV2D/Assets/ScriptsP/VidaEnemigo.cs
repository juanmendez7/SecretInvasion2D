using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    Enemigo enemigo; 
    public bool lastimado;
    public GameObject efectoMuerte;
    Rigidbody2D rbEnemigo;
    
    // Start is called before the first frame update
    void Start()
    {
        rbEnemigo = GetComponent<Rigidbody2D>();
        enemigo = GetComponent<Enemigo>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Arma") && !lastimado)
        {
            enemigo.vidaEnemigo -= 2f;
            AudioManager.instance.PlayAudio(AudioManager.instance.hit);
            if(collision.transform.position.x < transform.position.x)
            {
                rbEnemigo.AddForce(new Vector2(enemigo.FuerzaEmpujeX, enemigo.FuerzaEmpujeY), ForceMode2D.Force);  
            }
            else
            {
                rbEnemigo.AddForce(new Vector2(-enemigo.FuerzaEmpujeX, enemigo.FuerzaEmpujeY), ForceMode2D.Force);  
            }
            StartCoroutine(Dañado());
            if(enemigo.vidaEnemigo <= 0)
            {
                Instantiate(efectoMuerte,transform.position, Quaternion.identity);
                AudioManager.instance.PlayAudio(AudioManager.instance.muerteEnemigo);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Dañado()
    {
        lastimado = true;
        GetComponent<SpriteRenderer>().material = GetComponent<Parpadeos>().parpadeo;
        yield return new WaitForSeconds(0.5f);
         GetComponent<SpriteRenderer>().material = GetComponent<Parpadeos>().original;
        lastimado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
