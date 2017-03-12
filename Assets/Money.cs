using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour {

	public int value;


		
		void OnCollisionEnter(Collision collision) {
			print ("triggergold");
		if (collision.transform.tag == "Player") 
			{
				print ("should work");
				collision.transform.GetComponent<CharacterStats> ().gold += value;
				Destroy (transform.root.gameObject);
			}


	}

}
