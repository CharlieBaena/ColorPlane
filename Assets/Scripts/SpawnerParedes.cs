using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerParedes : MonoBehaviour
{
    public GameObject prefabMuroR,prefabMuroG,prefabMuroB,
                    prefabMuroCombinado1, prefabMuroCombinado2, prefabMuroCombinado3,
                    prefabMuroCombinado4, prefabMuroCombinado5, prefabMuroCombinado6;
    public float  tiempoEntreSpawns;
    public int nivelMurosCombinados; 

    private int cont;

    // Start is called before the first frame update
    void Start()
    {
        cont = 0;
        InvokeRepeating("SpawnObstaculo", 0F, tiempoEntreSpawns);
    }

    void SpawnObstaculo()
    {
        int random;
        if (cont < nivelMurosCombinados)
        {
            random = Random.Range(0, 3);
            switch (random)
            {
                case 0:
                    Instantiate(prefabMuroR, transform.position, Quaternion.identity);
                    cont++;
                    break;

                case 1:
                    Instantiate(prefabMuroG, transform.position, Quaternion.identity);
                    cont++;
                    break;

                case 2:
                    Instantiate(prefabMuroB, transform.position, Quaternion.identity);
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
                    cont++;
                    break;

                case 1:
                    Instantiate(prefabMuroCombinado2, transform.position, Quaternion.identity);
                    cont++;
                    break;

                case 2:
                    Instantiate(prefabMuroCombinado3, transform.position, Quaternion.identity);
                    cont++;
                    break;

                case 3:
                    Instantiate(prefabMuroCombinado4, transform.position, Quaternion.identity);
                    cont++;
                    break;

                case 4:
                    Instantiate(prefabMuroCombinado5, transform.position, Quaternion.identity);
                    cont++;
                    break;
                case 5:
                    Instantiate(prefabMuroCombinado6, transform.position, Quaternion.identity);
                    cont++;
                    break;
            }
        }
        //Instantiate(prefabMuroR, transform.position, Quaternion.identity);
    }
}
