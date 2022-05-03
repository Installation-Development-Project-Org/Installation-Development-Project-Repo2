using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    NavMeshAgent NMAgent;
    float speed = 0.2f;
    float time;


    void Start()
    {
        NMAgent = GetComponent<NavMeshAgent>();

        NMAgent.speed = speed;
        //NMAgent.acceleration = 0;
    }

    void Update()
    {
        //time = Time.deltaTime * speed * 0.2f;
        //transform.position = Vector3.Lerp(transform.position, waypoints[1].transform.position, time);
        
        /*
        if(Input.GetKey(KeyCode.P)) //Light sensor thing is off
        {
            //print("stopped");
            NMAgent.destination = gameObject.transform.position;
        }
        else
        {
            //print("moving");
            NMAgent.destination = waypoints[1].transform.position;
        }*/

        if (Input.GetKey(KeyCode.P)) //Light sensor thing is off
        {
            print("stopped");
            transform.position = gameObject.transform.position;
        }
        else
        {
            print("moving");
            time = Time.deltaTime * speed * 0.05f;
            transform.position = Vector3.Lerp(transform.position, waypoints[1].transform.position, time);
        }
    }
}
