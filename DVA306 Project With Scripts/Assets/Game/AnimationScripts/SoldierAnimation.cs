using UnityEngine;
using System.Collections;

public class SoldierAnimation : MonoBehaviour {

	protected Animator animator;
	Vector3 previousPosition;
	Transform parent;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		parent = GetComponentInParent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!animator.GetBool ("running") && previousPosition != parent.transform.position)
						animator.SetBool ("running", true);
				else
						animator.SetBool ("running", false);
		previousPosition = parent.transform.position;

	}
}
