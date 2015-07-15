using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerManager : MonoBehaviour {

    //Prefabs
    public GameObject cam_3rdperson;
    public GameObject cam_rts;
    public GameObject Humanplayer;
    public GameObject AIplayer;
    public HumanPlayer hplayer { get; set; }
    public AIPlayer aiplayer { get; set; }


	// Use this for initialization
	void Start () {
        //onStart();
	}
	
	// Update is called once per frame
	void Update () {
        onUpdate();
	}

    public void onStart()
    { 
        // Human player
        hplayer = ((GameObject)Instantiate(Humanplayer)).GetComponent<HumanPlayer>();
        hplayer.cam_3rdperson = ((GameObject)Instantiate(cam_3rdperson)).GetComponent<Camera>();
        hplayer.cam_rts = ((GameObject)Instantiate(cam_rts)).GetComponent<Camera>();

        // AI player
        aiplayer = ((GameObject)Instantiate(AIplayer)).GetComponent<AIPlayer>();
        
    }
    public void onUpdate()
    {
        hplayer.units = GetComponent<UnitManager>().GetUnitsInTeam(hplayer.team);
        aiplayer.units = GetComponent<UnitManager>().GetUnitsInTeam(aiplayer.team);
    }

    public void SetHero(Hero h)
    {
        if (h.team == hplayer.team)
        {
            hplayer.hero = h;
            hplayer.cam_3rdperson.GetComponent<ThirdPersonCam>().target = hplayer.hero.transform;
        }
        if (h.team == aiplayer.team)
        {
            aiplayer.hero = h;
        }
    }
}
