using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("highscore");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("EscenaPrincipal");
    }

    public void MainMenu()
    {
        //SceneManager.LoadScene("MenuPrincipal");
        Application.Quit();
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
}
