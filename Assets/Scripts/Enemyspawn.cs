using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawn : MonoBehaviour {

	public GameObject[] spawnableEnemy;
	private Transform[] spawnpoints;
	int i=0;
	// Use this for initialization
	void Start () {
		spawnpoints = gameObject.GetComponentsInChildren<Transform> ();
		while (i < spawnpoints.Length) 
		{
			print(spawnpoints [i].position);
			i++;
		}
	}

}
