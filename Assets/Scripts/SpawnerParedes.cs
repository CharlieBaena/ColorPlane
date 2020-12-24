using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnerParedes : MonoBehaviour
{
    public GameObject prefabMuroR,prefabMuroG,prefabMuroB,
                    prefabMuroCombinado1, prefabMuroCombinado2, prefabMuroCombinado3,
                    prefabMuroCombinado4, prefabMuroCombinado5, prefabMuroCombinado6,
                    prefabMuroDoble1, prefabMuroDoble2, prefabMuroDoble3, prefabMuroDoble4,
                    prefabMuroDoble5, prefabMuroDoble6;
    public float  tiempoEntreSpawns;
    //public int nivelMurosCombinados;
    public GameObject panelBarreras;

    private static int cont = 0;
    private List<GameObject> barrerasSpawneadas;



    // Start is called before the first frame update
    void Start()
    {
        barrerasSpawneadas = new List<GameObject>();
        InvokeRepeating("SpawnObstaculo", 0F, tiempoEntreSpawns);
    }

    void SpawnObstaculo()
    {
        int random;
        

        if (cont >= 0 && cont <= 10)
        {

            random = Random.Range(0, 6);
            switch (random)
            {
                case 0:
                    Instantiate(prefabMuroCombinado1, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado1);
                    cont++;
                    break;

                case 1:
                    Instantiate(prefabMuroCombinado2, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado2);
                    cont++;
                    break;

                case 2:
                    Instantiate(prefabMuroCombinado3, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado3);
                    cont++;
                    break;

                case 3:
                    Instantiate(prefabMuroCombinado4, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado4);
                    cont++;
                    break;

                case 4:
                    Instantiate(prefabMuroCombinado5, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado5);
                    cont++;
                    break;
                case 5:
                    Instantiate(prefabMuroCombinado6, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado6);
                    cont++;
                    break;
            }

        } else if ( cont >= 11 && cont <= 20) {

            random = Random.Range(0, 12);
            switch (random)
            {
                case 0:
                    Instantiate(prefabMuroCombinado1, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado1);
                    cont++;
                    break;

                case 1:
                    Instantiate(prefabMuroCombinado2, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado2);
                    cont++;
                    break;

                case 2:
                    Instantiate(prefabMuroCombinado3, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado3);
                    cont++;
                    break;

                case 3:
                    Instantiate(prefabMuroCombinado4, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado4);
                    cont++;
                    break;

                case 4:
                    Instantiate(prefabMuroCombinado5, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado5);
                    cont++;
                    break;

                case 5:
                    Instantiate(prefabMuroCombinado6, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado6);
                    cont++;
                    break;

                case 6:
                    Instantiate(prefabMuroDoble1, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble1);
                    cont++;
                    break;

                case 7:
                    Instantiate(prefabMuroDoble2, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble2);
                    cont++;
                    break;

                case 8:
                    Instantiate(prefabMuroDoble3, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble3);
                    cont++;
                    break;

                case 9:
                    Instantiate(prefabMuroDoble4, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble4);
                    cont++;
                    break;

                case 10:
                    Instantiate(prefabMuroDoble5, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble5);
                    cont++;
                    break;

                case 11:
                    Instantiate(prefabMuroDoble6, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble6);
                    cont++;
                    break;
            }

        } else if ( cont >= 21 && cont <= 30) {

            random = Random.Range(0, 6);
            switch (random)
            {
                case 0:
                    Instantiate(prefabMuroDoble1, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble1);
                    cont++;
                    break;

                case 1:
                    Instantiate(prefabMuroDoble2, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble2);
                    cont++;
                    break;

                case 2:
                    Instantiate(prefabMuroDoble3, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble3);
                    cont++;
                    break;

                case 3:
                    Instantiate(prefabMuroDoble4, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble4);
                    cont++;
                    break;

                case 4:
                    Instantiate(prefabMuroDoble5, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble5);
                    cont++;
                    break;
                case 5:
                    Instantiate(prefabMuroDoble6, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble6);
                    cont++;
                    break;
            }

        } else if ( cont >= 31 && cont <= 40) {

            random = Random.Range(0, 9);
            switch (random)
            {
                case 0:
                    Instantiate(prefabMuroDoble1, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble1);
                    cont++;
                    break;

                case 1:
                    Instantiate(prefabMuroDoble2, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble2);
                    cont++;
                    break;

                case 2:
                    Instantiate(prefabMuroDoble3, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble3);
                    cont++;
                    break;

                case 3:
                    Instantiate(prefabMuroDoble4, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble4);
                    cont++;
                    break;

                case 4:
                    Instantiate(prefabMuroDoble5, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble5);
                    cont++;
                    break;

                case 5:
                    Instantiate(prefabMuroDoble6, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble6);
                    cont++;
                    break;

                case 6:
                    Instantiate(prefabMuroR, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroR);
                    cont++;
                    break;

                case 7:
                    Instantiate(prefabMuroG, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroG);
                    cont++;
                    break;

                case 8:
                    Instantiate(prefabMuroB, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroB);
                    cont++;
                    break;
            }

        } else if ( cont >= 41 && cont <= 50) {

            random = Random.Range(0, 3);
            switch (random)
            {
                case 0:
                    Instantiate(prefabMuroR, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroR);
                    cont++;
                    break;

                case 1:
                    Instantiate(prefabMuroG, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroG);
                    cont++;
                    break;

                case 2:
                    Instantiate(prefabMuroB, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroB);
                    cont++;
                    break;
            }

        } else {

            random = Random.Range(0, 15);
            switch (random)
            {
                case 0:
                    Instantiate(prefabMuroCombinado1, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado1);
                    cont++;
                    break;

                case 1:
                    Instantiate(prefabMuroCombinado2, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado2);
                    cont++;
                    break;

                case 2:
                    Instantiate(prefabMuroCombinado3, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado3);
                    cont++;
                    break;

                case 3:
                    Instantiate(prefabMuroCombinado4, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado4);
                    cont++;
                    break;

                case 4:
                    Instantiate(prefabMuroCombinado5, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado5);
                    cont++;
                    break;

                case 5:
                    Instantiate(prefabMuroCombinado6, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado6);
                    cont++;
                    break;

                case 6:
                    Instantiate(prefabMuroDoble1, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble1);
                    cont++;
                    break;

                case 7:
                    Instantiate(prefabMuroDoble2, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble2);
                    cont++;
                    break;

                case 8:
                    Instantiate(prefabMuroDoble3, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble3);
                    cont++;
                    break;

                case 9:
                    Instantiate(prefabMuroDoble4, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble4);
                    cont++;
                    break;

                case 10:
                    Instantiate(prefabMuroDoble5, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble5);
                    cont++;
                    break;

                case 11:
                    Instantiate(prefabMuroDoble6, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroDoble6);
                    cont++;
                    break;

                case 12:
                    Instantiate(prefabMuroR, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroR);
                    cont++;
                    break;

                case 13:
                    Instantiate(prefabMuroG, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroG);
                    cont++;
                    break;

                case 14:
                    Instantiate(prefabMuroB, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroB);
                    cont++;
                    break;
            }

        }

        /*if (cont >= 10 && cont <=20 || cont >= 30 && cont <= 40 || cont >=45 && cont <=50 || cont ==52 || cont == 54 || cont == 56 || cont == 58 || cont >= 60)
        {
            random = Random.Range(0, 3);
            switch (random)
            {
                case 0:
                    Instantiate(prefabMuroR, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroR);
                    cont++;
                    break;

                case 1:
                    Instantiate(prefabMuroG, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroG);
                    cont++;
                    break;

                case 2:
                    Instantiate(prefabMuroB, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroB);
                    cont++;
                    break;
            }
        }
        else
        {
            random = Random.Range(0, 6);
            switch (random)
            {
                case 0:
                    Instantiate(prefabMuroCombinado1, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado1);
                    cont++;
                    break;

                case 1:
                    Instantiate(prefabMuroCombinado2, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado2);
                    cont++;
                    break;

                case 2:
                    Instantiate(prefabMuroCombinado3, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado3);
                    cont++;
                    break;

                case 3:
                    Instantiate(prefabMuroCombinado4, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado4);
                    cont++;
                    break;

                case 4:
                    Instantiate(prefabMuroCombinado5, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado5);
                    cont++;
                    break;
                case 5:
                    Instantiate(prefabMuroCombinado6, transform.position, Quaternion.identity);
                    barrerasSpawneadas.Add(prefabMuroCombinado6);
                    cont++;
                    break;
            }
        }*/
        ActualizarPanel();
    }

    public void ReiniciarContador()
    {
        cont = 0;
        barrerasSpawneadas.Clear();
    }

    public void SetContador(int x)
    {
        cont = x;
        barrerasSpawneadas.Clear();
    }

    public void ActualizarPanel()
    {
        panelBarreras.GetComponent<Image>().sprite = barrerasSpawneadas[0].GetComponentInChildren<SpriteRenderer>().sprite;
        barrerasSpawneadas.RemoveAt(0);
    }



}
