#pragma strict

var CamSpeed = 1.00;
var GUIsize = 200;
var rts=true;

//zoom camera
var distance : float = 60;
var sensitivityDistance : float = 50;
var damping : float = 5;
var minFOV : float = 40;
var maxFOV : float = 60;

function Start () {
distance = camera.fieldOfView;
}

function Update () {
var recdown = Rect (0, 0, Screen.width, GUIsize);
var recup = Rect (0, Screen.height-GUIsize, Screen.width, GUIsize);
var recleft = Rect (0, 0, GUIsize, Screen.height);
var recright = Rect (Screen.width-GUIsize, 0, GUIsize, Screen.height);

    if (recdown.Contains(Input.mousePosition)){
    	if(transform.position.z>-21){
        transform.Translate(0, 0, -CamSpeed, Space.World);
        }
   }

    if (recup.Contains(Input.mousePosition)){
    	if(transform.position.z<184){
        transform.Translate(0, 0, CamSpeed, Space.World);
        }
    }

    if (recleft.Contains(Input.mousePosition)){
    	if(transform.position.x>44.5){
        transform.Translate(-CamSpeed, 0, 0, Space.World);
       }
    }

    if (recright.Contains(Input.mousePosition)){
    	if(transform.position.x<204){
        transform.Translate(CamSpeed, 0, 0, Space.World);
        }
    }
    
   if(rts){
	if(Input.GetKey(KeyCode.S)){
    transform.Translate(0, 0, -CamSpeed, Space.World);
    }
    if(Input.GetKey(KeyCode.W)){
     transform.Translate(0, 0, CamSpeed, Space.World);
    }
    if(Input.GetKey(KeyCode.A)){
     transform.Translate(-CamSpeed, 0, 0, Space.World);
    }
    if(Input.GetKey(KeyCode.D)){
     transform.Translate(CamSpeed, 0, 0, Space.World);
    }	
    }

    

distance -= Input.GetAxis("Mouse ScrollWheel") * sensitivityDistance;
distance = Mathf.Clamp(distance, minFOV, maxFOV);
camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, distance, Time.deltaTime * damping);
}