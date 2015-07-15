using UnityEngine;
using System.Collections;

public class MoveCam : MonoBehaviour {

	public GUIStyle styleCursorBox; 
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) { 
			RaycastHit hit;
			
			Ray ray = this.camera.ScreenPointToRay (Input.mousePosition);
			
			if (Physics.Raycast (ray, out hit)) {
				Vector3 pos= hit.point;
				pos.y=GameObject.FindWithTag ("MainCamera").transform.position.y;
				
				Camera cam = GameObject.FindWithTag ("MainCamera").camera;
				pos.z-=calculateOffset()-80;
				//	pos.x+-=cam.rect.height / 2+calculateOffset()/2-cam.rect.width/2;
				GameObject.FindWithTag ("MainCamera").transform.position = pos;
			}
			
			
			
		}
		
	}
	
	void OnGUI(){
		
		
		Vector2 origin = new Vector2 (Input.mousePosition.x, Screen.height - Input.mousePosition.y);
		origin.x -= Input.mousePosition.x - 5;
		origin.y += Input.mousePosition.z + 5;
		
		GUI.Box (new Rect (origin.x, origin.y, 10, 10), "", styleCursorBox);
		
		
		
		
		
	}
	
	
	float calculateOffset(){
		// only allowed rotation on the x axis(range: 0-90 degrees) in order to calculate the offset correctly
		// get the complementary angle 
		float angle = 90-this.gameObject.transform.rotation.x;
		float heightCam= GameObject.FindWithTag ("MainCamera").transform.position.y;
		// as a result of a corresponding angle
		float hypotenuse = heightCam / Mathf.Sin (this.gameObject.transform.rotation.x);
		float offset = Mathf.Sin (angle) * hypotenuse;
		
		
		Camera cam = GameObject.FindWithTag ("MainCamera").camera;
		
		
		float arg = cam.fieldOfView * 0.5f * Mathf.Deg2Rad;
		float frustumHeight = 2.0f * hypotenuse * Mathf.Tan(arg);
		var frustumWidth = frustumHeight * cam.aspect;
		
		// plus half the width of the rectangle to be more accurate
		offset += cam.rect.width / 2;
		
		return offset;
		
	}
}
