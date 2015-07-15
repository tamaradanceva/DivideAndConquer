using UnityEngine;
using System.Collections;

public class SelectAndMove : MonoBehaviour {

	private bool selected=false;
	public Camera camera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (selected == true) {
			if(Input.GetMouseButtonDown(1)){
				//do something , pathfinding move on right click
						
			}
		} 

	}

	void OnMouseDown() {
		if (selected == false) {
			this.gameObject.renderer.material.color = Color.yellow;
			selected = true;
		} else {
			this.gameObject.renderer.material.color = Color.gray;
			selected=false;
		}

	}
}
