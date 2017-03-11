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
		if (Object.FindObjectOfType<WaffenStats> ().demonic) 
		{
			Object.FindObjectOfType<CharacterStats> ().xphell += xpdrop;
			Object.FindObjectOfType<CharacterStats> ().gold += moneydrop;
		} 
		else 
		{
			Object.FindObjectOfType<CharacterStats> ().xpheaven += xpdrop;
			Object.FindObjectOfType<CharacterStats> ().gold += moneydrop;
		}
	}
}
