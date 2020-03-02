using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckButonTouched : MonoBehaviour
{
    private bool buttonPressed;


    // Update is called once per frame

    private void Awake()
    {
        buttonPressed = true;
    }
    void Update()
    {
        if(Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Began && EventSystem.current.IsPointerOverGameObject())
        {
            buttonPressed = true;
            //print("Estoy tocando el boton");
        }
        else
        {
            buttonPressed = false;
            //print("No Estoy tocando el boton");
        }        
    }

    public bool isButtonPressed()
    {
        return buttonPressed;
    }
}
