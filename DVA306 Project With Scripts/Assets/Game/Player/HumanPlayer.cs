using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanPlayer : Player
{

    bool rts;
    public Camera cam_3rdperson { get; set; }
    public Camera cam_rts { get; set; }
    public CrossHair crosshair { get; set; }
    float herostartspeed;

    public int formationColLength, formationXoffset, formationZoffset;

    List<Unit> selectedUnits;
    List<Unit> heroUnitFollowers;

    //click drag select
    bool mousedown = false;
    Vector3 startpos, endpos;
    GameObject selectionbox = GameObject.CreatePrimitive(PrimitiveType.Cube);

    float timer = 0;

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
        selectedUnits = new List<Unit>();
        heroUnitFollowers = new List<Unit>();
        rts = true;
        hero.rts = rts;
        if (rts)
        {
            cam_3rdperson.gameObject.SetActive(false);
            cam_rts.gameObject.SetActive(true);
        }
        else
        {
            cam_3rdperson.gameObject.SetActive(true);
            cam_rts.gameObject.SetActive(false);
        }
        crosshair = cam_3rdperson.GetComponent<CrossHair>();
        herostartspeed = hero.mspeed;
    }

    protected void OnUpdate()
    {



        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            rts = !rts;
            hero.SwitchMode(rts);

            if (rts)
            {
                cam_3rdperson.gameObject.SetActive(false);
                cam_rts.gameObject.SetActive(true);
            }
            else
            {
                cam_3rdperson.gameObject.SetActive(true);
                cam_rts.gameObject.SetActive(false);
            }
        }
        //rts controls
        if (rts)
        {
            RTSActions();
        }
        else
            NonRTSActions();

        //herofollowers
        Vector3 target = new Vector3(hero.transform.position.x - 2 * formationXoffset, hero.transform.position.y, hero.transform.position.z - formationZoffset);
        int column = 0;
        int row = 0;
        for (int i = 0; i < heroUnitFollowers.Count; i++)
        {
            Unit u = heroUnitFollowers[i];
            u.mtarget_pos = new Vector3(target.x - row * formationXoffset, target.y, target.z + column * formationZoffset);
            column++;
            if (column >= formationColLength)
            {
                row++;
                column = 0;
            }
        }

    }

    private void NonRTSActions()
    {
        mousedown = false;
        selectionbox.SetActive(false);
        crosshair.crosshair.gameObject.SetActive(true);
        hero.forward = (crosshair.crosshair.transform.position - hero.transform.position).normalized;
        hero.right = cam_3rdperson.transform.right;
        hero.Sprint(false);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            hero.Sprint(true);
        }
        //dont attack if sprinting
        if (!hero.sprinting)
        {
            if (Input.GetMouseButton(0))
            {
                hero.Attack();
            }

            if (Input.GetMouseButton(1))
            {
                hero.Special1();
            }
            if (Input.GetKey(KeyCode.Q))
            {
                hero.Special2();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(hero.transform.position, hero.forward);
            RaycastHit rayhit;
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].transform.GetComponent<BoxCollider>().Raycast(ray, out rayhit, Mathf.Infinity))
                {
                    if (heroUnitFollowers.Contains(units[i]))
                        heroUnitFollowers.Remove(units[i]);
                    else
                        heroUnitFollowers.Add(units[i]);
                }

            }
        }
    }

    private void RTSActions()
    {
        crosshair.crosshair.gameObject.SetActive(false);
        if (mousedown)
        {
            Plane plane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float d = 0.0f;
            if (plane.Raycast(ray, out d))
                endpos = ray.GetPoint(d);

            selectionbox.SetActive(true);
            // Assuming this is run on a unit cube.
            Vector3 between = endpos - startpos;
            float distanceX = between.x;
            float distanceZ = between.z;
            float distanceY = 5;
            selectionbox.transform.localScale = new Vector3(distanceX, distanceY, distanceZ);
            selectionbox.transform.position = startpos + (between / 2.0f);
        }
        else
            selectionbox.SetActive(false);

        if (Input.GetMouseButtonUp(0))
        {
            if (startpos != endpos)
            {
                selectedUnits.Clear();
                for (int i = 0; i < units.Count; i++)
                {
                    Unit u = units[i];
                    //create plane at same level as unit
                    //shoot ray through screen, intersect with boxcollider, get point at distance d
                    BoxCollider bc = u.transform.GetComponent<BoxCollider>();

                    bool hit = bc.collider.bounds.Intersects(selectionbox.collider.bounds);
                    if (hit)
                    {
                        if (Input.GetKey(KeyCode.LeftShift))
                            u.Highlighted = !u.Highlighted;
                        else
                            u.Highlighted = true;
                    }
                    else
                    {
                        if (Input.GetKey(KeyCode.LeftShift))
                            u.Highlighted = u.Highlighted;
                        else
                            u.Highlighted = false;
                    }

                    if (u.Highlighted)
                        selectedUnits.Add(u);
                }
            }
            mousedown = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.up, transform.position);
            Ray planeray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float d = 0.0f;
            if (plane.Raycast(planeray, out d))
            {
                startpos = planeray.GetPoint(d);
            }
            mousedown = true;

            selectedUnits.Clear();
            for (int i = 0; i < units.Count; i++)
            {
                Unit u = units[i];
                //create plane at same level as unit
                //shoot ray through screen, intersect with boxcollider, get point at distance d
                BoxCollider bc = u.transform.GetComponent<BoxCollider>();
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit rayhit;
                bool hit = bc.Raycast(ray, out rayhit, Mathf.Infinity);
                if (hit)
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                        u.Highlighted = !u.Highlighted;
                    else
                        u.Highlighted = true;
                }
                else
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                        u.Highlighted = u.Highlighted;
                    else
                        u.Highlighted = false;
                }

                if (u.Highlighted)
                    selectedUnits.Add(u);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (selectedUnits.Count > 0)
            {

                Vector3 target = new Vector3(0, 0, 0);
                //create plane at same level as unit
                //shoot ray through screen, intersect with plane, get point at distance d
                Plane plane = new Plane(Vector3.up, transform.position);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                float d = 0.0f;
                if (plane.Raycast(ray, out d))
                {
                    target = ray.GetPoint(d);
                }


                int column = 0;
                int row = 0;
                for (int i = 0; i < selectedUnits.Count; i++)
                {
                    Unit u = selectedUnits[i];
                    if (heroUnitFollowers.Contains(u))
                        heroUnitFollowers.Remove(u);
                    u.mtarget_pos = new Vector3(target.x - row * formationXoffset, target.y, target.z + column * formationZoffset);
                    column++;
                    if (column >= formationColLength)
                    {
                        row++;
                        column = 0;
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
            selectedUnits.Clear();
            for (int i = 0; i < units.Count; i++)
            {
                units[i].Highlighted = true;
                selectedUnits.Add(units[i]);
            }
        }
    }
}