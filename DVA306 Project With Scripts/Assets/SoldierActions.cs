using UnityEngine;
using System.Collections;

public class SoldierActions : MonoBehaviour {

	private GameObject selectedSoldier;

	public int priceEachSoldierUpgrade=3800;

	// Use this for initialization
	void Start () {
		GUIManager.onUpgradeSoldierSpeed += upgradeSoldierSpeed;
		GUIManager.onUpgradeSoldierAttack += upgradeSoldierAttack;
		GUIManager.onUpgradeSoldierRange += upgradeSoldierRange;
		GUIManager.onUpgradeSoldierHealth += upgradeSoldierHealth;
		GUIManager.getSoldierNumSpeedU += getNumSpeedUpgrades;
		GUIManager.getSoldierNumAttackU += getNumAttackUpgrades;
		GUIManager.getSoldierNumRangeU += getNumRangeUpgrades;
		GUIManager.getSoldierNumHealthU += getNumHealthUpgrades;

	}
	
	// Update is called once per frame
	void Update () {
		GUIManager gm = GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ();
		if(gm.selectedSoldier!=null){
			selectedSoldier = gm.selectedSoldier;
		}

	}

	void upgradeSoldierSpeed(){
		if(GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources()>=priceEachSoldierUpgrade){
			GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceEachSoldierUpgrade);
			selectedSoldier.GetComponent<Soldier> ().mspeed += 3;
			selectedSoldier.GetComponent<Soldier> ().numSpeedUpgrades += 1;
		}

	}
	void upgradeSoldierAttack(){
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceEachSoldierUpgrade) {
			GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceEachSoldierUpgrade);
						selectedSoldier.GetComponent<Soldier> ().attackspeed -= 0.3f;
						selectedSoldier.GetComponent<Soldier> ().numAttackUpgrades += 1;
				}
	}

	void upgradeSoldierRange(){
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceEachSoldierUpgrade) {
			GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceEachSoldierUpgrade);
						selectedSoldier.GetComponent<Soldier> ().range += 3;
						selectedSoldier.GetComponent<Soldier> ().numRangeUpgrades += 1;
				}
	}
	void upgradeSoldierHealth(){
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceEachSoldierUpgrade) {
			GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceEachSoldierUpgrade);
						selectedSoldier.GetComponent<Soldier> ().health += 5;
						selectedSoldier.GetComponent<Soldier> ().numHealthUpgrades += 1;
				}
	}

	int getNumSpeedUpgrades(){
		return selectedSoldier.GetComponent<Soldier> ().numSpeedUpgrades;
	}

	int getNumAttackUpgrades(){
		return selectedSoldier.GetComponent<Soldier> ().numAttackUpgrades;
	}

	int getNumRangeUpgrades(){
		return selectedSoldier.GetComponent<Soldier> ().numRangeUpgrades;
	}

	int getNumHealthUpgrades(){
		return selectedSoldier.GetComponent<Soldier> ().numHealthUpgrades;
	}

}
