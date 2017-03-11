using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HellXpBar : MonoBehaviour {
	
	[SerializeField]
	private Image content;




	// Use this for initialization
	void Start () {
		
		content.color = Color.yellow;
	}
	
	// Update is called once per frame
	void Update () {
		content.fillAmount = (gameObject.transform.parent.parent.GetComponent<CharacterStats>().xphell/Mathf.Pow (gameObject.transform.parent.parent.GetComponent<CharacterStats>().lvlhell * 20, 1.2f));
	}
}
