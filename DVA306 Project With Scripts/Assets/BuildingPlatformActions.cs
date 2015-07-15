using UnityEngine;
using System.Collections;

public class BuildingPlatformActions : MonoBehaviour {

	private BuildingPlatform buildingPlatform;

	public int priceImprovementBuilding=9800;
	public int priceTower=8000;

	// Use this for initialization
	void Start () {
		GUIManager.onBuildImprovementBuilding += placeImprovementBuilding;
		GUIManager.onBuildTower += placeTower;
	}
	
	// Update is called once per frame
	void Update () {
		GUIManager gm = GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ();
		if(gm.selectedBuildingPlatform!=null && gm.selectedBuildingPlatform.GetComponent<BuildingPlatform>()!=null){
			buildingPlatform = gm.selectedBuildingPlatform.GetComponent<BuildingPlatform>();
		}
	}

	public void placeImprovementBuilding(){
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceImprovementBuilding) {
			GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceImprovementBuilding);
						if (!buildingPlatform.buildingPlaced && !buildingPlatform.buildingFinished && buildingPlatform.type == 0) {
								Vector3 pos = buildingPlatform.transform.position + buildingPlatform.offset;
								pos.y = 1.7f;
								pos.x -= 0.5f;
								Vector3 dustOffset = new Vector3 (0, 1, 0);
								GameObject d = (GameObject)Instantiate (buildingPlatform.dustPrefab, pos + dustOffset, Quaternion.identity);
								buildingPlatform.dust = d;
								GameObject b = (GameObject)Instantiate (buildingPlatform.improvementBuildingPrefab, pos, Quaternion.identity);
								b.transform.parent = buildingPlatform.gameObject.transform;
								buildingPlatform.building = b;
								buildingPlatform.buildingPlaced = true;
								buildingPlatform.type = 1;
								GameObject stage = GameObject.FindGameObjectWithTag ("Stage");
								stage.GetComponent<Stage> ().numOfImprovementBuildings--;
						}
				}
	}
	
	public void placeTower(){
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceTower) {
						GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceTower);
						if (!buildingPlatform.buildingPlaced && !buildingPlatform.buildingFinished && buildingPlatform.type == 0) {
								Vector3 pos = buildingPlatform.transform.position + buildingPlatform.offset;
								pos.y = 3.3f;
								Vector3 dustOffset = new Vector3 (0, 1, 0);
								GameObject d = (GameObject)Instantiate (buildingPlatform.dustPrefab, pos + dustOffset, Quaternion.identity);
								buildingPlatform.dust = d;
								GameObject b = (GameObject)Instantiate (buildingPlatform.towerPrefab, pos, Quaternion.identity);
								b.transform.parent = buildingPlatform.gameObject.transform;
								buildingPlatform.building = b;
								buildingPlatform.buildingPlaced = true;
								buildingPlatform.type = 2;	
								GameObject stage = GameObject.FindGameObjectWithTag ("Stage");
								stage.GetComponent<Stage> ().numOfTowers--;
						}
				}
		
	}


}
