using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseScript: MonoBehaviour {

	public float distance = 20;
	public float startTimer = 0;
	public int LinkedBase = 1;
	public float LMoveTimer;
	public float UMoveTimer;
	public int Readiness;

	private float MoveTimer;

	void Start(){
		MoveTimer = Random.Range (LMoveTimer, UMoveTimer);
	}

	void Update()
	{
		startTimer += Time.deltaTime;
		if (startTimer >= MoveTimer) {
			MoveUnits ();
			MoveTimer = Random.Range (LMoveTimer, UMoveTimer);
			startTimer = 0;
				}
	}

	void MoveUnits()
	{

		List<Unit> list = new List<Unit> ();
		for (int i = 0; i < GameObject.Find ("Managers").GetComponent<UnitManager> ().GetUnitsInTeam (1).Count; i++) {
			if (((this.transform.position - GameObject.Find ("Managers").GetComponent<UnitManager> ().GetUnitsInTeam (1)[i].transform.position).magnitude) <= distance && GameObject.Find ("Managers").GetComponent<UnitManager> ().GetUnitsInTeam (1)[i].gameObject.tag != "Building") {
				list.Add (GameObject.Find ("Managers").GetComponent<UnitManager> ().GetUnitsInTeam (1)[i]);
			}
				}
		if (list.Count >= Readiness) {
			for (int i = 0; i < list.Count; i++) {
				list[i].mtarget_pos = (GameObject.Find (LinkedBase.ToString()).GetComponent<BaseScript>().transform.position + new Vector3(Random.Range(0,5), 0, Random.Range (0,5)));
			}
				}

	}

}
