using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cell {
	
	private int i ;
	private int j ;
	private Vector3 center;
	
	private bool buildable;
	private bool occupied;
	
	//private GameObject gobj;
	
	public int geti(){
		return i;
	}
	
	public int getj(){
		return j;
	}
	
	public void setOccupied(bool occ){
		occupied = occ;
	}
	
	public void setBuildable(bool bld){
		buildable = bld;
	}
	
	public Vector3 getCenter(){
		return center;
	}
	
	public bool isBuildable(){
		return buildable;
	}
	
	public bool isOccupied(){
		return occupied;
	}
	
	public Cell(int i, int j, Vector3 center){
		this.i = i;
		this.j = j;
		this.center = center;
		checkCell ();
	}
	
	public void checkCell(){
		Vector3 point=center;
		center.y=200;
		Ray ray= new Ray(point, Vector3.down);
		RaycastHit hitCenter;
		LayerMask layerMask = new LayerMask ();
		//LayerMask layerMask = ~(1 << 8 | 1 << 9 | 1 << 11 | 1 << 18 | 1 << 19 | 1 << 20);
		if (Physics.Raycast (ray, out hitCenter, Mathf.Infinity, layerMask)) {
			//set occupied and buildable
			//check something
			//if(hitCenter.collider.tag==""){}
			setOccupied(true);
			
		} else {
			setOccupied(false);
		}
		
	}
}
