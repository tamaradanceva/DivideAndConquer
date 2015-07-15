using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	TextMesh text;
	
	void Start() {
		text = GetComponent<TextMesh> ();
	}
	
	void OnMouseDown() {
		Game.gameover = false;
		Application.LoadLevel (1);
	}

	void OnMouseEnter() { text.color = Color.yellow;}
	
	void OnMouseExit() {
		text.color = Color.white;
	}
}
