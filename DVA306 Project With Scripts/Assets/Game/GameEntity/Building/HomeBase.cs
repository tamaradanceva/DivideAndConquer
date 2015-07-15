using UnityEngine;
using System.Collections;

public class HomeBase : ZoneBuilding {

	public float defence=5; 
	public float maxDefence = 50;

	public float reinforcement=10;
	public float maxReinforcement=50;

	void Awake()
	{
		OnAwake();
	}

	// Use this for initialization
	void Start () {
		OnStart ();
		health = 700;
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 50 && defence > 0) {
		//spawn soldiers around 		
		
		}
		if (health <= 0 && team == 0) {
			if(health<=0 && reinforcement>0){
				reinforcement=0;
				health+=reinforcement*10;
			}
			else {
			GameObject.Find("Managers").GetComponent<ValuesManager>().Lose();
			}
		}
		OnUpdate ();
	}


}
