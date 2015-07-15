using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingManager : MonoBehaviour {

	 List<List<ZoneBuilding>> buildingList;
	//maximum for improvement buildings
	public int MaxIBuildings;

		void Awake()
		{
		MaxIBuildings = 3;
		buildingList = new List<List<ZoneBuilding>> ();
		for (int i = 0; i < GameObject.Find("Managers").GetComponent<UnitManager>().nrteams; i++) {
			buildingList.Add (new List<ZoneBuilding>());
				}
		GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");

		for (int i = 0; i < buildings.Length; i++)
		{
			ZoneBuilding u = buildings[i].GetComponent<ZoneBuilding>();
			AddBuilding(u, u.team);
		}

		}
	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
		for (int i = 0; i < GameObject.Find("Managers").GetComponent<UnitManager>().nrteams; i++) {
				for (int j = 0; j < buildingList[i].Count; j++) {
				if(buildingList[i][j].health <= 0)
				{
					if (!buildingList[i][j].captureAble) {
                        Debug.Log("DEAD------------------------");
						GameObject.Destroy(buildingList[i][j].gameObject);

					}
					buildingList[i].RemoveAt (j);
				}
				}
			}
	}

	public void DisableSpawners(int team)
	{
		for (int i = 0; i < buildingList[team].Count; i++) {
			buildingList[team][i].MainSpawner = false;
				}
		}

	public void AddBuilding(ZoneBuilding z, int team)
	{
		z.team = team;
		buildingList [z.team].Add (z);
		}

//	public List<List<ZoneBuilding>> BuildingList
//	{
//		get
//		{
//			return buildingList;
//		}
//		set
//		{
//			buildingList = value;
//				}
//	}

	public void ChangeTeam(ZoneBuilding z)
	{
		if (z.team == 0) {
			z.team = 1;
			AddBuilding(z,z.team);
		}
		else {
			z.team = 0;
			AddBuilding(z,z.team);

		}
		Debug.Log ("Team changed!");
	}

	public void findBuildingTargets(Unit u, int listnr)
	{
		for (int i = 0; i < buildingList.Count; i++)
		{
			if (i == listnr)
				continue;
			for (int j = 0; j < buildingList[i].Count; j++)
			{
				ZoneBuilding target = buildingList[i][j];
				float distance = (target.transform.position - u.transform.position).magnitude;
				if (distance <= u.range)
				{
					u.mtarget_gameentity = target;
				}
			}
		}

	}


	
}
