using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

	TextMesh text;

	void Start() {
		text = GetComponent<TextMesh> ();
		}

	void OnMouseDown() {
		Application.Quit ();
		}

	void OnMouseEnter() { text.color = Color.yellow;}

	void OnMouseExit() {
		text.color = Color.white;
		}
}
