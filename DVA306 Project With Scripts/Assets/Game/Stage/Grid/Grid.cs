using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	
	//Singleton
	public static Grid main;
	
	public int width;
	public int length;
	public float cell_size;
	
	private Cell[,] lstCells;
	
	// Use this for initialization
	void Start () {
		Initialise ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Awake()
	{
		main = this;
	}
	
	void Initialise(){
		lstCells = new Cell[width, length];
		for (int i=0; i<width; i++)
		{
			for (int j=0; j<length; j++)
			{
				//decide in which quadrant it is , adjust offset 
				
				float centerX = (i*cell_size) + (cell_size/2.0f);
				float centerZ = (j*cell_size) + (cell_size/2.0f);
				Vector3 center = new Vector3(centerX, 0, centerZ);				
				center.y = Terrain.activeTerrain.SampleHeight(center);
				
				lstCells[i,j] = new Cell(i, j, center);
				lstCells[i,j].checkCell();
				
				
			}
		}
		
	}
	
	public bool[,] getOccupied(){
		bool[,] occupied = new bool[width, length];
		for (int i=0; i<width; i++)
		{
			for (int j=0; j<length; j++)
			{
				if(lstCells[i,j].isOccupied()){
					occupied[i,j]=true;
				}
				else {
					occupied[i,j]=false;
				}
			}
		}
		return occupied;
	}
	
	bool chkCellOcc(int i, int j){
		if (lstCells [i, j].isOccupied())
			return true;
		else
			return false;
	}
	
	bool chkCellBld(int i, int j){
		if (lstCells [i, j].isBuildable())
			return true;
		else
			return false;
	}
	
}
