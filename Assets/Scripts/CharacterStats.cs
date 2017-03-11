using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
    public float speed;
    public float health;
	public float maxhealth;
    public float fireResistance;
    public float lightResistance;
    public float shadowResistance;
    public float waterResistance;
    public float Resistance;
    public float dashSpeed;
    public float dashTime;
	public float gold;
	public float xphell;
	public float xpheaven;
	public int lvlhell;
	public int lvlheaven;

	// Use this for initialization
	void Start () {
		
	}



	// Update is called once per frame
	void Update () {
		if( health <= 0)
		{
			health = 0;
			StartCoroutine (Destroy ());
		}

		if (Mathf.Pow (lvlhell * 20, 1.2f) < xphell) 
		{
			lvlhell++;
			xphell = 0;
		}

		if (Mathf.Pow (lvlheaven * 20, 1.2f) < xpheaven) 
		{
			lvlheaven++;
			xpheaven = 0;
		}
	}



	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(10f);
		Destroy(gameObject);
	}
}
