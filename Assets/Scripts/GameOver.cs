using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text highScoreText;
    private AudioSource audioSource;
    public GameObject botonContinuar,gameObjectAvion,gameObjectSpawner,gameObjectVideoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("highscore");
        audioSource = GetComponent<AudioSource>();
        botonContinuar.SetActive(gameObjectAvion.GetComponent<Avion>().GetPrimeraMuerte());
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



    IEnumerator EsperarTryAgain()
    { 
        yield return new WaitUntil(() => audioSource.isPlaying ==false);
        gameObjectSpawner.GetComponent<SpawnerParedes>().ReiniciarContador();
        gameObjectAvion.GetComponent<Avion>().SetPrimeraMuerte(true);
        gameObjectAvion.GetComponent<Avion>().ReiniciarPuntos();
        SceneManager.LoadScene("EscenaPrincipal");
        
    }

    IEnumerator EsperarMainMenu()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        SceneManager.LoadScene("MenuPrincipal");
    }

    IEnumerator EsperarContinuar()
    {

        yield return new WaitUntil(() => audioSource.isPlaying == false);
        gameObjectSpawner.GetComponent<SpawnerParedes>().SetContador(gameObjectAvion.GetComponent<Avion>().GetPuntos());
        gameObjectAvion.GetComponent<Avion>().SetPrimeraMuerte(false);


    }

}
