using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    public bool flashlightOn;

    void Update()
    {
        if (Input.GetKey(KeyCode.O)) //Light sensor thing is on
        {
            /*print("light On");
            flashlight.SetActive(true);
            flashlightOn = true;*/
            LightOn();
        }
        else //Light sensor thing is off
        {
            flashlight.SetActive(false);
            flashlightOn = false;
        }


    }
    public void LightOn()
    {
        print("light On");
        flashlight.SetActive(true);
        flashlightOn = true;
    }

    public void LightOFf()
    {
        flashlight.SetActive(false);
        flashlightOn = false;
    }
}
