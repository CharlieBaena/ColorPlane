using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text highScoreText;
    private AudioSource audioSource;
    private Avion avion;
    public GameObject botonContinuar,gameObjectAvion,gameObjectSpawner,gameObjectVideoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("highscore");
        audioSource = GetComponent<AudioSource>();
        //avion = gameObjectAvion.GetComponent<Avion>();
        botonContinuar.SetActive(gameObjectAvion.GetComponent<Avion>().GetPrimeraMuerte());
    }

    public void TryAgain()
    {
        StartCoroutine(EsperarTryAgain());
        
    }

    public void MainMenu()
    {
        StartCoroutine(EsperarMainMenu());
    }

    public void Continuar()
    {

        StartCoroutine(EsperarContinuar());

    }

    public void FullScreen()
    {
        if (Screen.fullScreen)
        {
            Screen.SetResolution(1920, 1080, false);
        }
        else
        {
            Screen.SetResolution(1920, 1080, true);
        }
    }

    IEnumerator EsperarTryAgain()
    { 
        yield return new WaitUntil(() => audioSource.isPlaying ==false);
        gameObjectSpawner.GetComponent<SpawnerParedes>().ReiniciarContador();
        /*avion*/gameObjectAvion.GetComponent<Avion>().SetPrimeraMuerte(true);
        /*avion*/gameObjectAvion.GetComponent<Avion>().ReiniciarPuntos();
        SceneManager.LoadScene("EscenaPrincipal");
        
    }

    IEnumerator EsperarMainMenu()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        SceneManager.LoadScene("MenuPrincipal");
        //Application.Quit();
    }

    IEnumerator EsperarContinuar()
    {

        yield return new WaitUntil(() => audioSource.isPlaying == false);
        gameObjectSpawner.GetComponent<SpawnerParedes>().SetContador(gameObjectAvion.GetComponent<Avion>().GetPuntos());
        /*avion*/gameObjectAvion.GetComponent<Avion>().SetPrimeraMuerte(false);
        //StartCoroutine(gameObjectVideoPlayer.GetComponent<ReproducirVideo>().PlayVideo());


        //SceneManager.LoadScene("EscenaPrincipal");
    }

}
