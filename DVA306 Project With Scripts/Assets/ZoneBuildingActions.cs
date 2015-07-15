using UnityEngine;
using System.Collections;

public class ZoneBuildingActions : MonoBehaviour {

	private ZoneBuilding selectedZoneBuilding;


	public int priceSpawnUpgrade=8000;
	public int priceIncomeUpgrade=4000;

	// Use this for initialization
	void Start () {
		GUIManager.onUpgradeZBIncomeTime += upgradeZBIncomeTime;
		GUIManager.getMaxIncomeTimeZB += getNumZBIncomeTimeU;
		GUIManager.onUpgradeZBSpawnTime += upgradeZBSpawnTime;
		GUIManager.getMaxSpawnTimeZB += getNumZBSpawnTimeU;
	}
	
	// Update is called once per frame
	void Update () {
		GUIManager gm = GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ();
		if(gm.selectedZoneBuilding!=null && gm.selectedZoneBuilding.GetComponent<ZoneBuilding>()!=null){
			selectedZoneBuilding = gm.selectedZoneBuilding.GetComponent<ZoneBuilding>();
		}
	}

	void upgradeZBSpawnTime(){
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceSpawnUpgrade) {
						GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceSpawnUpgrade);
						selectedZoneBuilding.SpawnTimer -= 1;
						selectedZoneBuilding.numSpawnUpgrades += 1;
				}

	}

	int getNumZBSpawnTimeU(){
		return  selectedZoneBuilding.numSpawnUpgrades;
	}

	void upgradeZBIncomeTime(){
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceIncomeUpgrade) {
						GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceIncomeUpgrade);
						selectedZoneBuilding.IncomeTimer -= 1;
						selectedZoneBuilding.numIncomeUpgrades += 1;
				}
	}

	int getNumZBIncomeTimeU(){
		return selectedZoneBuilding.numIncomeUpgrades;

	}

}
