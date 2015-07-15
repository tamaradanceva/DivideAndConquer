using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PathFinding : MonoBehaviour {
	
	Vector3 current_mTarget;
	public Queue<Vector3> path = new Queue<Vector3>();
	Unit unit;
	
	void Start(){ unit = GetComponent<Unit> ();
		current_mTarget = unit.mtarget_pos;
	}
	
	void Update()
	{
		if (unit.mtarget_pos != current_mTarget) {
			StartSearch();
		}
		
		if (path.Count > 0)
			if(transform.position.x == unit.mtarget_pos.x && transform.position.z == unit.mtarget_pos.z)
		{
			current_mTarget = unit.mtarget_pos = path.Dequeue();
		}
	}
	
	void StartSearch()
	{
		List<GameObject> start = new List<GameObject> ();
		GameObject goal = new GameObject ();
		Queue<Node> uncheckedPaths = new Queue<Node> ();
		path = new Queue<Vector3> ();
		
		foreach (GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint")) {
			if (waypoint.collider.bounds.Contains(new Vector3(transform.position.x, 1.9f, transform.position.z)))
				start.Add (waypoint);
			
			if (Vector3.Distance (unit.mtarget_pos, waypoint.transform.position)
			    < Vector3.Distance (unit.mtarget_pos, goal.transform.position))
				goal = waypoint;
		}
		
		foreach (GameObject node in start)
			if (node == goal)
				return; 
		
		Node current = new Node (goal);
		uncheckedPaths.Enqueue (current);
		bool finished = false;
		while (!finished) {
			foreach (GameObject link in current.Waypoint().GetComponent<WaypointLinks>().connections)
				uncheckedPaths.Enqueue (new Node (link, current));
			current = uncheckedPaths.Dequeue ();
			foreach(GameObject node in start)
				if (current.Waypoint() == node)
					finished = true;
		}
		
		current = current.Previous ();
		while (current.Previous() != null) {
			Debug.Log (" x: " + current.Waypoint ().transform.position.x +
			           " y: " + current.Waypoint ().transform.position.y +
			           " z: " + current.Waypoint ().transform.position.z);
			path.Enqueue (new Vector3 (current.Waypoint ().transform.position.x,
			                           Terrain.activeTerrain.SampleHeight (current.Waypoint ().transform.position), 
			                           current.Waypoint ().transform.position.z));
			current = current.Previous ();
		}
		
		path.Enqueue (unit.mtarget_pos);
		current_mTarget = unit.mtarget_pos = path.Dequeue ();
	}
}

class Node {
	Node previous;
	GameObject waypoint;
	
	public Node Previous(){
		return previous;
	}
	
	public GameObject Waypoint()
	{
		return waypoint;
	}
	
	public Node(GameObject waypoint)
	{this.waypoint = waypoint;
	}
	
	public Node(GameObject waypoint, Node parent):this(waypoint)
	{
		this.previous = parent;
	}
}


