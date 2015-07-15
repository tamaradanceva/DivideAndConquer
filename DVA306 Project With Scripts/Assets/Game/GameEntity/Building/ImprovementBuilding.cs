using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImprovementBuilding : ZoneBuilding {

	protected float Timer;
	protected float timerAutoIncrement=50;


	//1-Autoincrement attackSpeed
	//2-Autoincrement mspeed
	//3-Autoimcrmeent range
	//4-Autoincrement health
	public int choice=0;

	public float attackSpeedIncrease=0.05f;
	public float mspeedIncrease=0.05f;
	public float rangeIncrease=0.05f;
	public float healthIncrease=1f;

	void Awake()
	{
		OnAwake ();
	}
	// Use this for initialization
	void Start () {
		OnStart ();
	}
	
	// Update is called once per frame
	void Update () {
		if (choice > 0) {
			Timer += Time.deltaTime;
			if (Timer >= timerAutoIncrement) {
				Timer=0;
				GameObject [] gos= GameObject.FindGameObjectsWithTag("Unit");
				List<Soldier> listSoldiers= new List<Soldier>();
				for(int i=0;i<gos.Length;i++){
					if(gos[i].GetComponent<Soldier>().team==0){
						listSoldiers.Add(gos[i].GetComponent<Soldier>());
					}

				}

				for(int i=0;i<listSoldiers.Count;i++){
					Soldier sld=listSoldiers[i];

						if(choice==1){
							if(sld.attackspeed>=(sld.attackspeedMax+attackSpeedIncrease)){
							sld.attackspeed-=attackSpeedIncrease;
							}
						}
						else if(choice==2){
							if(sld.mspeed<=(sld.mspeedMax-mspeedIncrease)){
							sld.mspeed+=mspeedIncrease;
							}
						}
						else if(choice==2){
							if(sld.range<=(sld.rangeMax-rangeIncrease)){
							sld.range+=rangeIncrease;
							}
						}
						else if(choice==3){
								if(sld.health<=(sld.maxHealth-healthIncrease)){
								sld.health+=healthIncrease;
							}
						}

				}
				
				
				
			}
		}


		if (health <= 0) {
			GameObject.Find ("Managers").GetComponent<BuildingManager>().MaxIBuildings--;
				}
		OnUpdate ();
				}


	void OnAwake ()
	{
		Timer = 0;
	}

	}

		

