using UnityEngine;
using System.Collections;

public class Hero : Soldier {
    public bool rts { get; set; }
    public Vector3 forward { get; set; }
    public Vector3 right { get; set; }
	public float maxHealthHero;

	public int numCommandUpgrades=0;
	public int numShieldUpgrades=0;
	public int numWeapon1Upgrades=0;
	public int numWeapon2Upgrades=0;

    float baseattackspeed;
    float basemovespeed;
    public bool sprinting { get; set; }

    //Special1
    public GameObject special1Bullet;
    public float special1Cooldown;
    float CDtimer1 = 0;

    //Special2
    public float special2Cooldown;
    float CDtimer2 = 0;
    public float special2Duration;
    public float special2AtkSpeed;
    float durationtimer;

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
       // renderer.material.color = Color.yellow;
        rts = true;
        base.OnStart();
        sprinting = false;
        baseattackspeed = attackspeed;
        basemovespeed = mspeed;
    }

    protected void OnUpdate()
    {
		if (health == 0) {
			SwitchMode(true);		
		}

        timer += Time.deltaTime;
        CDtimer1 += Time.deltaTime;

        if (durationtimer > 0)
            durationtimer -= Time.deltaTime;
        else
        {
            attackspeed = baseattackspeed;
            CDtimer2 += Time.deltaTime;
        }

        if (rts)
            RTS();
        else
            nonRTS();
    }

    void RTS()
    {
        base.OnUpdate();

    }
    void nonRTS()
    {
     //   renderer.material.color = Color.yellow;
        Highlighted = false;
        Move();
    }

    new protected bool Move()
    {

        Vector3 movement_dir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            movement_dir += forward;
        if (Input.GetKey(KeyCode.S))
            movement_dir += -forward;
        if (Input.GetKey(KeyCode.A))
            movement_dir += -right;
        if (Input.GetKey(KeyCode.D))
            movement_dir += right;

        //rotate to face target
        transform.rotation = Quaternion.LookRotation(new Vector3(forward.x, forward.y, forward.z));

        //did not move 
        if (movement_dir == Vector3.zero)
            return false;

        //did move
        transform.position = Vector3.MoveTowards(transform.position, transform.position + movement_dir, mspeed * Time.deltaTime);

        float y = Terrain.activeTerrain.SampleHeight(transform.position) + transform.localScale.y / 2;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        return true;
    }

    public bool Attack()
    {
        if (timer < attackspeed)
            return false;
        Vector3 bulletdir = new Vector3(forward.x,forward.y, forward.z).normalized;
        GameObject b = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        Bullet bulletscript = b.GetComponent<Bullet>();
        bulletscript.dir = bulletdir;
        bulletscript.team = team;
        bulletscript.range = range;
        timer = 0;
        return true;
    }

    public bool Special1()
    {

        Debug.Log("CDtimer" + CDtimer1);
        Debug.Log("specialcooldown" + special1Cooldown);
        if (CDtimer1 < special1Cooldown)
            return false;
        Vector3 bulletdir = new Vector3(forward.x, forward.y, forward.z).normalized;
        GameObject b = (GameObject)Instantiate(special1Bullet, transform.position, Quaternion.identity);
        //b.transform.localScale = new Vector3(15, 15, 15);
        Bullet bulletscript = b.GetComponent<Bullet>();
        bulletscript.dir = bulletdir;
        bulletscript.team = team;
        bulletscript.dmg = 50;
        bulletscript.speed = 2;
        bulletscript.piercing = true;
        Debug.Log("SPECIAL");

        CDtimer1 = 0;
        return true;
    }

    public bool Special2()
    {
        if (CDtimer2 < special2Cooldown)
            return false;
        durationtimer = special2Duration;
        attackspeed = special2AtkSpeed;
        CDtimer2 = 0;
        return true;
    }

    public void SwitchMode(bool mode)
    {
        rts = mode;
        mtarget_pos = transform.position;
		if(rts==false){
		GUIManager go=GameObject.Find("Managers").GetComponent<GUIManager>();
		go.drawBPPanel=false;
		go.drawEnemyHomeBasePanel=false;
		go.drawHeroMenu=false;
		go.drawHomeBasePanel=false;
		go.drawImprovementBuildingPanel=false;
		go.drawNeutralBasePanel=false;
		go.drawPlayerBasePanel=false;
		go.drawSoldierMenu=false;
		go.drawTowerPanel=false;
		go.drawZoneBuildingPanel=false;
		}

    }

    public void Sprint(bool s)
    {
        sprinting = s;
        if (s)
        {
            mspeed += basemovespeed;
        }
        else
        {
            mspeed = basemovespeed;
        }
    }
}
