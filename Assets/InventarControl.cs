using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventarControl : MonoBehaviour {

	public Camera camera;
	private Button[] inventarSlots;
	private GameObject[] startInventar;
	int i=0;
	// Use this for initialization
	void Start () {
		inventarSlots = gameObject.GetComponentsInChildren<Button> ();

	}
	

}
