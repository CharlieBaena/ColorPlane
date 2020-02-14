using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerParedes : MonoBehaviour
{
    public GameObject prefabMuroR,prefabMuroG,prefabMuroB,
                    prefabMuroCombinado1, prefabMuroCombinado2, prefabMuroCombinado3,
                    prefabMuroCombinado4, prefabMuroCombinado5, prefabMuroCombinado6;
    public float spawnRandomRange, tiempoEntreSpawns;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstaculo", 0F, tiempoEntreSpawns);
    }

    void SpawnObstaculo()
    {

        Instantiate(prefabMuroR, transform.position, Quaternion.identity);
    }
}
