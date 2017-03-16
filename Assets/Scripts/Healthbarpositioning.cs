using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbarpositioning : MonoBehaviour {

	public Transform camera;
	
	// Update is called once per frame
	void Update () {
		Vector3 targetDir =   transform.position - camera.position;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 100F, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.parent.rotation = Quaternion.LookRotation(newDir);
	}
}
