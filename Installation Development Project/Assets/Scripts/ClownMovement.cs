using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClownMovement : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    NavMeshAgent NMAgent;
    //Animator anim;

    [SerializeField] float speed;
    //[SerializeField] float reachTargetRange;
    //[SerializeField] int currentWaypoint = 0;


    //float sightDistance = 9f;
    //Vector3 raycastDirection;
    //float currentSightAngle = 0f;
    //float scanSpeed = 150f;
    //float maxScanAngle = 45f;

    //private bool throwPotion;
    //public bool getThrowPotion
    //{
    //    get
    //    {
    //        return throwPotion;
    //    }
    //}

    void Start()
    {
        NMAgent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>(); - MAYBE NOT

        NMAgent.speed = speed;
        GoToWaypoint();
    }

    void Update()
    {
        //anim.SetFloat("MoveSpeed", NMAgent.velocity.magnitude * -2); -MAYBE NOT 

        //if (NMAgent.remainingDistance < reachTargetRange)
        //{
        //    GoToWaypoint();
        //}

        //ScanForPlayer();
    }

    void GoToWaypoint()
    {
        //currentWaypoint++;
        //if (currentWaypoint >= waypoints.Length)
        //{
        //    currentWaypoint = 0;
        //}
        NMAgent.SetDestination(waypoints[1].transform.position);
    }
}
