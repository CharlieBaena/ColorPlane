using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBolas : MonoBehaviour
{
    public GameObject prefabMuroBolaRoja, prefabMuroBolaVerde, prefabMuroBolaAzul;
    public float tiempoEntreSpawns, spawnRandomRange;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstaculo", 0F, tiempoEntreSpawns);
    }

    void SpawnObstaculo()
    {
        int random = Random.Range(0, 3);
        Vector3 posicionVertical;

        posicionVertical.x = 0.0f;
        posicionVertical.y = Random.Range(-spawnRandomRange, +spawnRandomRange);
        posicionVertical.z = 0.0f;

        switch (random)
        {
            case 0:
                Instantiate(prefabMuroBolaRoja, transform.position + posicionVertical, Quaternion.identity);
                break;

            case 1:
                Instantiate(prefabMuroBolaVerde, transform.position + posicionVertical, Quaternion.identity);
                break;

            case 2:
                Instantiate(prefabMuroBolaAzul, transform.position + posicionVertical, Quaternion.identity);
                break;
        }
        //Instantiate(prefabMuroR, transform.position, Quaternion.identity);
    }
}
