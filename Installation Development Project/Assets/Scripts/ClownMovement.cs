using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClownMovement : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    NavMeshAgent NMAgent;
    [SerializeField] float speed;


    void Start()
    {
        NMAgent = GetComponent<NavMeshAgent>();

        NMAgent.speed = speed;
        GoToWaypoint();
    }

    void Update()
    {
        NMAgent.destination = waypoints[1].transform.position;
    }

    void GoToWaypoint()
    {
        //NMAgent.SetDestination(waypoints[1].transform.position);
        NMAgent.destination = waypoints[1].transform.position;
    }
}
