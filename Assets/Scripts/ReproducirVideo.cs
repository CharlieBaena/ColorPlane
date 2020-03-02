using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ReproducirVideo : MonoBehaviour
{
    public RawImage panelVideo;
    public VideoPlayer videoPlayer;
    
    private AudioSource musica;

    public VideoClip vc1, vc2, vc3, vc4, vc5, vc6, vc7;

    private void Start()
    {
        musica = GameObject.FindWithTag("music").GetComponent<AudioSource>();
    }

    public void EmpezarCorutina()
    {
        musica.Pause();
        StartCoroutine(PlayVideo());
    }
    public IEnumerator PlayVideo()
    {


        videoPlayer.clip = escogerAleatorio();
        videoPlayer.Prepare();
        videoPlayer.frame = 0;
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);

        while (!videoPlayer.isPrepared)
        {
            yield return null;
            Debug.Log("Preparing Video");
        }

        panelVideo.texture = videoPlayer.texture;
        panelVideo.gameObject.SetActive(true);

        videoPlayer.Play();
        videoPlayer.loopPointReached += LoadScene;



    }

    void LoadScene(VideoPlayer vp)
    {
        musica.Play();
        SceneManager.LoadScene("EscenaPrincipal");
    }


    private VideoClip escogerAleatorio()
    {
        VideoClip res = null;
        int random;
        random = Random.Range(0, 7);
        switch (random)
        {
            case 0:
                res = vc1;
                break;
            case 1:
                res = vc2;
                break;
            case 2:
                res = vc3;
                break;
            case 3:
                res = vc4;
                break;
            case 4:
                res = vc5;
                break;
            case 5:
                res = vc6;
                break;
            case 6:
                res = vc7;
                break;
        }
        return res;
    }
}
