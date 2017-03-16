using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonzertharfeController : MonoBehaviour {

	public GameObject Projektil;
	public Transform Spawnpoint;
	private bool shoot = false;
	float i = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(shoot)
		{
			
			shoot = false;
		}
		if (Input.GetMouseButton (0)) 
		{
			InvokeRepeating ("Shoot", 0.5f, 0.7f);

		} else 
		{
			CancelInvoke ();
		}
			

	}
	void Shoot()
	{
		if ( i <= 10) 
		{
			Instantiate (Projektil, new Vector3 (Spawnpoint.position.x+(i/10f), Spawnpoint.position.y, Spawnpoint.position.z), transform.parent.parent.rotation);
			i++;
		}
		else 
			{
				i = 0;
			}

	}
}
