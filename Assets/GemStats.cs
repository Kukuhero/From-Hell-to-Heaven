using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStats : MonoBehaviour {

	public bool equiped;
	private bool statsadded = false;

	//Character

	public float speed;
	public float health;
	public float fireResistance;
	public float lightResistance;
	public float shadowResistance;
	public float waterResistance;
	public float Resistance;
	public float dashSpeed;
	public float dashTime;
	public float goldmultiplier = 1f;
	public float lootmultiplier;

	//Waffen

	public float damage;
	public float light;
	public float fire;
	public float shadow;
	public float water;
	public float firerate;
	public float Reichweite;
	//public bool Weihwasser;
	//public bool Dämonenfeuer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//vlt in IEnumerator alle 1-2s

		if (equiped&&!statsadded) 
		{
			Object.FindObjectOfType<CharacterStats> ().speed += speed;
			Object.FindObjectOfType<CharacterStats> ().maxhealth += health;
			Object.FindObjectOfType<CharacterStats> ().fireResistance += fireResistance;
			Object.FindObjectOfType<CharacterStats> ().lightResistance += lightResistance;
			Object.FindObjectOfType<CharacterStats> ().shadowResistance += shadowResistance;
			Object.FindObjectOfType<CharacterStats> ().waterResistance += waterResistance;
			Object.FindObjectOfType<CharacterStats> ().Resistance += Resistance;
			Object.FindObjectOfType<CharacterStats> ().dashSpeed += dashSpeed;
			Object.FindObjectOfType<CharacterStats> ().dashTime += dashTime;
			Object.FindObjectOfType<CharacterStats> ().goldmultiplier += goldmultiplier;
			Object.FindObjectOfType<CharacterStats> ().lootmultiplier += lootmultiplier;

			//Waffen

			Object.FindObjectOfType<WaffenStats> ().damage += damage;
			Object.FindObjectOfType<WaffenStats> ().light += light;
			Object.FindObjectOfType<WaffenStats> ().fire += fire;
			Object.FindObjectOfType<WaffenStats> ().shadow += shadow;
			Object.FindObjectOfType<WaffenStats> ().water += water;
			Object.FindObjectOfType<WaffenStats> ().firerate += firerate;
			Object.FindObjectOfType<WaffenStats> ().Reichweite += Reichweite;


			statsadded = true;
		}
		if (!equiped && statsadded) 
		{
			Object.FindObjectOfType<CharacterStats> ().speed -= speed;
			Object.FindObjectOfType<CharacterStats> ().maxhealth -= health;
			Object.FindObjectOfType<CharacterStats> ().fireResistance -= fireResistance;
			Object.FindObjectOfType<CharacterStats> ().lightResistance -= lightResistance;
			Object.FindObjectOfType<CharacterStats> ().shadowResistance -= shadowResistance;
			Object.FindObjectOfType<CharacterStats> ().waterResistance -= waterResistance;
			Object.FindObjectOfType<CharacterStats> ().Resistance -= Resistance;
			Object.FindObjectOfType<CharacterStats> ().dashSpeed -= dashSpeed;
			Object.FindObjectOfType<CharacterStats> ().dashTime -= dashTime;
			Object.FindObjectOfType<CharacterStats> ().goldmultiplier -= goldmultiplier;
			Object.FindObjectOfType<CharacterStats> ().lootmultiplier -= lootmultiplier;

			//Waffen

			Object.FindObjectOfType<WaffenStats> ().damage -= damage;
			Object.FindObjectOfType<WaffenStats> ().light -= light;
			Object.FindObjectOfType<WaffenStats> ().fire -= fire;
			Object.FindObjectOfType<WaffenStats> ().shadow -= shadow;
			Object.FindObjectOfType<WaffenStats> ().water -= water;
			Object.FindObjectOfType<WaffenStats> ().firerate -= firerate;
			Object.FindObjectOfType<WaffenStats> ().Reichweite -= Reichweite;

			statsadded = false;
		}
	}
}
