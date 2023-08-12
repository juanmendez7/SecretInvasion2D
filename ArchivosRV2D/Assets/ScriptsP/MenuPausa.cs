using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuPausa : MonoBehaviour
{

    public GameObject pauseMenu;
    bool esPausa; 
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        esPausa = false;
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    public void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !esPausa)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            esPausa = true;
        }else if(Input.GetKeyDown(KeyCode.Escape) && esPausa)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            esPausa = false;
        }
    }
}
