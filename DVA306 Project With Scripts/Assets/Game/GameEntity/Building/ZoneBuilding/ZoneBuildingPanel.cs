using UnityEngine;
using System.Collections;

public class ZoneBuildingPanel : MonoBehaviour , IPopUpBuildingsPanel {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		if(this.gameObject.GetComponent<ZoneBuilding>().team==0){
		disableOtherBuildingsPanels ();
		enablePanelInManager ();
		//GameObject basePlayer=GameObject.FindGameObjectWithTag("HomeBasePlayer");
		//Destroy (basePlayer);
		Debug.Log ("MouseDown Tower");
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().selectedZoneBuilding = this.gameObject;
		}
		}
	
	public void enablePanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawZoneBuildingPanel = true;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawZoneBuildingPanel = true;
		Debug.Log ("enabled panel improvement building");
	}
	
	public void disablePanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawZoneBuildingPanel = false;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawZoneBuildingPanel = false;
	}
	
	public void disableOtherBuildingsPanels(){
		GUIManager gm = GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ();
		gm.drawEnemyHomeBasePanel = false;
		gm.drawNeutralBasePanel = false;
		gm.drawTowerPanel = false;
		gm.drawHomeBasePanel = false;
		gm.drawImprovementBuildingPanel = false;
		gm.drawPlayerBasePanel = false;
		gm.drawSoldierMenu = false;
		gm.drawHeroMenu = false;
		gm.drawBPPanel = false;
	}
}

