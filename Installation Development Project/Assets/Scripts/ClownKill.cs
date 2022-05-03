using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownKill : MonoBehaviour
{
    [SerializeField] Flashlight flashlightScript;
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
        print("trigger");
        if (other.gameObject.tag == "KillClown" && flashlightScript.flashlightOn == true)
        {
            print("KillClown");
            Destroy(gameObject);
        }
    }
    

}
