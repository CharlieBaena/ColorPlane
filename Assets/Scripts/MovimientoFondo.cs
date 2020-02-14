using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFondo : MonoBehaviour
{
    private Material myMaterial;//, myMateria2;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset = myMaterial.mainTextureOffset + Vector2.right * 0.5f * Time.deltaTime;  // --->(1,0) * 0.5 ....
    }

    public void CambiarFondo()
    {
        print("mierda");
        //myMaterial = myMateria2;
    }
}
