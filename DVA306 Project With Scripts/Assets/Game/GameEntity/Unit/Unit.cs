using UnityEngine;
using System.Collections;

public class Unit : GameEntity {
    public GameEntity mtarget_gameentity;
	public Vector3 mtarget_pos;

    public float mspeed;
    public float range;

	public float mspeedMax;

	public float rangeMax;

	public bool moving{ get; private set;}

	void Awake()
	{
		mtarget_gameentity = null;
		mtarget_pos = transform.position;
		moving = false;
	}

    // Use this for initialization
    void Start()
    {
		float y = Terrain.activeTerrain.SampleHeight(transform.position) + transform.localScale.y / 2;
		transform.position = new Vector3(transform.position.x, y, transform.position.z);
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

    protected void OnUpdate()
    {
        base.OnUpdate();
 /*       if (Highlighted)
            renderer.material.color = Color.green;
        else
            renderer.material.color = Color.blue;*/
		Move();

        float y = Terrain.activeTerrain.SampleHeight(transform.position) + transform.localScale.y / 2;
		transform.position.Set (transform.position.x,y,transform.position.z);
		if (mtarget_pos != transform.position)
						moving = true;
    }

    protected virtual bool Attack()
    {
        return false;
    }
    protected virtual bool Move()
    {
        Vector3 moveto = mtarget_pos;


        if (mtarget_gameentity != null)
        {
            //moveto = mtarget_gameentity.transform.position;
        }
        /*if (Highlighted && Input.GetMouseButtonDown(1))
        {
            //create plane at same level as unit
            //shoot ray through screen, intersect with plane, get point at distance d
            Plane plane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float d = 0.0f;
            if (plane.Raycast(ray, out d))
            {
                moveto = mtarget_pos = ray.GetPoint(d);
                mtarget_gameentity = null;
            }

        }*/

        //rotate to face target
        if (mtarget_gameentity)
            transform.rotation = Quaternion.LookRotation(mtarget_gameentity.transform.position - transform.position);

        //did not move 
        if (transform.position == moveto) {
						return false;
				}

        //did move
        //rotate to face target
        transform.rotation = Quaternion.LookRotation(moveto - transform.position);
        transform.position = Vector3.MoveTowards(transform.position, moveto, mspeed * Time.deltaTime);
        return true;
    }
}
