using UnityEngine;
using System.Collections;

public class HeroPanel : MonoBehaviour, IPopUpUnitsPanel {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		if(this.gameObject.GetComponent<Hero>().team==0){
		disableOtherUnitPanels();
		enableUnitPanelInManager();
		//GameObject basePlayer=GameObject.FindGameObjectWithTag("HomeBasePlayer");
		//Destroy (basePlayer);
		Debug.Log ("MouseDown Tower");
		}
	}
	public void enableUnitPanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawHeroMenu = true;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawHeroMenu = true;
		Debug.Log ("enabled panel improvement building");
	}
	
	public void disableUnitPanelInManager(){
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ().drawHeroMenu= false;
		GameObject.Find ("Managers").GetComponent<GUIManager> ().drawHeroMenu = false;
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
		gm.drawSoldierMenu = false;
		gm.drawBPPanel = false;
	}
}
