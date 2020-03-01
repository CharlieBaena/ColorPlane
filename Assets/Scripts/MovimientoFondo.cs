using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFondo : MonoBehaviour
{
    private Material myMaterial;
    public Material myMaterial2;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset = myMaterial.mainTextureOffset + Vector2.right * speed * Time.deltaTime;  // --->(1,0) * 0.5 ....
    }

    public void CambiarFondo()
    {
        GetComponent<Renderer>().material = myMaterial2;
        myMaterial = myMaterial2;
    }
}
