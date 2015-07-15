using UnityEngine;
using System.Collections;

public class MinimapGameObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject mapBounds;
		if (this.gameObject.tag == "Hero") {
			mapBounds =GameObject.CreatePrimitive(PrimitiveType.Sphere);

		} else {
			mapBounds = GameObject.CreatePrimitive (PrimitiveType.Cube);
		}
		mapBounds.name="mapBounds";
		Destroy(mapBounds.GetComponent<Collider>());
		mapBounds.transform.parent=transform;
		mapBounds.layer=8;
		mapBounds.transform.localScale=new Vector3(3,3,3);
		mapBounds.transform.localPosition=new Vector3(0,4,0);
		if(this.gameObject.tag=="HomeBasePlayer"){
			mapBounds.renderer.material.color=Color.green;
			mapBounds.transform.localScale=new Vector3(5,5,5);
		}
		else if(this.gameObject.tag=="HomeBaseEnemy"){
			mapBounds.renderer.material.color=Color.red;
			mapBounds.transform.localScale=new Vector3(5,5,5);
		}
		else if (this.gameObject.tag.Contains("Building") || this.gameObject.tag.Contains("building")){
			if(this.gameObject.GetComponent<GameEntity>().team==0){
			mapBounds.renderer.material.color=Color.green;
			}
			else {
				mapBounds.renderer.material.color=Color.red;
			}

		}
		else if (this.gameObject.tag=="NeutralBase"){
			mapBounds.renderer.material.color=Color.white;
		}
		else if(this.gameObject.tag=="Hero"){
			if(this.gameObject.GetComponent<Hero>().team==0){
			mapBounds.renderer.material.color=Color.green;
			}
			else {
				mapBounds.renderer.material.color=Color.red;
			}
			mapBounds.transform.localScale=new Vector3(7,7,7);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
