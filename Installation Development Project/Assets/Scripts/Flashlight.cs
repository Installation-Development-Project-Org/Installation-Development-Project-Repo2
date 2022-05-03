using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    public bool flashlightOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O)) //Light sensor thing is off
        {
            print("light On");
            flashlight.SetActive(true);
            flashlightOn = true;
        }
        else
        {
            flashlight.SetActive(false);
            flashlightOn = false;
        }
    }
}
