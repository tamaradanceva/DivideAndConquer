using UnityEngine;
using System.Collections;

public class BuildingPlatformPanel : MonoBehaviour , IPopUpBuildingsPanel {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		disableOtherBuildingsPanels ();
		enablePanelInManager ();
		//GameObject basePlayer=GameObject.FindGameObjectWithTag("HomeBasePlayer");
		//Destroy (basePlayer);
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().selectedBuildingPlatform = this.gameObject;

	}
	
	public void enablePanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawBPPanel = true;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawBPPanel = true;
	}
	
	public void disablePanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawBPPanel = false;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawBPPanel = false;
	}
	
	public void disableOtherBuildingsPanels(){
		GUIManager gm = GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ();
		gm.drawEnemyHomeBasePanel = false;
		gm.drawNeutralBasePanel = false;
		gm.drawTowerPanel = false;
		gm.drawHomeBasePanel = false;
		gm.drawZoneBuildingPanel = false;
		gm.drawPlayerBasePanel = false;
		gm.drawSoldierMenu = false;
		gm.drawHeroMenu = false;
		gm.drawImprovementBuildingPanel = false;
	}
}

