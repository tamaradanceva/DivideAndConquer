using UnityEngine;
using System.Collections;

public class TowerActions : MonoBehaviour {

	private GameObject selectedTower;

	public int priceUpgradeDefence=4000;
	public int priceUpgradeFireballs=8000;

	// Use this for initialization
	void Start () {
		//Wire all events here 
		GUIManager.OnUpgradeDefenceTower += upgradeTowerDefence;
		GUIManager.isDefenceUpgradedMaxTower += isMaxTowerDefence;
		GUIManager.fireballsClickedTower += fireballClicked;
		GUIManager.getTowerFireballsActivated += getFireballStatus;

	}
	
	// Update is called once per frame
	void Update () {
		GUIManager gm = GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ();
		if(gm.selectedTower!=null){
			selectedTower = gm.selectedTower;
		}
	
	}

	void upgradeTowerDefence(){
	
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceUpgradeDefence) {
			GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceUpgradeDefence);
						selectedTower.GetComponent<Tower> ().defence += 5;
		}


	}

	bool isMaxTowerDefence(){
		if (selectedTower.GetComponent<Tower> ().defence == selectedTower.GetComponent<Tower> ().maxDefence) {
						return true;		
				} else {
			return false;		
		}
	
	}

	void fireballClicked(){
		if (selectedTower.GetComponent<Tower> ().fireballsActivated) {
						selectedTower.GetComponent<Tower> ().fireballsActivated = false;

				} else {

			if(selectedTower.GetComponent<Tower> ().paid==false){
				if(GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources()>=priceUpgradeFireballs){
					GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceUpgradeFireballs);
					selectedTower.GetComponent<Tower> ().paid=true;
					selectedTower.GetComponent<Tower> ().fireballsActivated = true;
				}
			}

		}

	}

	bool getFireballStatus(){
		return selectedTower.GetComponent<Tower> ().fireballsActivated;

	}
}
