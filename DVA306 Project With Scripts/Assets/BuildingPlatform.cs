using UnityEngine;
using System.Collections;

public class BuildingPlatform : MonoBehaviour {

	public GameObject improvementBuildingPrefab;
	public GameObject towerPrefab;
	public GameObject dustPrefab;


	public bool buildingPlaced=false;
	public bool buildingFinished=false;
	public GameObject building;
	public GameObject dust;
	//type=1 for improvement building
	//type=2 for tower
	public int type=0;
	public int timeToFinishTower=7;
	public int timeToFinishImprovementBuilding=9;

	public Vector3 offset= new Vector3(0,0,0);

	protected float Timer;


	// Use this for initialization
	void Start () {
//		placeTower ();
	}
	
	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;
		if (type == 1) {
			if(Timer>=timeToFinishImprovementBuilding)	{
				Destroy(dust);
				dust=null;
				buildingFinished=true;
			}
		}
		if (type == 2) {
			if(Timer>=timeToFinishTower)	{
				Destroy(dust);
				dust=null;
				buildingFinished=true;
			}			
		}
	}

	void OnAwake ()
	{
		Timer = 0;
	}

	void OnMouseDown(){
	}

	// call this method if parent of tower or improvement building is a building platform
	public void destroyBuilding(){
		type = 0;
		building = null;
		dust = null;
	}
}
