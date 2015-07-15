using UnityEngine;
using System.Collections;

public class HealthBarHero : MonoBehaviour {

	private float health=0;
	private float maxHealth=200;

	public float offsetUp=3f;

	public float team;
	// Use this for initialization
	void Start () {
		team = transform.parent.gameObject.GetComponent<Hero> ().team;
		this.renderer.material.color = Color.cyan;
		this.transform.Rotate (new Vector3(90,90,0));
		GameObject [] goHero1=GameObject.FindGameObjectsWithTag("Hero");
		for (int i=0; i<goHero1.Length; i++) {
			if(goHero1[i].GetComponent<Hero>().team==team){
				maxHealth=goHero1[i].GetComponent<Hero>().maxHealthHero;
			}		
			else 
				maxHealth=0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		health = this.gameObject.GetComponentInParent<Hero> ().health;
		
		Vector3 vectorScale = new Vector3 (0.4f,1f,0.4f);
		vectorScale.y *= (health / this.gameObject.GetComponentInParent<Hero> ().maxHealthHero);
		this.transform.localScale = vectorScale;
		Vector3 vectorPosition = this.transform.parent.position;
		vectorPosition += new Vector3 (0, offsetUp, 0);
		this.transform.position = vectorPosition;
		
		if (health <= 40) {
			this.renderer.material.color=Color.red;		
		}
	}
}
