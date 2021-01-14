﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPathing : MonoBehaviour {

    
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeead;
    int waypointIndex = 0;

	// Use this for initialization
	void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
	}
    

    // Update is called once per frame
    void Update ()
    {
        Move();
    }

    
    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeead * Time.deltaTime;
            transform.position = Vector2.MoveTowards
                (transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            waypointIndex = 0;
        }
    }
}
