using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	
	//top menu
	public Texture topMenu;


	public Texture healthBar; 
	public Texture defenceBar;
	public Texture reinforcementBar;



	//hero menu resources 
	public GUISkin heroSkin;
	public Texture heroMenuTexture;
	 
	public Texture upgradeHeroHealth;
	public Texture upgradeHeroTarget;
	public Texture resourceIcon;
	public Texture avatar;
	
	
	//buildings menu resources 
	public GUISkin buildingsSkin;
	public Texture improvementBuilding;
	public Texture tower;
	public Texture mana;
	
	//Pop up contet menu, building & units all in one 
	
	//Building menus
	
	// pop up for Player Home Base 
	public bool drawHomeBasePanel=false;
	public GUISkin homeBasePanelSkin;
	public Texture homeBaseIcon;
	public Texture homeBaseDefenceUpgrade;
	public Texture homeBaseDefenceUpgradeDark;
	public Texture homeBaseReinforcementUpgrade;
	public Texture homeBaseReinforcementUpgradeDark;
	public bool maxDefence = false;
	public bool maxReinforcement = false;

	
	//pop up for Enemy Home Base
	public bool drawEnemyHomeBasePanel=false;
	public GUISkin enemyHomeBasePanelSkin;
	
	//pop up for neutral base
	public bool drawNeutralBasePanel=false;
	public GUISkin neutralBasePanelSkin;
	
	//pop up for zone building 
	public bool drawZoneBuildingPanel = false;
	public GUISkin zoneBuildingSkin;
	public Texture zoneBuildingIcon;
	public Texture zoneBuildingSpawnTimeUpgrade;
	public Texture zoneBuildingSpawnTimeUpgradeDark;
	public Texture zoneBuildinIncomeUpgrade;
	public Texture zoneBuildinIncomeUpgradeDark;
	public int numZBSpawnTimeU=3;
	public int numZBIncomeU=3;
	public float ZBHealth;
	public GameObject selectedZoneBuilding;

	
	//pop up for improvementBuilding
	public bool drawImprovementBuildingPanel = false;
	public GUISkin imporovementBuildingSkin;
	public Texture ibAttackSpeedUpgrade;
	public Texture ibAttackSpeedUpgradeDark;
	public Texture ibMovementSpeedUpgrade;
	public Texture ibMovementSpeedUpgradeDark;
	public Texture ibRangeUpgrade;
	public Texture ibRangeUpgradeDark;
	public Texture ibHealthUpgrade;
	public Texture ibHealthUpgradeDark;
	public Texture improvementBuildingIcon;
	bool selectedUpgrade=false;
	public GameObject selectedImprovementBuilding;


	
	//pop up tower
	public bool drawTowerPanel = false;
	public GUISkin towerBuildingSkin;
	public Texture towerUpgradeFireballs;
	public Texture towerUpgradeFireballsDark;
	public Texture towerUpgradeDefence;
	public Texture towerUpgradeDefenceDark;
	public Texture towerIcon;
	public bool maxTowerDefence=false;
	public bool fireball = false;
	public GameObject selectedTower;


	
	//pop up regular player base menu
	public bool drawPlayerBasePanel=false;
	public GUISkin playerBaseSkin;
	
	//Units menus
	
	//pop up soldier menu
	public bool drawSoldierMenu=false;
	public GUISkin soldierMenuSkin;
	public Texture soldierSpeedMovementUpgrade;
	public Texture soldierSpeedMovementUpgradeDark;
	public Texture soldierAttackSpeedUpgrade;
	public Texture soldierAttackSpeedUpgradeDark;
	public Texture soldierRangeUpgrade;
	public Texture soldierRangeUpgradeDark;
	public Texture soldierHealthUpgrade;
	public Texture soldierHealthUpgradeDark;
	public Texture soldierIcon;
	public int numMaxSpeedUpgrades=3;
	public int numMaxAttackUpgrades=3;
	public int numMaxRangeUpgrades = 3;
	public int numMaxHealthUpgrades=3;
	public float healthSoldier = 0;
	public GameObject selectedSoldier;
	
	//pop up hero menu
	public bool drawHeroMenu=false;
	public GUISkin heroMenuSkin;
	public Texture heroSpeedMovementUpgrade;
	public Texture heroSpeedMovementUpgradeDark;
	public Texture heroAttackSpeedUpgrade;
	public Texture heroAttackSpeedUpgradeDark;
	public Texture heroRangeUpgrade;
	public Texture heroRangeUpgradeDark;
	public Texture heroHealthUpgrade;
	public Texture heroHealthUpgradeDark;
	public Texture heroCommandUpgrade;
	public Texture heroCommandUpgradeDark;
	public Texture heroShieldUpgrade;
	public Texture heroShieldUpgradeDark;
	public Texture heroWeapon1Upgrade;
	public Texture heroWeapon1UpgradeDark;
	public Texture heroWeapon2Upgrade;
	public Texture heroWeapon2UpgradeDark;
	public Texture heroIcon;
	public int maxSpeedUpgrades=3;
	public int maxAttackUpgrades=3;
	public int maxRangeUpgrades = 3;
	public int maxHealthUpgrades=3;
	public int maxCommandUpgrades=3;
	public int maxShieldUpgrades=3;
	public int maxWeapon1Upgrades = 3;
	public int maxWeapon2Upgrades=3;
	public float healthHero = 0;

	//pop up buildings platform menu
	public bool drawBPPanel=false;
	public GUISkin BPMenuSkin;
	public Texture BPIcon;
	public Texture iconImprovementBuilding;
	public Texture iconImprovementBuildingDark;
	public Texture iconTowerBuilding;
	public Texture iconTowerBuildingDark;
	public GameObject selectedBuildingPlatform;
	

	// screen width and height
	private float screenWidth=Screen.width;
	private float screenHeight=Screen.height;
	
	//context menu params
	public float contextMenuWidth=365;
	public float contextMenuHeight=150; 
	public float contextMenuX=250;
	public float contextMenuY=450;
	
	//health bar hero params
	public float healthBarMaxWidth=10;
	public float healthBarWidth;
	public float healthBarHeight=1;
	
	
	
	//strings
	private string incomeText;
	
	
	//buildings events 
	
	//homeBase events 
	public delegate void upgradeDefenceHomeBase();
	public static event upgradeDefenceHomeBase OnUpgradeDefenceHomeBase;

	public delegate void upgradeReinforcementHomeBase();
	public static event upgradeReinforcementHomeBase OnUpgradeReinforcementHomeBase;

	public delegate bool isDefenceUpgradedHB();
	public static event isDefenceUpgradedHB isDefenceUpgradedHomeBase;

	public delegate bool isReinforcedHB();
	public static event isReinforcedHB isReinforcedHomeBase;

	//tower events

	public delegate void upgradeDefenceTower();
	public static event upgradeDefenceTower OnUpgradeDefenceTower;

	public delegate bool isDefenceUpgradedTower();
	public static event isDefenceUpgradedTower isDefenceUpgradedMaxTower;

	public delegate void towerFireballsClicked();
	public static event towerFireballsClicked fireballsClickedTower;

	public delegate bool towerFireballsActivated();
	public static event towerFireballsActivated getTowerFireballsActivated;


	//soldier events

	public delegate void upgradeSoldierSpeed();
	public static event upgradeSoldierSpeed onUpgradeSoldierSpeed;

	public delegate int getSoldierNumSpeedUpgrades();
	public static event getSoldierNumSpeedUpgrades getSoldierNumSpeedU;

	public delegate void upgradeSoldierAttack();
	public static event upgradeSoldierSpeed onUpgradeSoldierAttack;

	public delegate int getSoldierNumAttackUpgrades();
	public static event getSoldierNumAttackUpgrades getSoldierNumAttackU;

	public delegate void upgradeSoldierRange();
	public static event upgradeSoldierSpeed onUpgradeSoldierRange;

	public delegate int getSoldierNumRangeUpgrades();
	public static event getSoldierNumRangeUpgrades getSoldierNumRangeU;

	public delegate void upgradeSoldierHealth();
	public static event upgradeSoldierHealth onUpgradeSoldierHealth;

	public delegate int getSoldierNumHealthUpgrades();
	public static event getSoldierNumHealthUpgrades getSoldierNumHealthU;

	//hero updates 

	public delegate void upgradeHeroSpeed();
	public static event upgradeHeroSpeed onUpgradeHeroSpeed;
	
	public delegate int getHeroNumSpeedUpgrades();
	public static event getHeroNumSpeedUpgrades getHeroNumSpeedU;
	
	public delegate void upgradeHeroAttack();
	public static event upgradeHeroSpeed onUpgradeHeroAttack;
	
	public delegate int getHeroNumAttackUpgrades();
	public static event getHeroNumAttackUpgrades getHeroNumAttackU;
	
	public delegate void upgradeHeroRange();
	public static event upgradeHeroSpeed onUpgradeHeroRange;
	
	public delegate int getHeroNumRangeUpgrades();
	public static event getHeroNumRangeUpgrades getHeroNumRangeU;
	
	public delegate void upgradeHeroHP();
	public static event upgradeHeroHP onUpgradeHeroHealth;
	
	public delegate int getHeroNumHealthUpgrades();
	public static event getHeroNumHealthUpgrades getHeroNumHealthU;

	public delegate void upgradeHeroCommand();
	public static event upgradeHeroCommand onUpgradeHeroCommand;

	public delegate int getHeroNumCommandUpgrades();
	public static event getHeroNumRangeUpgrades getHeroNumCommandU;

	public delegate void upgradeHeroShield();
	public static event upgradeHeroShield onUpgradeHeroShield;

	public delegate int getHeroNumShieldUpgrades();
	public static event getHeroNumShieldUpgrades getHeroNumShieldU;

	public delegate void upgradeHeroWeapon1();
	public static event upgradeHeroWeapon1 onUpgradeHeroWeapon1;

	public delegate void upgradeHeroWeapon2();
	public static event upgradeHeroWeapon2 onUpgradeHeroWeapon2;

	public delegate int getHeroNumWeapon1Upgrades();
	public static event getHeroNumWeapon1Upgrades getHeroNumWeapon1U;

	public delegate int getHeroNumWeapon2Upgrades();
	public static event getHeroNumWeapon2Upgrades getHeroNumWeapon2U;


	//zone buildings events

	public delegate void upgradeZBSpawnTime();
	public static event upgradeZBSpawnTime onUpgradeZBSpawnTime;

	public delegate int numMaxSpawnZBUpgrade();
	public static event numMaxSpawnZBUpgrade getMaxSpawnTimeZB;

	public delegate void upgradeZBIncomeTime();
	public static event upgradeZBIncomeTime onUpgradeZBIncomeTime; 

	public delegate int numMaxIncomeZBUpgrade();
	public static event numMaxSpawnZBUpgrade getMaxIncomeTimeZB;


	//events for building platform menu

	public delegate void buildImprovementBuilding();
	public static event buildImprovementBuilding onBuildImprovementBuilding;

	public delegate void buildTower();
	public static event buildTower onBuildTower;

	//events for improvement buildings 

	public delegate void chooseTypeOfUpgrade(int type);
	public static event chooseTypeOfUpgrade onChooseTypeOfUpgrade;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Resource values
		incomeText = (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources ()).ToString ();
		
	}
	
	void OnGUI(){
		
				if (Input.GetKey (KeyCode.Escape)) {
						drawEnemyHomeBasePanel = false;
						drawNeutralBasePanel = false;
						drawImprovementBuildingPanel = false;
						drawHomeBasePanel = false;
						drawZoneBuildingPanel = false;
						drawPlayerBasePanel = false;
						drawTowerPanel = false;
						drawSoldierMenu = false;
						drawHeroMenu = false;
				}
		
		
				//Resource indicator
				GUI.DrawTexture (new Rect (screenWidth - 100 - 40, 20, 30, 30), resourceIcon);
				GUI.Label (new Rect (screenWidth - 100, 20, 150, 20), incomeText);
		
		
				GUI.DrawTexture (new Rect ((screenHeight - 500), (screenWidth - 500), 128, 128), upgradeHeroHealth);
		
				// draw avatar and hero health bar on top
				GUI.DrawTexture (new Rect (10, 10, 100, 140), avatar);
				float healthHero = 0;
				float mhealthHero = 0;
				GameObject [] goHero = GameObject.FindGameObjectsWithTag ("Hero");
				for (int i=0; i<goHero.Length; i++) {
						if (goHero [i].GetComponent<Hero> ().team == 0) {
								healthHero = goHero [i].GetComponent<Hero> ().health;
								mhealthHero=goHero[i].GetComponent<Hero>().maxHealthHero;
						} else 
								healthHero = 0;
				}
				float healthWidthMaxHero = 70f;
				//change with variable maxHealth
				healthBarWidth = (healthHero / mhealthHero) * healthWidthMaxHero;
		
				GUI.DrawTexture (new Rect (120, 25, healthBarWidth, 15), healthBar);
				// Hero Menu 
		
				/*	GUI.skin = heroSkin;
		GUI.Box (new Rect(280,screenHeight-150,450,150),"Hero Menu");
		GUI.Label (new Rect(332, screenHeight-120,150,20), "Health");
		GUI.DrawTexture(new Rect (400, screenHeight - 120,120, 30), healthBar);
		GUI.Label (new Rect(332, screenHeight-80,150,20), "Healing power");
		GUI.DrawTexture(new Rect (420, screenHeight - 80, 120, 30), healingBar);
		
		
		// hero menu for upgrades 
		
		GUI.Label (new Rect(600,screenHeight-120,150,20),"Upgrades");
		GUI.DrawTexture (new Rect (610, screenHeight - 90, 40, 40), upgradeHeroHealth);
		GUI.DrawTexture (new Rect(660, screenHeight-90,40,40),upgradeHeroTarget );
	*/
				/*
		// Buildings Menu  
		
		GUI.skin = buildingsSkin;
		GUI.Box (new Rect(770,screenHeight-150,450,150), "Buildings Menu");
		GUI.Label (new Rect(780,screenHeight-120,150,20), "Mana ");
		GUI.DrawTexture (new Rect(820,screenHeight-120,15,15),mana);
		
		GUI.DrawTexture (new Rect(780,screenHeight-100,70,70), improvementBuilding);
		GUI.DrawTexture (new Rect(855,screenHeight-100,70,70), tower);
		GUI.Button (new Rect (780, screenHeight - 20, 67, 20), "Build (50)");
		GUI.Button (new Rect (855, screenHeight - 20, 67, 20), "Build (35)");
	*/	
		
				// Units menu 
		
		
				// Context pop up menu for buildings & units
		
		
				//home base pop up
				if (drawHomeBasePanel) {
			
						//set skin

						GUI.skin = homeBasePanelSkin;
						//GUI.skin=heroSkin;
						// Draw Building Panel
						GUI.Box (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight), "HomeBaseMenu");
						float healthHB = 0;	
						float mHealthHB=0;
						float defenceHB = 0;
						float reinforcementHB = 0;
						GameObject goHB = GameObject.FindGameObjectWithTag ("HomeBasePlayer");

						if (goHB.GetComponent<HomeBase> ().team == 0) {
								healthHB = goHB.GetComponent<HomeBase> ().health;
								defenceHB = goHB.GetComponent<HomeBase> ().defence;
								reinforcementHB = goHB.GetComponent<HomeBase> ().reinforcement;
								mHealthHB=goHB.GetComponent<HomeBase> ().maxHealth;
						} else {
								healthHB = 0;
								defenceHB = 0;
								reinforcementHB = 0;
						}
						float healthWidthMaxHB = 90f;
						//change with variable maxHealth
						healthBarWidth = (healthHB / mHealthHB) * healthWidthMaxHB;
						float defenceBaseWidth = (defenceHB / goHB.GetComponent<HomeBase> ().maxDefence) * healthWidthMaxHB;
						float reinforcementBaseWidth = (reinforcementHB / goHB.GetComponent<HomeBase> ().maxReinforcement) * healthWidthMaxHB;

						GUI.DrawTexture (new Rect (contextMenuX + 100, contextMenuY + 43, healthBarWidth, 16), healthBar);
		
						GUI.DrawTexture (new Rect (contextMenuX + 100, contextMenuY + 81, defenceBaseWidth, 16), defenceBar);
						GUI.DrawTexture (new Rect (contextMenuX + 100, contextMenuY + 108, reinforcementBaseWidth, 16), reinforcementBar);

						GUI.TextArea(new Rect(contextMenuX+235, contextMenuY+88,60,30),"5000");
						GUI.DrawTexture(new Rect(contextMenuX+268,contextMenuY+92,22,22),resourceIcon);

						GUI.TextArea(new Rect(contextMenuX+300, contextMenuY+88,60,30),"6000");
						GUI.DrawTexture(new Rect(contextMenuX+333,contextMenuY+92,22,22),resourceIcon);
						


						GUI.DrawTexture (new Rect (contextMenuX + 15, contextMenuY + 27, 50, 50), homeBaseIcon);

						GUILayout.BeginArea (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight));
						GUILayout.Space (27f);
						GUILayout.BeginHorizontal ();
						GUILayout.Space (70f);

						GUILayout.BeginVertical ();
						GUILayout.Space (15f);
						GUILayout.Label ("HP");
						GUILayout.EndVertical ();
		


						if (maxDefence == true) {
								GUI.skin.button.normal.background = homeBaseDefenceUpgradeDark as Texture2D;
								GUI.skin.button.hover.background = homeBaseDefenceUpgradeDark as Texture2D;
								GUI.skin.button.active.background = homeBaseDefenceUpgradeDark as Texture2D;
						} else {
								GUI.skin.button.normal.background = homeBaseDefenceUpgrade as Texture2D;
								GUI.skin.button.hover.background = homeBaseDefenceUpgrade as Texture2D;
								GUI.skin.button.active.background = homeBaseDefenceUpgrade as Texture2D;
						}
						if (GUILayout.Button ("")) {
								if (OnUpgradeDefenceHomeBase != null) {
										if (isDefenceUpgradedHomeBase != null) {
												if (!isDefenceUpgradedHomeBase ()) {
														OnUpgradeDefenceHomeBase ();
												} else {
														maxDefence = true;

												}

										}
								}
						}
						GUILayout.Space (12.5f);

						if (maxReinforcement == false) {
								GUI.skin.button.normal.background = homeBaseReinforcementUpgrade as Texture2D;
								GUI.skin.button.hover.background = homeBaseReinforcementUpgrade as Texture2D;
								GUI.skin.button.active.background = homeBaseReinforcementUpgrade as Texture2D;
						} else {
								GUI.skin.button.normal.background = homeBaseReinforcementUpgradeDark as Texture2D;
								GUI.skin.button.hover.background = homeBaseReinforcementUpgradeDark as Texture2D;
								GUI.skin.button.active.background = homeBaseReinforcementUpgradeDark as Texture2D;
						}
						if (GUILayout.Button ("")) {
								if (OnUpgradeReinforcementHomeBase != null) {
										if (isReinforcedHomeBase != null) {
												if (!isReinforcedHomeBase ()) {
														OnUpgradeReinforcementHomeBase ();
												} else {
														maxReinforcement = true;

												}

										}

								}


						}
						GUILayout.Space(10f);
						GUILayout.EndHorizontal ();

						GUILayout.BeginHorizontal ();
						GUILayout.Space (10f);
						GUILayout.Label ("Defence");
						GUILayout.EndHorizontal ();

						GUILayout.BeginHorizontal ();
						GUILayout.Space (10f);
						GUILayout.Label ("Reinforcement");
						GUILayout.EndHorizontal ();


						GUILayout.EndArea ();


			
				}
		
				//enemy home base pop up
		
				if (drawEnemyHomeBasePanel) {
						// Draw Building Panel
						GUI.skin = enemyHomeBasePanelSkin;
						GUI.skin = heroSkin;
			
						GUI.Box (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight), "EnemyHomeBase Menu");
						GUILayout.BeginArea (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight));
						GUILayout.Space (20f);
						//GUILayout.Button("new",new GUILayoutOption[]
						GUILayout.Button ("Click me");
						GUILayout.Button ("Or me");
						GUILayout.EndArea ();
			
				}
		
				//tower pop up
				if (drawTowerPanel) {
						//set skin
						GUI.skin = towerBuildingSkin;
						//GUI.skin=heroSkin;
						// Draw Building Panel
						GUI.Box (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight), "Tower Menu");

						float healthTower = 0;
						float defenceTower = 0;


						Tower t = selectedTower.GetComponent<Tower> ();
						if (t.team == 0) {
								healthTower = t.health;
								defenceTower = t.defence;
						} else {
								healthTower = 0;
								defenceTower = 0;
						}
						float healthWidthMaxTower = 90f;
						//change with variable maxHealth
						healthBarWidth = (healthTower / t.maxHealth) * healthWidthMaxTower;
						float defenceBaseWidth = (defenceTower / t.maxDefence) * healthWidthMaxTower;

			
						GUI.DrawTexture (new Rect (contextMenuX + 100, contextMenuY + 43, healthBarWidth, 16), healthBar);
						GUI.DrawTexture (new Rect (contextMenuX + 100, contextMenuY + 81, defenceBaseWidth, 16), defenceBar);

			
						GUI.DrawTexture (new Rect (contextMenuX + 15, contextMenuY + 27, 50, 50), homeBaseIcon);
						
						GUI.TextArea(new Rect(contextMenuX+235, contextMenuY+88,60,30),"4000");
						GUI.DrawTexture(new Rect(contextMenuX+268,contextMenuY+92,22,22),resourceIcon);
			
						GUI.TextArea(new Rect(contextMenuX+300, contextMenuY+88,60,30),"8000");
						GUI.DrawTexture(new Rect(contextMenuX+333,contextMenuY+92,22,22),resourceIcon);


						GUILayout.BeginArea (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight));
						GUILayout.Space (27f);
						GUILayout.BeginHorizontal ();
						GUILayout.Space (70f);
			
						GUILayout.BeginVertical ();
						GUILayout.Space (15f);
						GUILayout.Label ("HP");
						GUILayout.EndVertical ();
			
			
			
						if (maxTowerDefence == true) {
								GUI.skin.button.normal.background = towerUpgradeDefenceDark as Texture2D;
								GUI.skin.button.hover.background = towerUpgradeDefenceDark as Texture2D;
								GUI.skin.button.active.background = towerUpgradeDefenceDark as Texture2D;
						} else {
								GUI.skin.button.normal.background = towerUpgradeDefence as Texture2D;
								GUI.skin.button.hover.background = towerUpgradeDefence as Texture2D;
								GUI.skin.button.active.background = towerUpgradeDefence as Texture2D;
						}
						if (GUILayout.Button ("")) {
								if (OnUpgradeDefenceTower != null) {
										if (isDefenceUpgradedMaxTower != null) {
												if (!isDefenceUpgradedMaxTower ()) {
														OnUpgradeDefenceTower ();
												} else {
														maxTowerDefence = true;
							
												}
						
										}
								}
						}
						GUILayout.Space (12.5f);
						if (getTowerFireballsActivated != null) {
								if (!getTowerFireballsActivated ()) {
										GUI.skin.button.normal.background = towerUpgradeFireballs as Texture2D;
										GUI.skin.button.hover.background = towerUpgradeFireballs as Texture2D;
										GUI.skin.button.active.background = towerUpgradeFireballs as Texture2D;
										fireball = false;
								} else {
										GUI.skin.button.normal.background = towerUpgradeFireballsDark as Texture2D;
										GUI.skin.button.hover.background = towerUpgradeFireballsDark as Texture2D;
										GUI.skin.button.active.background = towerUpgradeFireballsDark as Texture2D;
										fireball = true;
								}
						}
						if (GUILayout.Button ("")) {
								if (fireballsClickedTower != null) {
										if (fireballsClickedTower != null) {

												fireballsClickedTower ();
						
										}
					
								}
				
				
						}
						GUILayout.Space (10f);
						GUILayout.EndHorizontal ();
			
						GUILayout.BeginHorizontal ();
						GUILayout.Space (10f);
						GUILayout.Label ("Defence");
						GUILayout.EndHorizontal ();

						GUILayout.EndArea ();
			
				}
		
				if (drawImprovementBuildingPanel) {
						//set skin
						GUI.skin = imporovementBuildingSkin;	
						
						GUI.DrawTexture (new Rect (contextMenuX + 15, contextMenuY + 27, 50, 50), improvementBuildingIcon);
			
						GUI.Box (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight), "Improvement Building Menu");
			
						GUILayout.BeginArea (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight));
						
						GUILayout.Space(20f);

						GUILayout.Label("Choose one of the following upgrades to autoincrement, you choose only once!");
						
						int choice=0;
						if(selectedImprovementBuilding!=null){
						
				if(selectedImprovementBuilding.GetComponent<ImprovementBuilding>()!=null){
					choice=selectedImprovementBuilding.GetComponent<ImprovementBuilding>().choice;
				}
						
						}	

					GUILayout.BeginHorizontal();
					
			if(choice==0 && selectedUpgrade==false){
				GUI.skin.button.normal.background = ibAttackSpeedUpgrade  as Texture2D;
				GUI.skin.button.hover.background = ibAttackSpeedUpgrade as Texture2D;
				GUI.skin.button.active.background = ibAttackSpeedUpgrade as Texture2D;

				if(GUILayout.Button("")){
					selectedUpgrade=true;
					onChooseTypeOfUpgrade(1);
				}

				GUI.skin.button.normal.background = ibMovementSpeedUpgrade  as Texture2D;
				GUI.skin.button.hover.background = ibMovementSpeedUpgrade as Texture2D;
				GUI.skin.button.active.background = ibMovementSpeedUpgrade as Texture2D;

				if(GUILayout.Button("")){
					selectedUpgrade=true;
					onChooseTypeOfUpgrade(2);
				}

				GUI.skin.button.normal.background = ibRangeUpgrade  as Texture2D;
				GUI.skin.button.hover.background = ibRangeUpgrade as Texture2D;
				GUI.skin.button.active.background = ibRangeUpgrade as Texture2D;

				if(GUILayout.Button("")){
					selectedUpgrade=true;
					onChooseTypeOfUpgrade(3);
				}
				
				GUI.skin.button.normal.background = ibHealthUpgrade  as Texture2D;
				GUI.skin.button.hover.background = ibHealthUpgrade as Texture2D;
				GUI.skin.button.active.background = ibHealthUpgrade as Texture2D;

				if(GUILayout.Button("")){
					selectedUpgrade=true;
					onChooseTypeOfUpgrade(4);
				}
			}
			else {
				if(choice==1){
					GUI.skin.button.normal.background = ibAttackSpeedUpgradeDark  as Texture2D;
					GUI.skin.button.hover.background = ibAttackSpeedUpgradeDark as Texture2D;
					GUI.skin.button.active.background = ibAttackSpeedUpgradeDark as Texture2D;
					GUILayout.Button("");
					GUI.skin.button.normal.background = ibMovementSpeedUpgrade  as Texture2D;
					GUI.skin.button.hover.background = ibMovementSpeedUpgrade as Texture2D;
					GUI.skin.button.active.background = ibMovementSpeedUpgrade as Texture2D;
					GUILayout.Button("");
					GUI.skin.button.normal.background = ibRangeUpgrade  as Texture2D;
					GUI.skin.button.hover.background = ibRangeUpgrade as Texture2D;
					GUI.skin.button.active.background = ibRangeUpgrade as Texture2D;
					GUILayout.Button("");
					GUI.skin.button.normal.background = ibHealthUpgrade  as Texture2D;
					GUI.skin.button.hover.background = ibHealthUpgrade as Texture2D;
					GUI.skin.button.active.background = ibHealthUpgrade as Texture2D;
					GUILayout.Button("");
				}
				else if(choice==2){
					GUI.skin.button.normal.background = ibAttackSpeedUpgrade  as Texture2D;
					GUI.skin.button.hover.background = ibAttackSpeedUpgrade as Texture2D;
					GUI.skin.button.active.background = ibAttackSpeedUpgrade as Texture2D;
					GUILayout.Button("");
					GUI.skin.button.normal.background = ibMovementSpeedUpgradeDark  as Texture2D;
					GUI.skin.button.hover.background = ibMovementSpeedUpgradeDark as Texture2D;
					GUI.skin.button.active.background = ibMovementSpeedUpgradeDark as Texture2D;
					GUILayout.Button("");
					GUI.skin.button.normal.background = ibRangeUpgrade  as Texture2D;
					GUI.skin.button.hover.background = ibRangeUpgrade as Texture2D;
					GUI.skin.button.active.background = ibRangeUpgrade as Texture2D;
					GUILayout.Button("");
					GUI.skin.button.normal.background = ibHealthUpgrade  as Texture2D;
					GUI.skin.button.hover.background = ibHealthUpgrade as Texture2D;
					GUI.skin.button.active.background = ibHealthUpgrade as Texture2D;
					GUILayout.Button("");

				}
				else if(choice==3){
					GUI.skin.button.normal.background = ibAttackSpeedUpgrade  as Texture2D;
					GUI.skin.button.hover.background = ibAttackSpeedUpgrade as Texture2D;
					GUI.skin.button.active.background = ibAttackSpeedUpgrade as Texture2D;
					GUILayout.Button("");
					GUI.skin.button.normal.background = ibMovementSpeedUpgrade as Texture2D;
					GUI.skin.button.hover.background = ibMovementSpeedUpgrade as Texture2D;
					GUI.skin.button.active.background = ibMovementSpeedUpgrade as Texture2D;
					GUILayout.Button("");
					GUI.skin.button.normal.background = ibRangeUpgradeDark  as Texture2D;
					GUI.skin.button.hover.background = ibRangeUpgradeDark as Texture2D;
					GUI.skin.button.active.background = ibRangeUpgradeDark as Texture2D;
					GUILayout.Button("");
					GUI.skin.button.normal.background = ibHealthUpgrade  as Texture2D;
					GUI.skin.button.hover.background = ibHealthUpgrade as Texture2D;
					GUI.skin.button.active.background = ibHealthUpgrade as Texture2D;
					GUILayout.Button("");
					
				}
				else if(choice==4){
					GUI.skin.button.normal.background = ibAttackSpeedUpgrade  as Texture2D;
					GUI.skin.button.hover.background = ibAttackSpeedUpgrade as Texture2D;
					GUI.skin.button.active.background = ibAttackSpeedUpgrade as Texture2D;
					GUILayout.Button("");
					GUI.skin.button.normal.background = ibMovementSpeedUpgrade as Texture2D;
					GUI.skin.button.hover.background = ibMovementSpeedUpgrade as Texture2D;
					GUI.skin.button.active.background = ibMovementSpeedUpgrade as Texture2D;
					GUILayout.Button("");
					GUI.skin.button.normal.background = ibRangeUpgrade as Texture2D;
					GUI.skin.button.hover.background = ibRangeUpgrade as Texture2D;
					GUI.skin.button.active.background = ibRangeUpgrade as Texture2D;
					GUILayout.Button("");
					GUI.skin.button.normal.background = ibHealthUpgradeDark as Texture2D;
					GUI.skin.button.hover.background = ibHealthUpgradeDark as Texture2D;
					GUI.skin.button.active.background = ibHealthUpgradeDark as Texture2D;
					GUILayout.Button("");
					
				}



			}

					GUILayout.EndHorizontal();

						GUILayout.EndArea();
						
			
				}
		
				if (drawNeutralBasePanel) {
						GUI.skin = neutralBasePanelSkin;
						GUI.skin = heroSkin;
			
						GUI.Box (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight), "Neutral Base Menu");
						GUILayout.BeginArea (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight));
						GUILayout.Space (20f);
						GUILayout.Button ("Click me");
						GUILayout.Button ("Or me");
						GUILayout.EndArea ();
			
			
			
				}
		
				if (drawPlayerBasePanel) {
						GUI.skin = playerBaseSkin;
						GUI.skin = heroSkin;
			
						GUI.Box (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight), "Base Menu");
						GUILayout.BeginArea (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight));
						GUILayout.Space (20f);
						GUILayout.Button ("Click me");
						GUILayout.Button ("Or me");
						GUILayout.EndArea ();
			
			
			
				}
		
				// Unit pop up menu
		
				//soldier menu
				if (drawSoldierMenu) {
						GUI.skin = soldierMenuSkin;
						//GUI.skin=heroSkin;

						float healthSoldier = 0;
						Soldier s = selectedSoldier.GetComponent<Soldier> ();
						if (s.team == 0) {
								healthSoldier = s.health;
						} else {
								healthSoldier = 0;
						}
						float healthWidthMaxSoldier = 90f;
						//change with variable maxHealth
						healthBarWidth = (healthSoldier / s.maxHealth) * healthWidthMaxSoldier;
			
						GUI.DrawTexture (new Rect (contextMenuX + 100, contextMenuY + 43, healthBarWidth, 16), healthBar);
						
						GUI.TextArea(new Rect(contextMenuX+20, contextMenuY+88,110,30),"3800       for each");
						GUI.DrawTexture(new Rect(contextMenuX+53,contextMenuY+92,20,20),resourceIcon);

						GUI.DrawTexture (new Rect (contextMenuX + 15, contextMenuY + 27, 50, 50), soldierIcon);


						GUI.Box (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight), "Soldier Menu");

						GUILayout.BeginArea (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight));
						GUILayout.Space (27f);
						GUILayout.BeginHorizontal ();
						GUILayout.Space (70f);
			
						GUILayout.BeginVertical ();
						GUILayout.Space (15f);
						GUILayout.Label ("HP");
						GUILayout.EndVertical ();

						bool canUpgradeSpeed = true;

						if (getSoldierNumSpeedU != null) {
								if (getSoldierNumSpeedU () < numMaxSpeedUpgrades) {

										GUI.skin.button.normal.background = soldierSpeedMovementUpgrade  as Texture2D;
										GUI.skin.button.hover.background = soldierSpeedMovementUpgrade as Texture2D;
										GUI.skin.button.active.background = soldierSpeedMovementUpgrade as Texture2D;
								} else {
										GUI.skin.button.normal.background = soldierSpeedMovementUpgradeDark  as Texture2D;
										GUI.skin.button.hover.background = soldierSpeedMovementUpgradeDark as Texture2D;
										GUI.skin.button.active.background = soldierSpeedMovementUpgradeDark as Texture2D;
										canUpgradeSpeed = false;
								}


						}
						if (GUILayout.Button ("")) {
								if (canUpgradeSpeed) {
										if (onUpgradeSoldierSpeed != null) {
												onUpgradeSoldierSpeed ();
										}
								}
						}
			
		
						GUILayout.Space (12.5f);

						bool canUpgradeAttack = true;
			
						if (getSoldierNumAttackU != null) {
								if (getSoldierNumAttackU () < numMaxAttackUpgrades) {
					
										GUI.skin.button.normal.background = soldierAttackSpeedUpgrade as Texture2D;
										GUI.skin.button.hover.background = soldierAttackSpeedUpgrade as Texture2D;
										GUI.skin.button.active.background = soldierAttackSpeedUpgrade as Texture2D;

								} else {
										GUI.skin.button.normal.background = soldierAttackSpeedUpgradeDark  as Texture2D;
										GUI.skin.button.hover.background = soldierAttackSpeedUpgradeDark as Texture2D;
										GUI.skin.button.active.background = soldierAttackSpeedUpgradeDark as Texture2D;
										canUpgradeSpeed = false;
								}
				
				
						}
						if (GUILayout.Button ("")) {
								if (canUpgradeAttack) {
										if (onUpgradeSoldierAttack != null) {
												onUpgradeSoldierAttack ();
										}
								}
						}


						GUILayout.EndHorizontal ();

						GUILayout.Space (20f);

						GUILayout.BeginHorizontal ();
						GUILayout.Space (245f);

						bool canUpgradeRange = true;
			
						if (getSoldierNumRangeU != null) {
								if (getSoldierNumRangeU () < numMaxRangeUpgrades) {
					
										GUI.skin.button.normal.background = soldierRangeUpgrade as Texture2D;
										GUI.skin.button.hover.background = soldierRangeUpgrade as Texture2D;
										GUI.skin.button.active.background = soldierRangeUpgrade as Texture2D;

								} else {
										GUI.skin.button.normal.background = soldierRangeUpgradeDark  as Texture2D;
										GUI.skin.button.hover.background = soldierRangeUpgradeDark as Texture2D;
										GUI.skin.button.active.background = soldierRangeUpgradeDark as Texture2D;
										canUpgradeSpeed = false;
								}
				
				
						}
						if (GUILayout.Button ("")) {
								if (canUpgradeRange) {
										if (onUpgradeSoldierRange != null) {
												onUpgradeSoldierRange ();
										}
								}
						}

						GUILayout.Space (12.5f);

						bool canUpgradeHealth = true;
			
						if (getSoldierNumHealthU != null) {
								if (getSoldierNumHealthU () < numMaxHealthUpgrades) {
					
										GUI.skin.button.normal.background = soldierHealthUpgrade as Texture2D;
										GUI.skin.button.hover.background = soldierHealthUpgrade as Texture2D;
										GUI.skin.button.active.background = soldierHealthUpgrade as Texture2D;

								} else {
										GUI.skin.button.normal.background = soldierHealthUpgradeDark  as Texture2D;
										GUI.skin.button.hover.background = soldierHealthUpgradeDark as Texture2D;
										GUI.skin.button.active.background = soldierHealthUpgradeDark as Texture2D;
										canUpgradeSpeed = false;
								}
				
				
						}
						if (GUILayout.Button ("")) {
								if (canUpgradeHealth) {
										if (onUpgradeSoldierHealth != null) {
												onUpgradeSoldierHealth ();
										}
								}
						}


						GUILayout.EndHorizontal ();
			
					
						GUILayout.EndArea ();		
			
				}
		
				if (drawHeroMenu) {
			
						GUI.skin = heroMenuSkin;
						//GUI.skin=heroSkin;

						float healthHero1 = 0;
						float maxHP = 0;
						GameObject [] goHero1 = GameObject.FindGameObjectsWithTag ("Hero");
						for (int i=0; i<goHero1.Length; i++) {
								if (goHero1 [i].GetComponent<Hero> ().team == 0) {
										healthHero = goHero1 [i].GetComponent<Hero> ().health;
										maxHP = goHero1 [i].GetComponent<Hero> ().maxHealthHero;
								} else 
										healthHero = 0;
						}
						float healthWidthMaxHero1 = 70f;
						//change with variable maxHealth
						healthBarWidth = (healthHero / maxHP) * healthWidthMaxHero1;
			
						GUI.DrawTexture (new Rect (contextMenuX + 100, contextMenuY + 43, healthBarWidth, 16), healthBar);
						GUI.DrawTexture (new Rect (contextMenuX + 15, contextMenuY + 27, 50, 50), heroIcon);
						

						GUI.TextArea(new Rect(contextMenuX+20, contextMenuY+88,110,30),"5200       for each");
						GUI.DrawTexture(new Rect(contextMenuX+53,contextMenuY+92,20,20),resourceIcon);
			
						GUI.Box (new Rect (contextMenuX, contextMenuY, contextMenuWidth + 150, contextMenuHeight), "Hero Menu");
			
						GUILayout.BeginArea (new Rect (contextMenuX, contextMenuY, contextMenuWidth + 150, contextMenuHeight));
						GUILayout.Space (27f);
						GUILayout.BeginHorizontal ();
						GUILayout.Space (70f);
			
						GUILayout.BeginVertical ();
						GUILayout.Space (15f);
						GUILayout.Label ("HP");
						GUILayout.EndVertical ();

						GUILayout.Space (80f);
						bool canUpgradeSpeed = true;
			
						if (getHeroNumSpeedU != null) {
								if (getHeroNumSpeedU () < maxSpeedUpgrades) {
					
										GUI.skin.button.normal.background = heroSpeedMovementUpgrade  as Texture2D;
										GUI.skin.button.hover.background = heroSpeedMovementUpgrade as Texture2D;
										GUI.skin.button.active.background = heroSpeedMovementUpgrade as Texture2D;
								} else {
										GUI.skin.button.normal.background = heroSpeedMovementUpgradeDark  as Texture2D;
										GUI.skin.button.hover.background = heroSpeedMovementUpgradeDark as Texture2D;
										GUI.skin.button.active.background = heroSpeedMovementUpgradeDark as Texture2D;
										canUpgradeSpeed = false;
								}
				
				
						}
						if (GUILayout.Button ("")) {
								if (canUpgradeSpeed) {
										if (onUpgradeHeroSpeed != null) {
												onUpgradeHeroSpeed ();
										}
								}
						}
			
			
						GUILayout.Space (10f);
			
						bool canUpgradeAttack = true;
			
						if (getHeroNumAttackU != null) {
								if (getHeroNumAttackU () < maxAttackUpgrades) {
					
										GUI.skin.button.normal.background = heroAttackSpeedUpgrade as Texture2D;
										GUI.skin.button.hover.background = heroAttackSpeedUpgrade as Texture2D;
										GUI.skin.button.active.background = heroAttackSpeedUpgrade as Texture2D;
					
								} else {
										GUI.skin.button.normal.background = heroAttackSpeedUpgradeDark  as Texture2D;
										GUI.skin.button.hover.background = heroAttackSpeedUpgradeDark as Texture2D;
										GUI.skin.button.active.background = heroAttackSpeedUpgradeDark as Texture2D;
										canUpgradeSpeed = false;
								}
				
				
						}
						if (GUILayout.Button ("")) {
								if (canUpgradeAttack) {
										if (onUpgradeHeroAttack != null) {
												onUpgradeHeroAttack ();
										}
								}
						}
			
			
						//	GUILayout.EndHorizontal();
			
						GUILayout.Space (10f);
			
						//	GUILayout.BeginHorizontal();
						//	GUILayout.Space (245f);
			
						bool canUpgradeRange = true;
			
						if (getHeroNumRangeU != null) {
								if (getHeroNumRangeU () < maxRangeUpgrades) {
					
										GUI.skin.button.normal.background = heroRangeUpgrade as Texture2D;
										GUI.skin.button.hover.background = heroRangeUpgrade as Texture2D;
										GUI.skin.button.active.background = heroRangeUpgrade as Texture2D;
					
								} else {
										GUI.skin.button.normal.background = heroRangeUpgradeDark  as Texture2D;
										GUI.skin.button.hover.background = heroRangeUpgradeDark as Texture2D;
										GUI.skin.button.active.background = heroRangeUpgradeDark as Texture2D;
										canUpgradeSpeed = false;
								}
				
				
						}
						if (GUILayout.Button ("")) {
								if (canUpgradeRange) {
										if (onUpgradeHeroRange != null) {
												onUpgradeHeroRange ();
										}
								}
						}
			
						GUILayout.Space (10f);
			
						bool canUpgradeHealth = true;
			
						if (getHeroNumHealthU != null) {
								if (getHeroNumHealthU () < maxHealthUpgrades) {
					
										GUI.skin.button.normal.background = heroHealthUpgrade as Texture2D;
										GUI.skin.button.hover.background = heroHealthUpgrade as Texture2D;
										GUI.skin.button.active.background = heroHealthUpgrade as Texture2D;
					
								} else {
										GUI.skin.button.normal.background = heroHealthUpgradeDark  as Texture2D;
										GUI.skin.button.hover.background = heroHealthUpgradeDark as Texture2D;
										GUI.skin.button.active.background = heroHealthUpgradeDark as Texture2D;
										canUpgradeSpeed = false;
								}
				
				
						}
						if (GUILayout.Button ("")) {
								if (canUpgradeHealth) {
										if (onUpgradeHeroHealth != null) {
												onUpgradeHeroHealth ();
										}
								}
						}
			
						GUILayout.Space (10f);
						GUILayout.EndHorizontal ();
						GUILayout.Space (10f);

						GUILayout.BeginHorizontal ();
						GUILayout.Space (263f);

						bool canUpgradeCommand = true;
			
						if (getHeroNumCommandU != null) {
								if (getHeroNumCommandU () < maxCommandUpgrades) {
					
										GUI.skin.button.normal.background = heroCommandUpgrade as Texture2D;
										GUI.skin.button.hover.background = heroCommandUpgrade as Texture2D;
										GUI.skin.button.active.background = heroCommandUpgrade as Texture2D;
					
								} else {
										GUI.skin.button.normal.background = heroCommandUpgradeDark  as Texture2D;
										GUI.skin.button.hover.background = heroCommandUpgradeDark as Texture2D;
										GUI.skin.button.active.background = heroCommandUpgradeDark as Texture2D;
										canUpgradeCommand = false;
								}
				
				
						}
						if (GUILayout.Button ("")) {
								if (canUpgradeCommand) {
										if (onUpgradeHeroCommand != null) {
												onUpgradeHeroCommand ();
										}
								}
						}

						GUILayout.Space (12.5f);

						bool canUpgradeShield = true;
			
						if (getHeroNumShieldU != null) {
								if (getHeroNumShieldU () < maxShieldUpgrades) {
					
										GUI.skin.button.normal.background = heroShieldUpgrade as Texture2D;
										GUI.skin.button.hover.background = heroShieldUpgrade as Texture2D;
										GUI.skin.button.active.background = heroShieldUpgrade as Texture2D;
					
								} else {
										GUI.skin.button.normal.background = heroShieldUpgradeDark  as Texture2D;
										GUI.skin.button.hover.background = heroShieldUpgradeDark as Texture2D;
										GUI.skin.button.active.background = heroShieldUpgradeDark as Texture2D;
										canUpgradeShield = false;
								}
				
				
						}
						if (GUILayout.Button ("")) {
								if (canUpgradeShield) {
										if (onUpgradeHeroShield != null) {
												onUpgradeHeroShield ();
										}
								}
						}

						GUILayout.Space (12.5f);
			
						bool canUpgradeWeapon1 = true;
			
						if (getHeroNumWeapon1U != null) {
								if (getHeroNumWeapon1U () < maxWeapon1Upgrades) {
					
										GUI.skin.button.normal.background = heroWeapon1Upgrade as Texture2D;
										GUI.skin.button.hover.background = heroWeapon1Upgrade as Texture2D;
										GUI.skin.button.active.background = heroWeapon1Upgrade as Texture2D;
					
								} else {
										GUI.skin.button.normal.background = heroWeapon1UpgradeDark  as Texture2D;
										GUI.skin.button.hover.background = heroWeapon1UpgradeDark as Texture2D;
										GUI.skin.button.active.background = heroWeapon1UpgradeDark as Texture2D;
										canUpgradeWeapon1 = false;
								}
				
				
						}
						if (GUILayout.Button ("")) {
								if (canUpgradeWeapon1) {
										if (onUpgradeHeroWeapon1 != null) {
												onUpgradeHeroWeapon1 ();
										}
								}
						}
						GUILayout.Space (12.5f);
			
						bool canUpgradeWeapon2 = true;
			
						if (getHeroNumWeapon2U != null) {
								if (getHeroNumWeapon2U () < maxWeapon2Upgrades) {
					
										GUI.skin.button.normal.background = heroWeapon2Upgrade as Texture2D;
										GUI.skin.button.hover.background = heroWeapon2Upgrade as Texture2D;
										GUI.skin.button.active.background = heroWeapon2Upgrade as Texture2D;
					
								} else {
										GUI.skin.button.normal.background = heroWeapon2UpgradeDark  as Texture2D;
										GUI.skin.button.hover.background = heroWeapon2UpgradeDark as Texture2D;
										GUI.skin.button.active.background = heroWeapon2UpgradeDark as Texture2D;
										canUpgradeWeapon2 = false;
								}
				
				
						}
						if (GUILayout.Button ("")) {
								if (canUpgradeWeapon2) {
										if (onUpgradeHeroWeapon2 != null) {
												onUpgradeHeroWeapon2 ();
										}
								}
						}

						GUILayout.EndHorizontal ();
						GUILayout.EndArea ();		

				}

				if (drawZoneBuildingPanel) {
			GUI.skin = zoneBuildingSkin;
			//GUI.skin=heroSkin;
			// Draw Building Panel
			GUI.Box (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight), "ZoneBuilding Menu");
			
			float healthZB = 0;
			//float defenceTower = 0;
			
			
			ZoneBuilding z = selectedZoneBuilding.GetComponent<ZoneBuilding> ();
			if (z.team == 0) {
				healthZB = z.health;
				//defenceTower = t.defence;
			} else {
				healthZB = 0;
				//defenceTower = 0;
			}
			float healthWidthMaxZB = 90f;
			//change with variable maxHealth
			healthBarWidth = (healthZB / z.maxHealth) * healthWidthMaxZB;
			//float defenceBaseWidth = (defenceTower / t.maxDefence) * healthWidthMaxTower;
			
			
			GUI.DrawTexture (new Rect (contextMenuX + 100, contextMenuY + 43, healthBarWidth, 16), healthBar);
		//	GUI.DrawTexture (new Rect (contextMenuX + 100, contextMenuY + 81, defenceBaseWidth, 16), defenceBar);
			
			
			GUI.DrawTexture (new Rect (contextMenuX + 15, contextMenuY + 27, 50, 50), zoneBuildingIcon);

			GUI.TextArea(new Rect(contextMenuX+235, contextMenuY+88,60,30),"8000");
			GUI.DrawTexture(new Rect(contextMenuX+268,contextMenuY+92,22,22),resourceIcon);
			
			GUI.TextArea(new Rect(contextMenuX+300, contextMenuY+88,60,30),"4000");
			GUI.DrawTexture(new Rect(contextMenuX+333,contextMenuY+92,22,22),resourceIcon);



			GUILayout.BeginArea (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight));
			GUILayout.Space (27f);
			GUILayout.BeginHorizontal ();
			GUILayout.Space (70f);
			
			GUILayout.BeginVertical ();
			GUILayout.Space (15f);
			GUILayout.Label ("HP");
			GUILayout.EndVertical ();
			bool canSpawnU=true;
			if(getMaxSpawnTimeZB!=null){
			if(getMaxSpawnTimeZB()<z.numSpawnUpgrades){
				GUI.skin.button.normal.background = zoneBuildingSpawnTimeUpgradeDark as Texture2D;
					GUI.skin.button.hover.background = zoneBuildingSpawnTimeUpgradeDark as Texture2D;
					GUI.skin.button.active.background = zoneBuildingSpawnTimeUpgradeDark as Texture2D;
					canSpawnU=false;
			} else {
					GUI.skin.button.normal.background = zoneBuildingSpawnTimeUpgrade as Texture2D;
					GUI.skin.button.hover.background = zoneBuildingSpawnTimeUpgrade as Texture2D;
					GUI.skin.button.active.background = zoneBuildingSpawnTimeUpgrade as Texture2D;
			}
			}

			if (GUILayout.Button ("")) {
				if (onUpgradeZBSpawnTime != null) {
						if (canSpawnU) {
						onUpgradeZBSpawnTime ();
						} 

				}
			}
			GUILayout.Space (12.5f);

			bool canIncomeU=true;
			if(getMaxIncomeTimeZB!=null){
				if(getMaxIncomeTimeZB()<z.numIncomeUpgrades){
					GUI.skin.button.normal.background = zoneBuildinIncomeUpgradeDark as Texture2D;
					GUI.skin.button.hover.background = zoneBuildinIncomeUpgradeDark as Texture2D;
					GUI.skin.button.active.background = zoneBuildinIncomeUpgradeDark as Texture2D;
					canIncomeU=false;
				} else {
					GUI.skin.button.normal.background = zoneBuildinIncomeUpgradeDark as Texture2D;
					GUI.skin.button.hover.background = zoneBuildinIncomeUpgradeDark as Texture2D;
					GUI.skin.button.active.background = zoneBuildinIncomeUpgradeDark as Texture2D;
				}
			}
			
			if (GUILayout.Button ("")) {
				if (onUpgradeZBIncomeTime != null) {
					if (canIncomeU) {
						onUpgradeZBIncomeTime ();
					} 
					
				}
			}

			GUILayout.Space (10f);
			GUILayout.EndHorizontal ();
			
			GUILayout.BeginHorizontal ();
			GUILayout.Space (10f);
			//GUILayout.Label ("Defence");
			GUILayout.EndHorizontal ();
			
			GUILayout.EndArea ();

				}

		if (drawBPPanel) {
			GUI.skin = BPMenuSkin;
			//GUI.skin=heroSkin;
			// Draw Building Panel
			GUI.Box (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight), "Buildings Menu");
		

			
			GUI.DrawTexture (new Rect (contextMenuX + 15, contextMenuY + 27, 50, 50), BPIcon);

			GUI.TextArea(new Rect(contextMenuX+8, contextMenuY+127,60,30),"9800");
			GUI.DrawTexture(new Rect(contextMenuX+41,contextMenuY+131,22,22),resourceIcon);

			GUI.TextArea(new Rect(contextMenuX+73, contextMenuY+127,60,30),"8000");
			GUI.DrawTexture(new Rect(contextMenuX+106,contextMenuY+131,22,22),resourceIcon);


			
			GUILayout.BeginArea (new Rect (contextMenuX, contextMenuY, contextMenuWidth, contextMenuHeight));
			GUILayout.Space(20f);
			//get available towers and inmrovement buildings from stage
			GameObject stage= GameObject.FindGameObjectWithTag("Stage");
			string s="Improvement buildings you can build: "+ stage.GetComponent<Stage>().numOfImprovementBuildings;
			string t="Towers you can build: "+ stage.GetComponent<Stage>().numOfTowers;
			GUILayout.Label(s);
			GUILayout.Label(t);
			GUILayout.Space(7f);
			GUILayout.BeginHorizontal();
			GUILayout.Space(12f);
			if(stage.GetComponent<Stage>().numOfImprovementBuildings>0){
				GUI.skin.button.normal.background = iconImprovementBuilding as Texture2D;
				GUI.skin.button.hover.background = iconImprovementBuilding as Texture2D;
				GUI.skin.button.active.background = iconImprovementBuilding as Texture2D;

			}
			else {
				GUI.skin.button.normal.background = iconImprovementBuildingDark as Texture2D;
				GUI.skin.button.hover.background = iconImprovementBuildingDark as Texture2D;
				GUI.skin.button.active.background = iconImprovementBuildingDark as Texture2D;

			}
			if (GUILayout.Button ("")) {
				if(onBuildImprovementBuilding!=null){
					onBuildImprovementBuilding();
				}
			}
			GUILayout.Space(12f);
			if(stage.GetComponent<Stage>().numOfTowers>0){
				GUI.skin.button.normal.background = iconTowerBuilding as Texture2D;
				GUI.skin.button.hover.background = iconTowerBuilding as Texture2D;
				GUI.skin.button.active.background = iconTowerBuilding as Texture2D;
				
			}
			else {
				GUI.skin.button.normal.background = iconTowerBuildingDark as Texture2D;
				GUI.skin.button.hover.background = iconTowerBuildingDark as Texture2D;
				GUI.skin.button.active.background = iconTowerBuildingDark as Texture2D;
				
			}
			if (GUILayout.Button ("")) {
				if(onBuildTower!=null){
					onBuildTower();
				}
			}
			GUILayout.EndHorizontal();

			GUILayout.EndArea();
		}
				

		
		
		
		
	//end of OnGUI()
	}
	
	
}
