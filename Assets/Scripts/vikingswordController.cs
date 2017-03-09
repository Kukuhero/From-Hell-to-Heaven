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
			print (transform.root);
			other.GetComponent<CharacterStats>().health -= -other.GetComponent<CharacterStats>().fireResistance + transform.root.GetComponent<EnemyStats>().fire;
			other.GetComponent<CharacterStats>().health -= -other.GetComponent<CharacterStats>().waterResistance + transform.root.GetComponent<EnemyStats>().light;
			other.GetComponent<CharacterStats>().health -= -other.GetComponent<CharacterStats>().shadowResistance + transform.root.GetComponent<EnemyStats>().damage;
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
