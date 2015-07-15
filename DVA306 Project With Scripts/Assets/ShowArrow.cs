using UnityEngine;
using System.Collections;

public class ShowArrow : MonoBehaviour {


	public GameObject arrowPrefab;

	private GameObject arrow;

	public float offsetUp=0;

	// Use this for initialization
	void Start () {
		if (this.gameObject.tag == "HomeBasePlayer") {
						offsetUp = 19.8f;
				} else if (this.gameObject.tag == "Building") {
						offsetUp = 8f;		
				} else if (this.gameObject.tag == "Unit") {
						offsetUp = 5f;
				} else if (this.gameObject.tag == "Hero") {
						offsetUp = 5f;
				}
		Vector3 pos = this.gameObject.transform.position;
		pos.y = offsetUp;
		arrow=(GameObject)Instantiate (arrowPrefab, pos, Quaternion.identity);
					
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		arrow.GetComponent<arrow> ().visible = true;
	}

}
