using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbarController : MonoBehaviour {

	[SerializeField]
	private Image content;
	private float health;
	private float maxhealth;

	// Use this for initialization
	void Start () {
		maxhealth = gameObject.transform.parent.parent.GetComponent<EnemyStats> ().health;
		content.color = Color.green;
	}

	// Update is called once per frame
	void Update () 
	{
		Barchange ();
	}

	void Barchange ()
	{
		health = gameObject.transform.parent.parent.GetComponent<EnemyStats> ().health;
		//print ("playerhealth" + playerhealth + ", maxhealth:" + maxPlayerhealth);
		content.fillAmount = (health/maxhealth);
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