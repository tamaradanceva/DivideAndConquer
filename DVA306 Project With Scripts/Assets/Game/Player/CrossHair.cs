using UnityEngine;
using System.Collections;

public class CrossHair : MonoBehaviour
{
    public GameObject crossHair;
    public Transform crosshair { get; set; }
    public float minDistance;
    public float maxDistance;

    void Awake()
    {
        crosshair = ((GameObject)Instantiate(crossHair)).GetComponent<Transform>();
        crosshair.renderer.material.color = Color.red;
    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        crosshair.rotation = Quaternion.LookRotation(transform.position - crosshair.position);

        RaycastHit hit = new RaycastHit();
        bool found = Physics.Raycast(transform.position + transform.forward*20, transform.forward, out hit, maxDistance);
        float magnitude = (hit.point - transform.position).magnitude;

        if (!found)
            crosshair.position = (transform.position + transform.forward * maxDistance);
        else if (found && magnitude > minDistance)
            crosshair.position = hit.point;
        else if (found && magnitude <= minDistance)
            crosshair.position = (transform.position + transform.forward * minDistance);
    }
}
