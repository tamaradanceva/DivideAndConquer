using UnityEngine;
using System.Collections;

public class HomeBaseActions : MonoBehaviour {

	public int priceUpgradeDefence=5000;
	public int priceUpgradeReinforcement=6000;

	// Use this for initialization
	void Start () {

		//Wire all events here 
		GUIManager.OnUpgradeDefenceHomeBase += UpgradeDefenceHomeBase;
		GUIManager.isDefenceUpgradedHomeBase += isDefenceUpgraded;
		GUIManager.OnUpgradeReinforcementHomeBase += ReinforceHomeBase;
		GUIManager.isReinforcedHomeBase += isReinforced;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpgradeDefenceHomeBase(){
	
		if(GameObject.Find ("Managers").GetComponent<ValuesManager> ().Resources>=priceUpgradeDefence){
			GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceUpgradeDefence);
			GameObject basePlayer=GameObject.FindGameObjectWithTag("HomeBasePlayer");
			basePlayer.GetComponent<HomeBase> ().defence += 5;
		
		}

	}

	//check if max defence is reached
	bool isDefenceUpgraded(){
		GameObject basePlayer=GameObject.FindGameObjectWithTag("HomeBasePlayer");
		if(basePlayer.GetComponent<HomeBase>().defence==basePlayer.GetComponent<HomeBase>().maxDefence){
			return true;
		}
		else {
			return false;
		}

	}

	void ReinforceHomeBase(){

		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceUpgradeReinforcement){
			GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceUpgradeReinforcement);
			GameObject basePlayer = GameObject.FindGameObjectWithTag ("HomeBasePlayer");
			basePlayer.GetComponent<HomeBase> ().reinforcement += 10;
		}
	}

	//check if max reinforcement is reached
	bool isReinforced(){
		GameObject basePlayer=GameObject.FindGameObjectWithTag("HomeBasePlayer");
		if(basePlayer.GetComponent<HomeBase>().reinforcement==basePlayer.GetComponent<HomeBase>().maxReinforcement){
			return true;
		}
		else {
			return false;
		}

	}
}
