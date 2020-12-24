using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    public GameObject iconoMutedMusica, iconoMutedEfectos;
    public Sprite iconoMuted, iconoUnmuted;
    public Slider sliderMusica, sliderEfectos;

    public static float volumenMusica = 1f, volumenEfectos = 0.6f;
    public static bool musicaMuted = false, efectosMuted = false;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        /*volumenMusica = 1f;
        volumenEfectos = 0.6f;
        musicaMuted = false;
        efectosMuted = false;*/

        audioSource = GetComponent<AudioSource>();


    }

    private void Update()
    {
        sliderMusica.value = volumenMusica;
        sliderEfectos.value = volumenEfectos;

        if (efectosMuted)
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
            audioSource.volume = volumenEfectos;
        }

        if (musicaMuted)
        {
            iconoMutedMusica.gameObject.GetComponent<Image>().sprite = iconoMuted;
        }
        else
        {
            iconoMutedMusica.gameObject.GetComponent<Image>().sprite = iconoUnmuted;
        }

        if (efectosMuted)
        {
            iconoMutedEfectos.gameObject.GetComponent<Image>().sprite = iconoMuted;
        }
        else
        {
            iconoMutedEfectos.gameObject.GetComponent<Image>().sprite = iconoUnmuted;
        }
    }

    public void MutearMusica()
    {
        StartCoroutine(EsperarMutearVolumen());
    }

    public void MutearEfectos()
    {
        StartCoroutine(EsperarMutearEfectos());
    }

    public void SetVolumenMusica()
    {
        volumenMusica = sliderMusica.value;
    }

    public void SetVolumenEfectos()
    {
        volumenEfectos = sliderEfectos.value;
    }
    
    public void Volver()
    {
        StartCoroutine(EsperarVolver());
    }

    IEnumerator EsperarVolver()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        SceneManager.LoadScene("MenuPrincipal");
    }

    IEnumerator EsperarMutearVolumen()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        if (musicaMuted)
        {
            musicaMuted = false;
            iconoMutedMusica.gameObject.GetComponent<Image>().sprite = iconoMuted;
        }
        else
        {
            musicaMuted = true;
            iconoMutedMusica.gameObject.GetComponent<Image>().sprite = iconoUnmuted;
        }
    }

    IEnumerator EsperarMutearEfectos()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        if (efectosMuted)
        {
            efectosMuted = false;
            iconoMutedEfectos.gameObject.GetComponent<Image>().sprite = iconoMuted;
        }
        else
        {
            efectosMuted = true;
            iconoMutedEfectos.gameObject.GetComponent<Image>().sprite = iconoUnmuted;
        }
    }

}
