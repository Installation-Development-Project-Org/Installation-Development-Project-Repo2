using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownTrigger : MonoBehaviour
{
    [SerializeField] GameObject clown;

    void Start()
    {
        if(clown != null)
        {
            clown.SetActive(false);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("trigger");
            if (clown != null)
            {
                clown.SetActive(true);
            }
        }
    }
}
