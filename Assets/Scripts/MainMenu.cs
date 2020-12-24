using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEditor;

public class MainMenu : MonoBehaviour
{
    public Text highscoreText;
    private AudioSource audioSource;
    public bool isMute;

    void Start()	
    {
        Screen.fullScreen = true;
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore");
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (MenuOpciones.efectosMuted)
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
            audioSource.volume = MenuOpciones.volumenEfectos;
        }
    }

    public void Play()
    {
        StartCoroutine(EsperarPlay());
    }

    public void CloseApp()
    {
        StartCoroutine(EsperarCloseApp());
    }

    public void EscenaMenuOpciones()
    {
        StartCoroutine(EsperarMenuOpciones());
    }


    public void Mute()
    {
        StartCoroutine(EsperarMute());
    }


    IEnumerator EsperarPlay()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        SceneManager.LoadScene("EscenaPrincipal");
    }

    IEnumerator EsperarCloseApp()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        Application.Quit();
    }

    IEnumerator EsperarMenuOpciones()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        SceneManager.LoadScene("MenuOpciones");
    }

    IEnumerator EsperarMute()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }
}