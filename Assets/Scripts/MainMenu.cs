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

    public void Play()
    {
        StartCoroutine(EsperarPlay());
    }

    public void CloseApp()
    {
        StartCoroutine(EsperarCloseApp());
    }

    public void FullScreen()
    {
        StartCoroutine(EsperarFullScreen());
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

    IEnumerator EsperarFullScreen()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false); 
        if (Screen.fullScreen)
        {
            //PlayerSettings.resizableWindow = true;
            Screen.SetResolution(1920, 1080, false);
        }
        else
        {
            Screen.SetResolution(1920, 1080, true);
        }
    }

    IEnumerator EsperarMute()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }
}