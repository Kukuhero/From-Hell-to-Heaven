using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbarpositioning : MonoBehaviour {

	public Transform camera;
	
	// Update is called once per frame
	void Update () {
		Vector3 targetDir = camera.position - transform.position;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 100F, 0.0F);
		transform.rotation = Quaternion.LookRotation(newDir);
	}
}
