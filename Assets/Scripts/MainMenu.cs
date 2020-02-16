using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highscoreText;

    void Start()	
    {
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore");
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}