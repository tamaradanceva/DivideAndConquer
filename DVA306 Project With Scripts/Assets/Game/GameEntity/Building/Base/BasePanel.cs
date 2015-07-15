using UnityEngine;
using System.Collections;

public class BasePanel : MonoBehaviour , IPopUpBuildingsPanel {
	
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
		Debug.Log ("MouseDown Tower");
	}
	
	public void enablePanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawPlayerBasePanel = true;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawPlayerBasePanel = true;
		Debug.Log ("enabled panel improvement building");
	}
	
	public void disablePanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawPlayerBasePanel= false;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawPlayerBasePanel = false;
	}
	
	public void disableOtherBuildingsPanels(){
		GUIManager gm = GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ();
		gm.drawEnemyHomeBasePanel = false;
		gm.drawNeutralBasePanel = false;
		gm.drawTowerPanel = false;
		gm.drawHomeBasePanel = false;
		gm.drawImprovementBuildingPanel = false;
		gm.drawZoneBuildingPanel = false;
		gm.drawSoldierMenu = false;
		gm.drawHeroMenu = false;
		gm.drawBPPanel = false;
	}
}