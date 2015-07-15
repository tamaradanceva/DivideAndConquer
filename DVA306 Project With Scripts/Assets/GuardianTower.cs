using UnityEngine;
using System.Collections;

public class GuardianTower : Tower {

	// Use this for initialization
	void Start () {
		OnStart ();
	}
	
	// Update is called once per frame
	void Update () {
			OnUpdate();
		if (health <= 0) {
			RecallGuards();
				}

	}

	public void RecallGuards()
	{
		for (int i = 0; i < GameObject.Find ("Managers").GetComponent<UnitManager>().GetUnitsInTeam(1).Count; i++) {
			GameObject.Find ("Managers").GetComponent<UnitManager>().GetUnitsInTeam(1)[i].mtarget_pos = this.transform.position + new Vector3(Random.Range (0,10), 0, Random.Range (0,10));
				}
	}
}
