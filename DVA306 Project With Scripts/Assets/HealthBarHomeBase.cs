using UnityEngine;
using System.Collections;

public class HealthBarHomeBase : MonoBehaviour {

	private float health=0;
	private float maxHealth=0;
	
	public int offsetUp=6;
	// Use this for initialization
	void Start () {
		maxHealth = this.gameObject.GetComponentInParent<HomeBase> ().maxHealth;
		this.renderer.material.color = Color.green;
		this.transform.Rotate (new Vector3(90,90,0));
	}
	
	// Update is called once per frame
	void Update () {
		health = this.gameObject.GetComponentInParent<HomeBase> ().health;

		Vector3 vectorScale = new Vector3 (0.4f,3f,0.4f);
		vectorScale.y *= (health / maxHealth);
		this.transform.localScale = vectorScale;
		Vector3 vectorPosition = this.transform.parent.position;
		vectorPosition += new Vector3 (0, offsetUp, 0);
		this.transform.position = vectorPosition;
		
		if (health <= 40) {
			this.renderer.material.color=Color.red;		
		}
	}
}
