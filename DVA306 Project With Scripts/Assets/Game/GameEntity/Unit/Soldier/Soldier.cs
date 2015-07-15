using UnityEngine;
using System.Collections;

public class Soldier : Unit {
	public GameObject bullet;
	public float attackspeed;
	//actually mim, since this is timer 
	public float attackspeedMax;

	public float maxHealth=100;

	public int numSpeedUpgrades=0;
	public int numAttackUpgrades=0;
	public int numRangeUpgrades = 0;
	public int numHealthUpgrades=0;
	// Use this for initialization
	void Start()
	{
		OnStart();
	}
	
	// Update is called once per frame
	void Update()
	{
		OnUpdate();
	}
	protected void OnStart()
	{
		base.OnStart();
	}
	protected float timer = 0;
	protected void OnUpdate()
	{
		timer += Time.deltaTime;
		base.OnUpdate();
		if (timer > attackspeed && mtarget_gameentity)
		{
			Attack();
			timer = 0;
		}
		
	}
	
	protected void Attack()
	{
		if (mtarget_gameentity)
		{
            Vector3 yoffset = new Vector3(0,2,0);
			Vector3 bulletdir = (mtarget_gameentity.transform.position - transform.position).normalized;
            GameObject b = (GameObject)Instantiate(bullet, transform.position + yoffset, Quaternion.identity);
			Bullet bulletscript = b.GetComponent<Bullet>();
			bulletscript.dir = bulletdir;
			bulletscript.team = team;
		}
	}
}
