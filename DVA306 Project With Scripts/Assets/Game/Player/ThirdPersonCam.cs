using UnityEngine;
using System.Collections;

public class ThirdPersonCam : MonoBehaviour
{
    public float camPosOffsetX;
    public float camPosOffsetY;
    Vector3 mouserot;
    public float sensitivity;
    public float zoom;
    Camera cam;
    public Transform target;


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
        cam = GetComponent<Camera>();
        cam.transform.LookAt(target);
        if (sensitivity == 0)
            sensitivity = 10;
    }
    public void onUpdate()
    {
        mouserot.x += Input.GetAxis("Mouse X");
        mouserot.y += Input.GetAxis("Mouse Y");
        //zoom += -Input.GetAxis("Mouse ScrollWheel") * 100;

        Quaternion rotation = Quaternion.Euler(-mouserot.y * sensitivity, mouserot.x * sensitivity, 0);
        Vector3 position = rotation * (new Vector3(0, 0, -zoom)) + (target.position + target.right * camPosOffsetX);
        position.y += camPosOffsetY;
        cam.transform.rotation = rotation;
        cam.transform.position = position;
    }
}
