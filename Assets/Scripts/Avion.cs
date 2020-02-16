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
    private MovimientoFondo mFondo;
    private Sprite avionSeleccionado;

    //Para establecer un rango de valores
    [Range(3, 8)]
    public float speed = 5f;
    public Text marcadorDePuntos;
    public GameObject panelMuerte,fondo;
    public AudioClip sonidoSalto, sonidoPuntos, sonidoGolpe, sonidoMuerte;
    public Sprite avionBlanco, avionRojo, avionVerde, avionAzul;


    //Bola Roja spritesColorPlane_PickUpsYPlaneTrans_0
    //Bola Verde spritesColorPlane_PickUpsYPlaneTrans_1
    //Bola Azul spritesColorPlane_PickUpsYPlaneTrans_2

    //Blanco spritesColorPlane_PickUpsYPlaneTrans_3
    //Rojo spritesColorPlane_PickUpsYPlaneTrans_4
    //Verde spritesColorPlane_PickUpsYPlaneTrans_5
    //Azul spritesColorPlane_PickUpsYPlaneTrans_6

    //BarreraRoja spritesColorPlane_BarrerasSimples_0
    //BarreraVerde spritesColorPlane_BarrerasSimples_1
    //BarreraAzul spritesColorPlane_BarrerasSimples_2


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        emisorAudio = GetComponent<AudioSource>();
        panelMuerte.SetActive(false);
        isDead = false;
        avionSeleccionado = GetComponent<SpriteRenderer>().sprite;
        mFondo = fondo.GetComponent<MovimientoFondo>();   // Find("Scripts").GetComponent(typeof(MovimientoFondo)) as MovimientoFondo;
        Time.timeScale = 1f;

        /*MostrarTextoAleatorio();
        Debug.Log("Prueba");
        InvokeRepeating("ImprimirLetra", 0f, 3);*/

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ContadorPuntos"))
        {
            if (!isDead)
            {
                puntos += 1;
                emisorAudio.PlayOneShot(sonidoPuntos);
                marcadorDePuntos.text = puntos.ToString();
            }
        }
        else
        {
            switch (collision.gameObject.GetComponent<SpriteRenderer>().sprite.name)
            {
                case "spritesColorPlane_PickUpsYPlaneTrans_0": //Bola Roja

                    GetComponent<SpriteRenderer>().sprite = avionRojo;
                    avionSeleccionado = avionRojo;
                    break;

                case "spritesColorPlane_PickUpsYPlaneTrans_1": //Bola verde

                    GetComponent<SpriteRenderer>().sprite = avionVerde;
                    avionSeleccionado = avionVerde;
                    break;

                case "spritesColorPlane_PickUpsYPlaneTrans_2": //Bola Azul

                    GetComponent<SpriteRenderer>().sprite = avionAzul;
                    avionSeleccionado = avionAzul;
                    break;

            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (PlayerPrefs.GetInt("highscore") < puntos)
        {
            PlayerPrefs.SetInt("highscore", puntos);
        }

        if (collision.gameObject.CompareTag("Pared"))
        {
            Morir();
        } else {

            switch (avionSeleccionado.name)
            {
                case "spritesColorPlane_PickUpsYPlaneTrans_3": //avion blanco
                    Morir();
                    break;

                case "spritesColorPlane_PickUpsYPlaneTrans_4": //avion rojo

                    switch (collision.gameObject.GetComponentInChildren<SpriteRenderer>().sprite.name)
                    {
                        case "spritesColorPlane_BarrerasSimples_0":  //Barrera roja

                            isDead = false;
                            collision.gameObject.SetActive(false);
                            break;

                        case "spritesColorPlane_BarrerasSimples_2":  //Barrera verde

                            Morir();
                            break;

                        case "spritesColorPlane_BarrerasSimples_1":  //Barrera azul

                            Morir();
                            break;
                    }

                    break;

                case "spritesColorPlane_PickUpsYPlaneTrans_5": //avion Verde

                    switch (collision.gameObject.GetComponentInChildren<SpriteRenderer>().sprite.name)
                    {
                        case "spritesColorPlane_BarrerasSimples_0":  //Barrera roja

                            Morir();
                            break;

                        case "spritesColorPlane_BarrerasSimples_2":  //Barrera verde

                            isDead = false;
                            collision.gameObject.SetActive(false);
                            break;

                        case "spritesColorPlane_BarrerasSimples_1":  //Barrera azul

                            Morir();
                            break;
                    }

                    break;

                case "spritesColorPlane_PickUpsYPlaneTrans_6": //avion Azul

                    switch (collision.gameObject.GetComponentInChildren<SpriteRenderer>().sprite.name)
                    {
                        case "spritesColorPlane_BarrerasSimples_0":  //Barrera roja

                            Morir();
                            //Time.timeScale = 0.1f;
                            break;

                        case "spritesColorPlane_BarrerasSimples_2":  //Barrera verde

                            Morir();
                            break;

                        case "spritesColorPlane_BarrerasSimples_1":  //Barrera azul

                            isDead = false;
                            collision.gameObject.SetActive(false);
                            break;
                    }

                    break;
            }
        }

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

    private void Morir()
    {
        emisorAudio.PlayOneShot(sonidoGolpe);
        emisorAudio.PlayOneShot(sonidoMuerte);
        isDead = true;
        panelMuerte.SetActive(true);
        mFondo.CambiarFondo();

        Time.timeScale = 0.5f;
        Esperar();
        
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 0f;
    }






    /*        List<string> n = new List<string>() {"I thought love was only true in fairy tales",
                                                    "Meant for someone else but not for me",
                                                    "Love was out to get me",
                                                    "That's the way it seemed",
                                                    "Disappointment haunted all of my dreams",
                                                    "Then I saw her face, now I'm a believer",
                                                    "Not a trace, of doubt in my mind",
                                                    "I'm in love, and I'm a believer",
                                                    "I couldn't leave her if I tried",
                                                    "I thought love was more or less a giving thing",
                                                    "The more I gave the less I got oh yeah",
                                                    "What's the use in tryin'",
                                                    "All you get is pain",
                                                    "When I wanted sunshine I got rain",
                                                    "Then I saw her face, now I'm a believer",
                                                    "Not a trace, of doubt in my mind",
                                                    "I'm in love, I'm a believer",
                                                    "I couldn't leave her if I tried",
                                                    "What's the use of trying",
                                                    "All you get is pain",
                                                    "When I wanted sunshine I got rain",
                                                    "Then I saw her face, now I'm a"};
            public Text letra;
            private int i = 0,j=0;*/



    /*void MostrarTextoAleatorio()
    {
        
        int tamanio = n.Count;
        int random  = Random.Range(0, tamanio-1);

        letra.text = n[random];
    }

    IEnumerator Esperar() {
        yield return new WaitForSeconds(60);
    }*/

    /*void ImprimirLetra()
    {
        if (i == n.Count)
            i = 0;

        letra.text = n[i];
        Debug.Log(letra.text);
            //StartCoroutine(Esperar());
        i++;

    }*/
}
