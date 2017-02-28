using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vikingswordController : MonoBehaviour {
	float damage1 = 2.5f;
	public bool hit = false;
	bool inattack;
	// Use this for initialization
	void Start () {
		
	}
	

	void OnTriggerEnter(Collider other)
	{
		if (!other.isTrigger && other.transform.tag == "Player") 
		{
			other.GetComponent<Health> ().health -= damage1;
			hit = true;
		}
	}

	/*void OnTriggerExit(Collider other)
	{
		if (!other.isTrigger && other.transform.tag == "Player") 
		{
			hit = false;
		}
	}*/
}
