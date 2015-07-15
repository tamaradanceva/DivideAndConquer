using UnityEngine;
using System.Collections;

public class ZoneBuilding : GameEntity {
	
	public GameObject object2Spawn;
	protected float StartTimer;
	protected float StartTimer2;
	public int Income;
	public bool MainSpawner = false;
	public float IncomeTimer = 5;
	public float SpawnTimer = 3;
	public bool captureAble = false;

	public float maxHealth=500;
	public int numSpawnUpgrades=0;
	public int numIncomeUpgrades=0;


	void Awake()
	{

		}

	void Start(){
		captureAble = true;
		OnStart ();
		}

	protected void OnAwake ()
	{
		StartTimer = 0;
		StartTimer2 = 0;
		}

	protected void OnStart()
	{
	
		}

	// Update is called once per frame
	void Update()
	{
		if (health <= 0) {
			if(this.team==1){
				//increase cap
				GameObject stage=GameObject.FindGameObjectWithTag("Stage");
				stage.GetComponent<Stage>().numOfTowers++;
				stage.GetComponent<Stage>().numOfImprovementBuildings++;

			}
			GameObject.Find ("Managers").GetComponent<BuildingManager>().ChangeTeam(this.GetComponent<ZoneBuilding>());
			MainSpawner = false;
			health = 700;
				}
		OnUpdate ();
	}
	protected void OnUpdate() {
		//The interval of income addition, also only generates resources when friendly.
		if (team == 0) {
						StartTimer2 += Time.deltaTime;
						if (StartTimer2 >= IncomeTimer) {
								GameObject.Find ("Managers").GetComponent<ValuesManager> ().AddResources (Income);
								StartTimer2 = 0;
						}
				}

		//If it's the main spawner, it will continue to spawn units.
			if (MainSpawner) {
			StartTimer += Time.deltaTime;
			if (StartTimer >= SpawnTimer) {
				GameObject newUnit = Instantiate(object2Spawn, transform.position + new Vector3(Random.Range(-5,5),-1.6f,Random.Range(-5,5)), Quaternion.identity) as GameObject;
			GameObject.Find ("Managers").GetComponent<UnitManager>().AddUnit(newUnit.GetComponent<Unit>(), team);
			StartTimer = 0;
			}
		
		}

}

//	public void IncreaseIncome(int value){
//		Income += value;
//		}

	//Set current spawner as the main spawner.
	public void SetMainSpawner(int team)
	{
		GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<BuildingManager> ().DisableSpawners (team);
		this.MainSpawner = true;
	}


	

}