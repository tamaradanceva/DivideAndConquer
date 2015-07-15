using UnityEngine;
using System.Collections;

public class HomeBasePanel : MonoBehaviour, IPopUpBuildingsPanel {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if(this.gameObject.GetComponent<HomeBase>().team==0){
		disableOtherBuildingsPanels ();
		enablePanelInManager ();
		Debug.Log ("MouseDown");
		}
	}

	public void enablePanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawHomeBasePanel = true;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawHomeBasePanel = true;
		Debug.Log ("enabled panel home base");
	}

	public void disablePanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawHomeBasePanel = false;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawHomeBasePanel = false;
	}

	public void disableOtherBuildingsPanels(){
		GUIManager gm = GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ();
		gm.drawEnemyHomeBasePanel = false;
		gm.drawNeutralBasePanel = false;
		gm.drawImprovementBuildingPanel = false;
		gm.drawTowerPanel = false;
		gm.drawZoneBuildingPanel = false;
		gm.drawPlayerBasePanel = false;
		gm.drawSoldierMenu = false;
		gm.drawHeroMenu = false;
		gm.drawBPPanel = false;
	}


}
