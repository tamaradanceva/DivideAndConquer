using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WayPointList : MonoBehaviour {

	public List<GameObject> waypoints;
	// Use this for initialization
	void Start () {
		waypoints = new List<GameObject> ();
		foreach (Collider coll in GetComponentsInChildren<Collider>())
						if (coll.tag == "Waypoint")
								waypoints.Add (coll.gameObject);

		foreach (WaypointLinks waypoint in GetComponentsInChildren<WaypointLinks>())
						waypoint.Link ();
	}
}
