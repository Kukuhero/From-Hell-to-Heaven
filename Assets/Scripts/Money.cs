using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour {

	public int value;

	void Update () {
		transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);

	}


		
		void OnCollisionEnter(Collision collision) {
		if (collision.transform.tag == "Player") 
			{
				print ("should work");
			Object.FindObjectOfType<CharacterStats> ().gold += value * Object.FindObjectOfType<CharacterStats> ().goldmultiplier;
				Destroy (transform.root.gameObject);
			}


	}

}
