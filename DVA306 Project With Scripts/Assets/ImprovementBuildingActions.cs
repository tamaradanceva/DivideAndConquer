using UnityEngine;
using System.Collections;

public class ImprovementBuildingActions : MonoBehaviour {

	private ImprovementBuilding selectedImprovementBuilding;

	// Use this for initialization
	void Start () {
		GUIManager.onChooseTypeOfUpgrade += chooseType;
	}
	
	// Update is called once per frame
	void Update () {
		GUIManager gm = GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<GUIManager> ();
		if(gm.selectedImprovementBuilding!=null && gm.selectedImprovementBuilding.GetComponent<ImprovementBuilding>()!=null){
			selectedImprovementBuilding = gm.selectedImprovementBuilding.GetComponent<ImprovementBuilding>();
		}
	}

	void chooseType(int type){
		selectedImprovementBuilding.choice = type;
	}


}
