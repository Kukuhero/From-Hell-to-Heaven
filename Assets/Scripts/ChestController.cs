using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {
	bool inTrigger = false;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = transform.FindChild ("Schatztruhe").GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (inTrigger && Input.GetKeyDown (KeyCode.Q)) 
		{
			anim.SetBool ("open", true);
			transform.GetComponent<Drops> ().Drop();
		}
		
	}

	void OnTriggerEnter(Collider other)
	{

		switch (other.transform.tag)
		{
		case "Player":
			if (!other.isTrigger) 
			{
				inTrigger = true;

			}
			break;
		default:
			break;
		}
	}
}
