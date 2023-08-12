using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public Animator OpcionesAnimacion;


    // Start is called before the first frame update
    void Start()
    {


        AudioManager.instance.PlayAudio(AudioManager.instance.menuPrincipalMusica);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarJuego()
    {
        
        SceneManager.LoadScene(1);
    }

    public void QuitarJuego()
    {
        Application.Quit();
        print("Juego Cerrado");
    }

    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void MostrarOpciones()
    {
        OpcionesAnimacion.SetBool("MostrarOpciones", true);
    }

    public void OcultarOpciones()
    {
        OpcionesAnimacion.SetBool("MostrarOpciones", false);
    }

    public void IniciarJuego2()
    {
        SceneManager.LoadScene(2);
    }
}
