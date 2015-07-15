using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour {

    //Hero is always in munitlists[x][0]
    public List<List<Unit>> munitlists;
    public int nrteams;
    public GameObject mhero;
    public GameObject msoldier;

	void Awake()
	{
		munitlists = new List<List<Unit>>(nrteams);
		for (int i = 0; i < nrteams; i++)
		{
			munitlists.Add(new List<Unit>());
		}


	}

    // Use this for initialization
    void Start()
    {
        onStart();

    }

    // Update is called once per frame
    void Update()
    {
        onUpdate();
    }

    public void onStart()
    {
      
        // Collect all units placed in game and add them
        GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
        for (int i = 0; i < units.Length; i++)
        {
            Unit u = units[i].GetComponent<Unit>();
            AddUnit(u, u.team);
        }

        // Collect all heroes placed in game and add them
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Hero");
        PlayerManager pm = GetComponent<PlayerManager>();
        pm.onStart();
        for (int i = 0; i < heroes.Length; i++)
        {
            Hero h = heroes[i].GetComponent<Hero>();
            pm.SetHero(h);

            AddUnit(h, h.team);
        }

        /*


        GameObject h1 = (GameObject)Instantiate(mhero, new Vector3(4 + 1000, 0, 10 + 1000), Quaternion.identity);
        Hero hero_1 = h1.GetComponent<Hero>();
        AddUnit(hero_1, 0);

        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 3; z++)
            {
                GameObject s1 = (GameObject)Instantiate(msoldier, new Vector3(x * 20 + 1000, msoldier.transform.position.y, z * 20 + 1000), Quaternion.identity);
                AddUnit(s1.GetComponent<Unit>(), 0);
            }
        }

        GameObject h2 = (GameObject)Instantiate(mhero, new Vector3(4 + 500, 0, 10 + 500), Quaternion.identity);
        AddUnit(h2.GetComponent<Hero>(), 1);
        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 3; z++)
            {
                GameObject s2 = (GameObject)Instantiate(msoldier, new Vector3(x * 20 + 500, msoldier.transform.position.y, z * 20 + 500), Quaternion.identity);
                AddUnit(s2.GetComponent<Unit>(), 1);
            }
        }
        */

    }

    void onUpdate()
    {
        //remove when health <= 0
        for (int i = 0; i < munitlists.Count; i++)
        {
            for (int j = munitlists[i].Count - 1; j >= 0; j--)
            {
                Unit u = munitlists[i][j];

                if (!u)
                    munitlists[i].RemoveAt(j);
                else if (u.health <= 0)
                {
                    munitlists[i].RemoveAt(j);
                    GameObject.Destroy(u.gameObject);
                }
            }
        }

        //find targets 
        for (int i = 0; i < munitlists.Count; i++)
        {
            for (int j = 0; j < munitlists[i].Count; j++)
            {
                Unit u = munitlists[i][j];
                GameObject.Find("Managers").GetComponent<BuildingManager>().findBuildingTargets(u, i);
                findTargets(u, i);

                if (u.mtarget_gameentity)
                    if (((u.mtarget_gameentity.transform.position - u.transform.position).magnitude >= u.range) || u.mtarget_gameentity.team == u.team)
                    {
                        u.mtarget_gameentity = null;
                    }

            }
		}

    }

    void findTargets(Unit u, int listnr)
    {
        float closestdist = u.range;
        Unit target = null;
        for (int i = 0; i < munitlists.Count; i++)
        {
            if (i == listnr)
                continue;
            for (int j = 0; j < munitlists[i].Count; j++)
            {
                Unit targetu = munitlists[i][j];
                if (targetu == null)
                {
                    Debug.Log("TARGET NULL");
                    Debug.Log("i"+ i);
                    Debug.Log("j" + j);
                    continue;
                }
                float dist = (targetu.transform.position - u.transform.position).magnitude;
                if (dist <= u.range)
                {
                    if (dist < closestdist)
                    {
                        closestdist = dist;
                        target = munitlists[i][j];
                    }

                }


            }
        }
        if (target)
            u.mtarget_gameentity = target;
    }

//	void findBuildingTargets(Unit u, int listnr)
//	{
//		for (int i = 0; i < buildingList.Count; i++)
//		{
//			if (i == listnr)
//				continue;
//			for (int j = 0; j < buildingList[i].Count; j++)
//			{
//				ZoneBuilding target = buildingList[i][j];
//				float dist = (target.transform.position - u.transform.position).magnitude;
//				if (dist <= u.range)
//				{
//					u.mtarget_gameentity = target;
//				}
//				
//				
//			}
//		}
//	}

    public void AddUnit(Unit u, int team)
    {
        u.team = team;
        munitlists[team].Add(u);
    }
    public List<Unit> GetUnitsInTeam(int team)
    {
        return munitlists[team];
    }



}
