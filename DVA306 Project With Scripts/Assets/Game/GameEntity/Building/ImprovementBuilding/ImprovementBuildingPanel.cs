using UnityEngine;
using System.Collections;

public class ImprovementBuildingPanel : MonoBehaviour , IPopUpBuildingsPanel {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		if(this.gameObject.GetComponent<ImprovementBuilding>().team==0){

		disableOtherBuildingsPanels ();
		enablePanelInManager ();
		//GameObject basePlayer=GameObject.FindGameObjectWithTag("HomeBasePlayer");
		//Destroy (basePlayer);
		Debug.Log ("MouseDown Tower");
		GameObject.Find ("Managers").GetComponent<GUIManager> ().selectedImprovementBuilding = this.gameObject;
		}
	}
	
	public void enablePanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawImprovementBuildingPanel = true;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawImprovementBuildingPanel = true;
		Debug.Log ("enabled panel improvement building");
	}
	
	public void disablePanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawImprovementBuildingPanel = false;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawImprovementBuildingPanel = false;
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
		gm.drawBPPanel = false;
	}
}
