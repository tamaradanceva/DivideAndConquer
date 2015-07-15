using UnityEngine;
using System.Collections;

public class TowerPanel : MonoBehaviour , IPopUpBuildingsPanel {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		if(this.gameObject.GetComponent<Tower>().team==0){
		disableOtherBuildingsPanels ();
		enablePanelInManager ();
		Debug.Log ("MouseDown Tower");
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().selectedTower = this.gameObject;
		}
		}
	
	public void enablePanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawTowerPanel = true;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawTowerPanel = true;
		Debug.Log ("enabled panel home base");
	}
	
	public void disablePanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawTowerPanel = false;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawTowerPanel = false;
	}
	
	public void disableOtherBuildingsPanels(){
		GUIManager gm = GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ();
		gm.drawEnemyHomeBasePanel = false;
		gm.drawNeutralBasePanel = false;
		gm.drawImprovementBuildingPanel = false;
		gm.drawHomeBasePanel = false;
		gm.drawZoneBuildingPanel = false;
		gm.drawPlayerBasePanel = false;
		gm.drawSoldierMenu = false;
		gm.drawBPPanel = false;
		gm.drawHeroMenu = false;
	}
	
	
}
