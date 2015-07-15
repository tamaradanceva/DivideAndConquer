using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointLinks : MonoBehaviour {

	public List<GameObject> connections = new List<GameObject>();


	public void Link()
	{
		List<GameObject> waypoints = new List<GameObject> ();
		waypoints = GetComponentInParent<WayPointList> ().waypoints;
		foreach (GameObject waypoint in waypoints)
		{
			if (waypoint.collider.bounds.Intersects(collider.bounds)
			    && waypoint != gameObject)
			{
				connections.Add(waypoint);
			}
		}

	}

}
