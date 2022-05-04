using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownKill : MonoBehaviour
{
    //[SerializeField] Flashlight flashlightScript;
    [SerializeField] AllInOneCode AllInOneCodeScript;
    [SerializeField] PlayerHealth playerHealthScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        print("trigger kill");
        print(other.name);
        if (other.gameObject.tag == "KillClown" && AllInOneCodeScript.flashlightOn == true) 
        {
            print("KillClown");
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player") // && flashlightScript.flashlightOn == true
        {
            print("TakeLife");
            playerHealthScript.TakeLife();
            //Destroy(gameObject);
        }
    }
    

}
