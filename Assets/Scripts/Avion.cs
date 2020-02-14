using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Avion : MonoBehaviour
{
    private Rigidbody2D myRB;
    private int puntos = 0;
    private bool isDead;
    private AudioSource emisorAudio;
    List<string> n = new List<string>() { "when", "I", "Saw", "Her", "Face" };
    public Text letra;
    private int i = 0,j=0;


    //Para establecer un rango de valores
    [Range(3, 8)]
    public float speed = 5f;
    public Text marcadorDePuntos;
    public GameObject panelMuerte;
    public AudioClip sonidoSalto, sonidoPuntos, sonidoGolpe, sonidoMuerte;



    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        emisorAudio = GetComponent<AudioSource>();
        panelMuerte.SetActive(false);
        isDead = false;
        //MostrarTextoAleatorio();
        Debug.Log("Prueba");
        InvokeRepeating("ImprimirLetra", 0f, 5);

    }

    /*void MostrarTextoAleatorio()
    {
        
        int tamanio = n.Count;
        int random  = Random.Range(0, tamanio-1);

        letra.text = n[random];
    }

    IEnumerator Esperar() {
        yield return new WaitForSeconds(60);
    }*/

    void ImprimirLetra()
    {
        if (i == 5)
            i = 0;

        letra.text = n[i];
        Debug.Log(letra.text);
            //StartCoroutine(Esperar());
        i++;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) || PantallaTocada() || Input.GetMouseButtonDown(0))
        {
            if (!isDead)
            {
                myRB.velocity = Vector2.up * speed; // ---> (0,1) * 5
                emisorAudio.PlayOneShot(sonidoSalto);
            }

        }
        /*if (j == 0) ;
        //ImprimirLetra();
        else
            j++;


        if (j == 30)
            j = 0;*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        puntos = puntos + 1;
        emisorAudio.PlayOneShot(sonidoPuntos);
        marcadorDePuntos.text = puntos.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (PlayerPrefs.GetInt("highscore") < puntos)
        {
            PlayerPrefs.SetInt("highscore", puntos);
        }
        emisorAudio.PlayOneShot(sonidoGolpe);
        emisorAudio.PlayOneShot(sonidoMuerte);
        isDead = true;
        panelMuerte.SetActive(true);

    }


    bool PantallaTocada()
    {
        if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Began)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
