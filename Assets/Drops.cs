using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour {

	public int xpdrop;
	public int moneydrop;
	public GameObject weapondrops;
	public float weaponDropChance;
	public GameObject money;
	// Use this for initialization
	void Start () {
		moneydrop = (int)(xpdrop * Random.Range (0.5f, 2f));
	}

	public void onDeath()
	{
		if (Object.FindObjectOfType<WaffenStats> ().demonic) 
		{
			Object.FindObjectOfType<CharacterStats> ().xphell += xpdrop;

		} 
		else 
		{
			Object.FindObjectOfType<CharacterStats> ().xpheaven += xpdrop;

		}
		for (int i = 0; i < moneydrop; i++) {
			Instantiate (money, gameObject.transform.position,gameObject.transform.rotation);
			print ("moneydrop");
		}
	}
}
