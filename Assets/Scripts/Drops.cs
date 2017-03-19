using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour {

	public int xpdrop;
	public int moneydrop;
	public GameObject weapondrops;
	public float weaponDropChance;
	public GameObject money;
	private Vector3 spawnposition;
	public bool xp;
	public Transform Spawnpoint;
	// Use this for initialization
	void Start () {
		moneydrop = (int)(xpdrop * Random.Range (0.5f, 2f));
	}

	public void Drop()
	{
		if (xp) {
			if (Object.FindObjectOfType<WaffenStats> ().demonic) {
				Object.FindObjectOfType<CharacterStats> ().xphell += xpdrop;

			} else {
				Object.FindObjectOfType<CharacterStats> ().xpheaven += xpdrop;

			}
		}

		Invoke ("Spawn", 1f);
		/*for (int i = 0; i < moneydrop; i++) {
			spawnposition = new Vector3 (gameObject.transform.position.x,gameObject.transform.position.y+(i+1f/3f),gameObject.transform.position.z);
			Instantiate (money, spawnposition,gameObject.transform.rotation);
			print ("moneydrop");
			//Time.timeScale = 0;
		}*/
	}
	void Spawn ()
	{
		money.GetComponent<Money> ().value = moneydrop;
		Instantiate (money, new Vector3(Spawnpoint.position.x,1f,Spawnpoint.position.z),Object.FindObjectOfType<CharacterStats> ().GetComponentInParent<Transform>().rotation);
	}
}
