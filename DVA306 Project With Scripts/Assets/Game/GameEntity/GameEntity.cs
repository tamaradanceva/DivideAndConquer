using UnityEngine;
using System.Collections;



public abstract class GameEntity : MonoBehaviour {
    public float health;
    public int team;
	// Use this for initialization
	void Start () {
        //empty but added just to be clear
        OnStart();
	}
	
	// Update is called once per frame
	void Update () {
        OnUpdate();
	}

	protected virtual void OnStart()
	{
		foreach (Renderer part in GetComponents<Renderer>()) {
			if (team == 0)
				part.material.color = Color.cyan;
			else
				part.material.color = Color.red;
		}
		foreach (Renderer part in GetComponentsInChildren<Renderer>()) {
			if (team == 0)
				part.material.color = Color.cyan;
			else
				part.material.color = Color.red;
		}
	}
    protected virtual void OnUpdate()
    {
        Highlight();
    }

    protected void Highlight()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            //create plane at same level as unit
            //shoot ray through screen, intersect with boxcollider, get point at distance d
            BoxCollider bc = transform.GetComponent<BoxCollider>();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayhit;
            bool hit = bc.Raycast(ray, out rayhit, Mathf.Infinity);
            if (hit)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    Highlighted = !Highlighted;
                else
                    Highlighted = true;
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    Highlighted = Highlighted;
                else
                    Highlighted = false;
                
            }
        }
         */
    }

    public bool Highlighted { get; set; }
}
