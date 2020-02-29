using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highscoreText;
    private AudioSource audioSource;

    void Start()	
    {
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
}