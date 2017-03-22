using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventar : MonoBehaviour {
    public GameObject[] inventar = new GameObject[20];
    public int number =0;
	public Image Menu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { 
        for(int i=0; i < 20 ; i++)
        {
			//Menu.GetComponent<InventarControl> ().inventarSlots[i]= inventar[i].GetComponent<WaffenStats>().Picture;
        }
		
	}
}
