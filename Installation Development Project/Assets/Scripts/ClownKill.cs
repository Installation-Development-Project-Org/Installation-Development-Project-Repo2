using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownKill : MonoBehaviour
{
    [SerializeField] AllInOneCode AllInOneCodeScript;
    [SerializeField] PlayerHealth playerHealthScript;

    private void OnTriggerEnter(Collider other)
    {
        print("trigger kill");
        print(other.name);
        if (other.gameObject.tag == "KillClown" && AllInOneCodeScript.flashlightOn == true) 
        {
            print("KillClown");
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player") 
        {
            print("TakeLife");
            playerHealthScript.TakeLife();
        }
    }
    

}
