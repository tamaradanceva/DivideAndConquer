using UnityEngine;
using System.Collections;

public class arrow : MonoBehaviour {

	public bool visible=true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!visible) {
			this.gameObject.SetActive (false);
				} else {
			this.gameObject.SetActive (true);
		}
	}
}
