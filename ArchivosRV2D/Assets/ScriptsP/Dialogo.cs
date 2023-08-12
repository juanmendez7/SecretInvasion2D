using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogo : MonoBehaviour
{
  

  private bool RangoHablar;
  [SerializeField] private GameObject dialogoMarca;
  [SerializeField] private GameObject dialogoPanel;
  [SerializeField] private TMP_Text dialogoTexto;
  [SerializeField, TextArea(4,6)] private string [] lineasDialogo;
  private float tiempoEscritura = 0.05f;
  private bool DialogoComenzo;
  private int numeroLinea;

    // Update is called once per frame
    void Update()
    {
        if(RangoHablar && Input.GetKeyDown(KeyCode.H))
        {
            if(!DialogoComenzo)
            {
                IniciarDialogo();
            }
            else if(dialogoTexto.text == lineasDialogo[numeroLinea])
            {
                SiguienteLineaDialogo();
            }else
            {
                StopAllCoroutines();
                dialogoTexto.text = lineasDialogo[numeroLinea];
            }
            
        }
    }

    private void IniciarDialogo()
    {
        DialogoComenzo = true;
        dialogoPanel.SetActive(true);
        dialogoMarca.SetActive(false);
        numeroLinea = 0;
        Time.timeScale = 0f;
        StartCoroutine(mostrarLinea());
    }

    private void SiguienteLineaDialogo()
    {
        numeroLinea++;
        if(numeroLinea < lineasDialogo.Length)
        {
            StartCoroutine(mostrarLinea());
        }else
        {
            DialogoComenzo = false;
            dialogoPanel.SetActive(false);
            dialogoMarca.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    private IEnumerator mostrarLinea()
    {
        dialogoTexto.text = string.Empty;
        foreach(char ch in lineasDialogo[numeroLinea])
        {
            dialogoTexto.text += ch;
            yield return new WaitForSecondsRealtime(tiempoEscritura);
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            dialogoMarca.SetActive(true);
           RangoHablar = true; 
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("Player"))
        {
            dialogoMarca.SetActive(false);
           RangoHablar = false; 
        }
        
    }
}
