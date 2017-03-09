using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour {

	public int xpdrop;
	public int moneydrop;
	public GameObject weapondrops;
	public float weaponDropChance;

	// Use this for initialization
	void Start () {
		moneydrop = (int)(xpdrop * Random.Range (0.5f, 2f));
	}

	public void onDeath()
	{
		
		Object.FindObjectOfType<CharacterStats> ().xp += xpdrop;
		Object.FindObjectOfType<CharacterStats> ().gold += moneydrop;
	}
}
