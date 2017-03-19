using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawn : MonoBehaviour {

	public GameObject[] spawnableEnemy;
	private int spawnedEnemys;
	private int alreadySpawnedEnemys;
	private int playerLVL;
	private int currentSpawnPosition;
	private bool[] alreadyUsedPositions;
	private GameObject currentlySpawnEnemy;
	private Transform[] spawnpoints;

	// Use this for initialization
	void Start () {
		spawnpoints = gameObject.GetComponentsInChildren<Transform> ();
		alreadyUsedPositions = new bool[spawnpoints.Length];

	}
	void OnTriggerEnter(Collider other)
	{
		
		if (other.transform.tag == "Player") 
		{
			playerLVL = other.transform.root.GetComponent<CharacterStats> ().lvlheaven + other.transform.root.GetComponent<CharacterStats> ().lvlhell;
			if (playerLVL < 10) 
			{
				spawnedEnemys = (spawnpoints.Length/2);
			}
			if (playerLVL >= 10 && playerLVL < 25) 
			{
				spawnedEnemys = (spawnpoints.Length/5);
			}
			if (playerLVL >= 25 && playerLVL < 50) 
			{
				spawnedEnemys = (spawnpoints.Length/4);
			}
			if (playerLVL >= 50 && playerLVL < 100) 
			{
				spawnedEnemys = (spawnpoints.Length/3);
			}
			while(spawnedEnemys>alreadySpawnedEnemys)
			{
				currentlySpawnEnemy = spawnableEnemy[Random.Range(0,spawnableEnemy.Length)];
				currentSpawnPosition = Random.Range (0,spawnpoints.Length);
				if (!alreadyUsedPositions [currentSpawnPosition]) 
				{
					print (spawnpoints [currentSpawnPosition].position);
					Instantiate (currentlySpawnEnemy,spawnpoints[currentSpawnPosition].position,spawnpoints[currentSpawnPosition].rotation);
					alreadyUsedPositions [currentSpawnPosition] = true;
					alreadySpawnedEnemys++;
				}
			}


		}
	}

}
