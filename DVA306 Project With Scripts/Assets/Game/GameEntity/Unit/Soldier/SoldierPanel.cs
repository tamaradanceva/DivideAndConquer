using UnityEngine;
using System.Collections;

public class SoldierPanel : MonoBehaviour, IPopUpUnitsPanel {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if(this.gameObject.GetComponent<Soldier>().team==0){
		disableOtherUnitPanels();
		enableUnitPanelInManager();
		//GameObject basePlayer=GameObject.FindGameObjectWithTag("HomeBasePlayer");
		//Destroy (basePlayer);
		Debug.Log ("MouseDown Tower");
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().selectedSoldier = this.gameObject;
		}
		}
	
	public void enableUnitPanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawSoldierMenu = true;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawSoldierMenu = true;
		Debug.Log ("enabled panel improvement building");
	}
	
	public void disableUnitPanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawSoldierMenu= false;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawSoldierMenu = false;
	}
	
	public void disableOtherUnitPanels(){
		GUIManager gm = GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ();
		gm.drawEnemyHomeBasePanel = false;
		gm.drawHomeBasePanel = false;
		gm.drawImprovementBuildingPanel = false;
		gm.drawNeutralBasePanel = false;
		gm.drawPlayerBasePanel = false;
		gm.drawTowerPanel=false;
		gm.drawZoneBuildingPanel=false;
		gm.drawHeroMenu = false;
		gm.drawBPPanel = false;
	}
}
