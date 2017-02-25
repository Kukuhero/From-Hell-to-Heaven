using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    public Transform Spawnpoint;
    public GameObject Projektil;
    public bool shoot;

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        if(shoot)
        {
            Instantiate(Projektil, Spawnpoint.position, transform.parent.parent.rotation);
            shoot = false;
        }
		
	}
}
