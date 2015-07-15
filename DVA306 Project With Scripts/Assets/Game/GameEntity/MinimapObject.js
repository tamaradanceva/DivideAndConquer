#pragma strict

function Start () {
var mapBounds= GameObject.CreatePrimitive(PrimitiveType.Cube);
mapBounds.name="mapBounds";
Destroy(mapBounds.GetComponent(Collider));
mapBounds.transform.parent=transform;
mapBounds.layer=8;
mapBounds.transform.localScale=Vector3(3,3,3);
mapBounds.transform.localPosition=Vector3(0,4,0);
//get color depending on what type of object it is , logic in object itself
//hardcoded now, change later
if(this.gameObject.tag=="HomeBasePlayer"){
mapBounds.renderer.material.color=Color.green;
mapBounds.transform.localScale=Vector3(5,5,5);
}
else if(this.gameObject.tag=="HomeBaseEnemy"){
mapBounds.renderer.material.color=Color.red;
mapBounds.transform.localScale=Vector3(5,5,5);
}
else if (this.gameObject.tag.Contains("Player")){
mapBounds.renderer.material.color=Color.green;
}
else if(this.gameObject.tag.Contains("Enemy")){
mapBounds.renderer.material.color=Color.red;
}
else if (this.gameObject.tag=="NeutralBase"){
mapBounds.renderer.material.color=Color.white;
}
else if(this.gameObject.tag=="Hero"){
	mapBounds.renderer.material.color=Color.black;
	mapBounds.transform.localScale=Vector3(4,4,4);
	}

//mapBounds.renderer.material.color=Color.yellow;

}

function Update () {

}