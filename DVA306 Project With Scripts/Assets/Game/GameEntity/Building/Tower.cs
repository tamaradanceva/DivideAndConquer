using UnityEngine;
using System.Collections;

public class Tower : ZoneBuilding {


	// Use this for initialization
	GameObject towerUnit;
	public int tRange;
	public float tAtkSpeed;
	
	public float defence=5;
	public float maxDefence=50;
	public bool fireballsActivated=false;
	public GameObject psFireball;
	public GameObject bullet;

	//paid for the fireballs upgrade, it can switch between fireball and normal later without paying again
	public bool paid=false;

	void Start () {
		Vector3 pos = transform.position;
		pos.y = 0f;
		pos.x += 0.45f;
		pos.z -= 0.45f;
	    towerUnit = Instantiate(object2Spawn, pos, Quaternion.identity) as GameObject;
		towerUnit.GetComponent<Unit> ().range = tRange;
		towerUnit.GetComponent<Soldier> ().attackspeed = tAtkSpeed;
		towerUnit.transform.parent = this.transform;
		towerUnit.GetComponent<Unit> ().health = 700;
		towerUnit.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
		towerUnit.gameObject.tag = "Building";
		GameObject.Find ("Managers").GetComponent<UnitManager>().AddUnit(towerUnit.GetComponent<Unit>(), team);
//		towerUnit.GetComponent<Unit> ().renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (fireballsActivated == true) {

						towerUnit.GetComponent<Soldier> ().bullet = psFireball;
			
				} else {
			towerUnit.GetComponent<Soldier> ().bullet = bullet;
		}
	if (health <= 0) {
			if(defence>0){
				health+=defence*5;
			}
			else {
			
			Destroy();
			}
				}
}
	void Destroy()
	{
		towerUnit.GetComponent<Unit> ().health = 0;

	}
}
