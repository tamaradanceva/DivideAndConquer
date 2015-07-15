using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
	public GameObject healthBar;
	
	void Start () {
		GameObject hp=(GameObject)Instantiate (healthBar,Vector3.zero, Quaternion.identity);
		hp.transform.parent = this.gameObject.transform;
	}
	
	void Update () {
			
		
	}
}