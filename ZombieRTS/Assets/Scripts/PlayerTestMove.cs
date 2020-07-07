using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestMove : MonoBehaviour
{

    public float speed = 10f;

    public Transform target;
    // private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //target = Waypoints.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        else
        {
            Vector3 dirToMove = target.position - transform.position;
            transform.Translate(dirToMove.normalized * speed * Time.deltaTime, Space.World);
        }

        //if (Vector3.Distance(transform.position, target.position) <= 0.3f)
        //{
        //    GetNextWayPoint();
        //}
    }

    void GetNextWayPoint()
    {
        //if (waypointIndex >= Waypoints.waypoints.Length)
        //{
        //    waypointIndex = 0;
        //    return;
        //}

        //target = Waypoints.waypoints[waypointIndex];

        //waypointIndex++;
    }
}
