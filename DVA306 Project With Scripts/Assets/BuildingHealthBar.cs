using UnityEngine;
using System.Collections;

public class BuildingHealthBar : MonoBehaviour {

	private float health=0;
	private float maxHealth=0;
	
	public int offsetUp=6;
	// Use this for initialization
	void Start () {
		if (this.gameObject.GetComponentInParent<Tower> () != null) {
			maxHealth = this.gameObject.GetComponentInParent<Tower> ().maxHealth;
		} else if (this.gameObject.GetComponentInParent<ImprovementBuilding> () != null) {
			maxHealth = this.gameObject.GetComponentInParent<ImprovementBuilding> ().maxHealth;
		} else if (this.gameObject.GetComponentInParent<ZoneBuilding> () != null) {
			maxHealth = this.gameObject.GetComponentInParent<ZoneBuilding> ().maxHealth;
		}
		this.renderer.material.color = Color.green;
		this.transform.Rotate (new Vector3(90,90,0));
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponentInParent<ZoneBuilding> () != null) {
						health = this.gameObject.GetComponentInParent<ZoneBuilding> ().health;
				} else if (this.gameObject.GetComponentInParent<ImprovementBuilding> () != null) {
						health = this.gameObject.GetComponentInParent<ImprovementBuilding> ().health;
				} else if (this.gameObject.GetComponent<Tower> () != null) {
						health = this.gameObject.GetComponentInParent<Tower> ().health;
				}

		Vector3 vectorScale = new Vector3 (0.35f,2.7f,0.35f);
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
