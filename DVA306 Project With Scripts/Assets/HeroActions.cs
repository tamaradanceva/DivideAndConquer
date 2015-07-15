using UnityEngine;
using System.Collections;

public class HeroActions : MonoBehaviour {

	private Hero hero;

	public int priceEachHeroUpdate=5200;
	// Use this for initialization
	void Start () {
		GameObject [] goHero1=GameObject.FindGameObjectsWithTag("Hero");
		for (int i=0; i<goHero1.Length; i++) {
			if(goHero1[i].GetComponent<Hero>().team==0){
				hero=goHero1[i].GetComponent<Hero>();
			}		
		}
		GUIManager.onUpgradeHeroSpeed += upgradeHeroSpeed;
		GUIManager.onUpgradeHeroAttack += upgradeHeroAttack;
		GUIManager.onUpgradeHeroRange += upgradeHeroRange;
		GUIManager.onUpgradeHeroHealth += upgradeHeroHealth;
		GUIManager.onUpgradeHeroCommand += upgradeHeroCommand;
		GUIManager.onUpgradeHeroShield += upgradeHeroShield;
		GUIManager.onUpgradeHeroWeapon1 += upgradeHeroWeapon1;
		GUIManager.onUpgradeHeroWeapon2 += upgradeHeroWeapon2;

		GUIManager.getHeroNumSpeedU += getNumSpeedHeroUpgrades;
		GUIManager.getHeroNumAttackU += getNumAttackHeroUpgrades;
		GUIManager.getHeroNumRangeU += getNumRangeHeroUpgrades;
		GUIManager.getHeroNumHealthU += getNumHealthHeroUpgrades;
		GUIManager.getHeroNumCommandU += getNumCommandHeroUpgrades;
		GUIManager.getHeroNumShieldU += getNumShieldHeroUpgrades;
		GUIManager.getHeroNumWeapon1U += getNumWeapon1HeroUpgrades;
		GUIManager.getHeroNumWeapon2U += getNumWeapon2HeroUpgrades;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void upgradeHeroSpeed(){
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceEachHeroUpdate) {
						GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceEachHeroUpdate);
						hero.mspeed += 3;
						hero.numSpeedUpgrades += 1;
				}
	}
	void upgradeHeroAttack(){
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceEachHeroUpdate) {
						GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceEachHeroUpdate);
						hero.attackspeed -= 0.3f;
						hero.numAttackUpgrades += 1;
				}
	}
	
	void upgradeHeroRange(){
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceEachHeroUpdate) {
						GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceEachHeroUpdate);
						hero.range += 3;
						hero.numRangeUpgrades += 1;
				}
	}
	void upgradeHeroHealth(){
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceEachHeroUpdate) {
						GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceEachHeroUpdate);
						hero.health += 5;
						hero.numHealthUpgrades += 1;
				}
	}

	void upgradeHeroCommand(){
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceEachHeroUpdate) {
						GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceEachHeroUpdate);

						//implement

						hero.numCommandUpgrades += 1;
				}
	}

	void upgradeHeroShield(){
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceEachHeroUpdate) {
						GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceEachHeroUpdate);
			
						//implement

						hero.numShieldUpgrades += 1;
				}
	}

	void upgradeHeroWeapon1(){
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceEachHeroUpdate) {
						GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceEachHeroUpdate);
			
						//implement

						hero.numWeapon1Upgrades += 1;
				}
	}

	void upgradeHeroWeapon2(){
		if (GameObject.Find ("Managers").GetComponent<ValuesManager> ().GetResources () >= priceEachHeroUpdate) {
						GameObject.Find ("Managers").GetComponent<ValuesManager> ().SpendResources (priceEachHeroUpdate);
			
						//implement

						hero.numWeapon2Upgrades += 1;
				}
	}

	
	int getNumSpeedHeroUpgrades(){
		return hero.numSpeedUpgrades;
	}
	
	int getNumAttackHeroUpgrades(){
		return hero.numAttackUpgrades;
	}
	
	int getNumRangeHeroUpgrades(){
		return hero.numRangeUpgrades;
	}
	
	int getNumHealthHeroUpgrades(){
		return hero.numHealthUpgrades;
	}

	int getNumCommandHeroUpgrades(){
		return hero.numCommandUpgrades;
	}

	int getNumShieldHeroUpgrades(){
		return hero.numShieldUpgrades;
		
	}

	int getNumWeapon1HeroUpgrades(){
		return hero.numWeapon1Upgrades;
		
	}

	int getNumWeapon2HeroUpgrades(){
		return hero.numWeapon2Upgrades;
		
	}
}
