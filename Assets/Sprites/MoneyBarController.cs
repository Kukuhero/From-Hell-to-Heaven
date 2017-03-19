using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBarController : MonoBehaviour {
	public Text Money;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Money.text = (string)transform.parent.parent.GetComponent<CharacterStats> ().gold.ToString();
		
	}
}
