using System.Collections.Generic;
using UnityEngine;

public class PlatformPathing : MonoBehaviour
{
	[SerializeField] private List<Transform> waypoints = null;
	[SerializeField] private float moveSpeead = 0;

	private int waypointIndex = 0;

	private void Start()
	{
		transform.position = waypoints[waypointIndex].transform.position;
	}

	private void Update()
	{
		Move();
	}
	
	private void Move()
	{
		if (waypointIndex <= waypoints.Count - 1)
		{
			var targetPosition = waypoints[waypointIndex].transform.position;
			var movementThisFrame = moveSpeead * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

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
