using UnityEngine;
using System.Collections;

public class ValuesManager : MonoBehaviour {

	public int StartResource;
	public int Resources;

	void Awake()
	{
		Resources = StartResource;
	}


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Apparently, this makes you quit the game in the real version, but doesn't quite work in debug mode.
	public void Lose()
	{
		Debug.Log ("You Lost, GAME OVER!");
		Application.Quit ();
	}

	public void AddResources(int value)
	{
		Resources += value;
		Debug.Log ("Current amount of resources " + Resources.ToString());
	}

	public void SpendResources(int value)
	{
		Resources -= value;
	}
	public int GetResources()
	{
		return Resources;
	}

}
