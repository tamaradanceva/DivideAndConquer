
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public Hero hero { get; set; }
    public List<Unit> units;
    public int team;

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
    }

    protected void OnUpdate()
    {
    }
}
