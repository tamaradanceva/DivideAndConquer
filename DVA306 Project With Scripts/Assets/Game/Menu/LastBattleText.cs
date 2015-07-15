using UnityEngine;
using System.Collections;

public class LastBattleText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		guiText.text = Game.lastbattle;
	}
}
