using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class shark_movement : MonoBehaviour
{
    NavMeshAgent nm;
    Rigidbody rb;
    private Transform target;
    public Transform []waypoints;
    private int current_waypoint;
    public float speed, stop_distance; //pause_time;
    //[SerializeField]
    //public float current_timer;

    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        current_waypoint = 0;
        target = waypoints[current_waypoint];
    }

    void Update()
    {
        nm.speed = speed;
        nm.acceleration = speed / 3;
        nm.stoppingDistance = speed / 10;
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > stop_distance && waypoints.Length > 0)
        {
            //jak już będzie animacja to tutaj ustawić bool moving = true i bool idle = false
            target = waypoints[current_waypoint];
        }
        else if (distance <= stop_distance && waypoints.Length > 0)
        {
            //if (current_timer > 0)
            //{
            //    current_timer -= 0.01f;
            //    //jak już będzie animacja to tutaj ustawić bool moving = false i bool idle = true
            //}
            //if (current_timer <= 0)
            //{
                current_waypoint++;
                if (current_waypoint >= waypoints.Length)
                {
                    current_waypoint = 0;
                }
                target = waypoints[current_waypoint];
                //current_timer = pause_time;
            //}
        }
        nm.SetDestination(target.position);
    }
}
