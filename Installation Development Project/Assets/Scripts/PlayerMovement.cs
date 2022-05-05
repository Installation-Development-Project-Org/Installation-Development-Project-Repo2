using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    NavMeshAgent NMAgent;
    float speed = 0.005f;
    float time;


    void Start()
    {
        NMAgent = GetComponent<NavMeshAgent>();

        NMAgent.speed = speed;
    }


    public void Move()
    {
        print("moving");
        time = Time.time * speed * 0.0005f; 
        transform.position = Vector3.Lerp(transform.position, waypoints[1].transform.position, time);
    }

    public void StopMoving()
    {
        print("stopped");
        transform.position = gameObject.transform.position;
    }
}
