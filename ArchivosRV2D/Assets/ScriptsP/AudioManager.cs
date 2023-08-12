using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer music, effects;

    public AudioSource musicaJuego, hit, muerteEnemigo, cura, disparo, dañoJugadorSound, menuPrincipalMusica, GameOverSonido, Salto, Pasos, canva1, canva2;

    public static AudioManager instance;

    [Range(-80, 10)]
    public float musicaVolumen, efectosVolumen;
    public Slider MusicSlider, EffectsSlider;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayAudio(musicaJuego);
        MusicSlider.value = musicaVolumen;
        EffectsSlider.value = efectosVolumen;

        MusicSlider.minValue = -80;
        MusicSlider.maxValue = 10;


        EffectsSlider.minValue = -80;
        EffectsSlider.maxValue = 10;
    }
    

    // Update is called once per frame
    void Update()
    {
        MasterMusicVol();
        MasterEffectsVol();
    }

    public void MasterMusicVol()
    {
        music.SetFloat("MusicVolume", MusicSlider.value);
    }

    public void MasterEffectsVol()
    {
        effects.SetFloat("EffectsVolume", EffectsSlider.value);
    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
