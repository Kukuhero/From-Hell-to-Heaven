using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour {
    public GameObject[] inventar = new GameObject[20];
    public int number =0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for(int i=0; i <= 20 ; i++)
        {
            //print(inventar[i].name + "i: " + i);
        }
		
	}
}
