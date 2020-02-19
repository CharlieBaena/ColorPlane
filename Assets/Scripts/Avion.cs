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
    public AudioClip sonidoSalto, sonidoPuntos, sonidoBola, sonidoMuerte;
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
    //Barrera combinada RGB spritesColorPlane_BarrerasCombinadas_0
    //Barrera combinada RBG spritesColorPlane_BarrerasCombinadas_1
    //Barrera combinada BRG spritesColorPlane_BarrerasCombinadas_2
    //Barrera combinada GRB spritesColorPlane_BarrerasCombinadas_3
    //Barrera combinada BGR spritesColorPlane_BarrerasCombinadas_4
    //Barrera combinada GBR spritesColorPlane_BarrerasCombinadas_5


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
    }

    

    // Update is called once per frame
    void Update()
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
                    emisorAudio.PlayOneShot(sonidoBola);
                    break;

                case "spritesColorPlane_PickUpsYPlaneTrans_1": //Bola verde

                    GetComponent<SpriteRenderer>().sprite = avionVerde;
                    avionSeleccionado = avionVerde;
                    emisorAudio.PlayOneShot(sonidoBola);
                    break;

                case "spritesColorPlane_PickUpsYPlaneTrans_2": //Bola Azul

                    GetComponent<SpriteRenderer>().sprite = avionAzul;
                    avionSeleccionado = avionAzul;
                    emisorAudio.PlayOneShot(sonidoBola);
                    break;

            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string nombreSprite;

        if (PlayerPrefs.GetInt("highscore") < puntos)
        {
            PlayerPrefs.SetInt("highscore", puntos);
        }

        if (collision.gameObject.CompareTag("Pared"))
        {
            Morir();
        } else {

            if (collision.gameObject.CompareTag("BarreraSimple")) { //Comprobamos si es una barrera simple o combinada. Almacenamos su nombre para el switch
                nombreSprite = collision.gameObject.GetComponentInChildren<SpriteRenderer>().sprite.name;
            }else{
                nombreSprite = collision.gameObject.GetComponentInParent<SpriteRenderer>().sprite.name;
            }

            switch (avionSeleccionado.name) //Consultamos primero de que color es nuestro avion
            {
                case "spritesColorPlane_PickUpsYPlaneTrans_3": //avion blanco
                    Morir();
                    break;

                case "spritesColorPlane_PickUpsYPlaneTrans_4": //avion rojo

                    switch (nombreSprite) //Comprobamos cual de las barreras es
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

                        case "spritesColorPlane_BarrerasCombinadas_0": //Barrera combinada RGB

                            if (collision.gameObject.CompareTag("ColliderRojo")) //Si pasamos por la parte roja de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_1": //Barrera combinada RBG

                            if (collision.gameObject.CompareTag("ColliderRojo")) //Si pasamos por la parte roja de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_2": //Barrera combinada BRG

                            if (collision.gameObject.CompareTag("ColliderRojo")) //Si pasamos por la parte roja de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_3": //Barrera combinada GRB

                            if (collision.gameObject.CompareTag("ColliderRojo")) //Si pasamos por la parte roja de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_4": //Barrera combinada BGR

                            if (collision.gameObject.CompareTag("ColliderRojo")) //Si pasamos por la parte roja de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_5": //Barrera combinada GBR

                            if (collision.gameObject.CompareTag("ColliderRojo")) //Si pasamos por la parte roja de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;
                    }

                    break;

                case "spritesColorPlane_PickUpsYPlaneTrans_5": //avion Verde

                    switch (nombreSprite) //Comprobamos cual de las barreras es
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

                        case "spritesColorPlane_BarrerasCombinadas_0": //Barrera combinada RGB

                            if (collision.gameObject.CompareTag("ColliderVerde")) //Si pasamos por la parte verde de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_1": //Barrera combinada RBG

                            if (collision.gameObject.CompareTag("ColliderVerde")) //Si pasamos por la parte verde de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_2": //Barrera combinada BRG

                            if (collision.gameObject.CompareTag("ColliderVerde")) //Si pasamos por la parte verde de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_3": //Barrera combinada GRB

                            if (collision.gameObject.CompareTag("ColliderVerde")) //Si pasamos por la parte verde de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_4": //Barrera combinada BGR 

                            if (collision.gameObject.CompareTag("ColliderVerde")) //Si pasamos por la parte verde de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_5": //Barrera combinada GBR 

                            if (collision.gameObject.CompareTag("ColliderVerde")) //Si pasamos por la parte verde de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;
                    }

                    break;

                case "spritesColorPlane_PickUpsYPlaneTrans_6": //avion Azul

                    switch (nombreSprite) //Comprobamos cual de las barreras es
                    {
                        case "spritesColorPlane_BarrerasSimples_0":  //Barrera roja

                            Morir();
                            break;

                        case "spritesColorPlane_BarrerasSimples_2":  //Barrera verde

                            Morir();
                            break;

                        case "spritesColorPlane_BarrerasSimples_1":  //Barrera azul

                            isDead = false;
                            collision.gameObject.SetActive(false);
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_0": //Barrera combinada RGB

                            if (collision.gameObject.CompareTag("ColliderAzul")) //Si pasamos por la parte azul de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_1": //Barrera combinada RBG

                            if (collision.gameObject.CompareTag("ColliderAzul")) //Si pasamos por la parte azul de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_2": //Barrera combinada BRG

                            if (collision.gameObject.CompareTag("ColliderAzul")) //Si pasamos por la parte azul de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_3": //Barrera combinada GRB

                            if (collision.gameObject.CompareTag("ColliderAzul")) //Si pasamos por la parte azul de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_4": //Barrera combinada BGR

                            if (collision.gameObject.CompareTag("ColliderAzul")) //Si pasamos por la parte azul de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
                            break;

                        case "spritesColorPlane_BarrerasCombinadas_5": //Barrera combinada GBR

                            if (collision.gameObject.CompareTag("ColliderAzul")) //Si pasamos por la parte azul de la barrera
                            {
                                isDead = false;
                                collision.gameObject.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
                                break;
                            }
                            else
                            {
                                Morir();
                            }
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
        //emisorAudio.PlayOneShot(sonidoGolpe);
        emisorAudio.PlayOneShot(sonidoMuerte);
        isDead = true;
        panelMuerte.SetActive(true);
        mFondo.CambiarFondo();
        //Time.timeScale = 0f;
        Time.timeScale = 0.5f;
        StartCoroutine(Esperar());
        
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 0f;
    }

}
