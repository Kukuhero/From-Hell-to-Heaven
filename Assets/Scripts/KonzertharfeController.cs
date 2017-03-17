using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonzertharfeController : MonoBehaviour {

	public GameObject Projektil;
	public Transform Spawnpoint;
	private bool shoot = false;
	float i = 0;
	bool inshoot = false;
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
			if (!inshoot) 
			{
				inshoot = true;
				InvokeRepeating ("Shoot", 0.5f, 0.3f);
			}

		} else 
		{
			inshoot = false;
			CancelInvoke ();
		}
			

	}
	void Shoot()
	{
		if ( i <= 10) 
		{
			Spawnpoint.localPosition = new Vector3 (Spawnpoint.localPosition.x , Spawnpoint.localPosition.y, Spawnpoint.localPosition.z+ (i / 7f));
			Instantiate (Projektil,Spawnpoint.position , transform.parent.parent.rotation);
			Spawnpoint.localPosition = new Vector3 (Spawnpoint.localPosition.x , Spawnpoint.localPosition.y, Spawnpoint.localPosition.z- (i / 7f));
			i++;
		}
		else 
			{
				i = 0;
			}

	}
}
