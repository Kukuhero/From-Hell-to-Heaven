using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    public Transform Spawnpoint;
    public GameObject Projektil;

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Instantiate(Projektil, Spawnpoint.position, transform.parent.parent.rotation);
        }
		
	}
}
