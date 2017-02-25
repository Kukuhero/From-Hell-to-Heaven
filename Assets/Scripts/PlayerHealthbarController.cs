using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbarController : MonoBehaviour {

	[SerializeField]
	private Image content;
	private float playerhealth;
	private float maxPlayerhealth;

	// Use this for initialization
	void Start () {
		maxPlayerhealth = gameObject.transform.parent.parent.GetComponent<Health> ().maxhealth;
		content.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Barchange ();
	}

	void Barchange ()
	{
		playerhealth = gameObject.transform.parent.parent.GetComponent<Health> ().health;
		print ("playerhealth" + playerhealth + ", maxhealth:" + maxPlayerhealth);
		content.fillAmount = (playerhealth/maxPlayerhealth);
		if (content.fillAmount > 0.7f) 
		{
			content.color = Color.green;
		}
		if (content.fillAmount <= 0.7f) 
		{
			content.color = Color.yellow;
		}

		if (content.fillAmount <= 0.3f) 
		{
			content.color = Color.red;
		}
	}
}