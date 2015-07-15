using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public Vector3 dir;
    public float dmg;
    public int team;
    public float speed;
    public bool piercing = false;
    Vector3 start;
    public float range { get; set; }

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

    protected virtual void OnStart()
    {
        renderer.material.color = Color.yellow;
        start = transform.position;
        transform.LookAt(transform.position + dir);
    }

    float timer = 0;
    protected virtual void OnUpdate()
    {
        timer += Time.deltaTime;
        transform.LookAt(transform.position + dir);
        Move();
        if (range > 0)
        {
            if ((start - transform.position).magnitude > range)
                Destroy(gameObject);
        }
        else
        {
            if (timer > 10)
                Destroy(gameObject);
        }
    }

    protected bool Move()
    {
        Vector3 newpos = transform.position + dir * speed;

        if (newpos == transform.position)
        {
            Destroy(gameObject);
            return false;
        }

        if (transform.position.y <= Terrain.activeTerrain.SampleHeight(transform.position))
        {
            Destroy(gameObject);
            return false;
        }


        transform.position += dir * speed;
        return true;
    }

    void OnTriggerEnter(Collider c)
    {
        GameEntity hit = c.GetComponent<GameEntity>();
        if (hit)
        {
            if (hit.team != team)
            {
                hit.health -= dmg;
                if(!piercing)
                    Destroy(gameObject);
            }
        }
    }
}
