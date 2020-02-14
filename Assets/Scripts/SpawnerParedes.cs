using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerParedes : MonoBehaviour
{
    public GameObject prefabMuroR,prefabMuroG,prefabMuroB,
                    prefabMuroCombinado1, prefabMuroCombinado2, prefabMuroCombinado3,
                    prefabMuroCombinado4, prefabMuroCombinado5, prefabMuroCombinado6;
    public float  tiempoEntreSpawns;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstaculo", 0F, tiempoEntreSpawns);
    }

    void SpawnObstaculo()
    {
        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                Instantiate(prefabMuroR, transform.position, Quaternion.identity);
                break;

            case 1:
                Instantiate(prefabMuroG, transform.position, Quaternion.identity);
                break;

            case 2:
                Instantiate(prefabMuroB, transform.position, Quaternion.identity);
                break;
        }
        //Instantiate(prefabMuroR, transform.position, Quaternion.identity);
    }
}
