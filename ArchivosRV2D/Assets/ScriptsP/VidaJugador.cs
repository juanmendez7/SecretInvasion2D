using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    SpriteRenderer sprite2;
    public float vida;
    public float maximaVida;
    bool esInmune;
    public float tiempoInmunidad;
    Parpadeos material;
    public float FuerzaEmpujePX;
    public float FuerzaEmpujePY;
    Rigidbody2D rbP;
    public Image imagenVida;

    public GameObject GameOverImagen;
    // Start is called before the first frame update
    void Start()
    {
        GameOverImagen.SetActive(false);
        imagenVida.fillAmount = vida / 100;
        rbP = GetComponent<Rigidbody2D>();
        sprite2 = GetComponent<SpriteRenderer>();
        material = GetComponent<Parpadeos>();
        vida = maximaVida;
    }

    // Update is called once per frame
    void Update()
    {
        imagenVida.fillAmount = vida / 100;
        
        if(vida > maximaVida)
        {
            vida = maximaVida;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemigo") && !esInmune)
        {
            vida -= collision.GetComponent<Enemigo>().dañoHecho;
            AudioManager.instance.PlayAudio(AudioManager.instance.dañoJugadorSound);
            StartCoroutine(Inmunidad());

            if(collision.transform.position.x > transform.position.x)
            {
                rbP.AddForce(new Vector2(-FuerzaEmpujePX, FuerzaEmpujePY), ForceMode2D.Force);

            }else
            {
                rbP.AddForce(new Vector2(FuerzaEmpujePX, FuerzaEmpujePY), ForceMode2D.Force);
            }
            if(vida <= 0)
            {   
                AudioManager.instance.musicaJuego.Stop();
                AudioManager.instance.PlayAudio(AudioManager.instance.GameOverSonido);
                Time.timeScale = 0;
                GameOverImagen.SetActive(true);
                
            }
        }
    }

    IEnumerator Inmunidad()
    {
        esInmune = true;
        sprite2.material = material.parpadeo;
        yield return new WaitForSeconds(tiempoInmunidad);
        sprite2.material = material.original;
        esInmune = false;
    }
}
