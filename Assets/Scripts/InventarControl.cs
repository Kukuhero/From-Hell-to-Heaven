using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventarControl : MonoBehaviour {

	public Camera camera;
	public Sprite[] inventarSlots ;
	private Transform[] pictureArray;
	public GameObject Inventar;
	int i=0;
	bool find = false;
	// Use this for initialization
	void Start () {
		pictureArray = new Transform[40];
		inventarSlots = new Sprite[20];
		for (int i = 0; i < 40; i++) 
		{
			pictureArray[i] = transform.GetChild(0).GetChild (i).transform;
		}
	}
	void Update()
	{
		
		for(int i = 0; i < Inventar.GetComponent<Inventar> ().number && Inventar.GetComponent<Inventar> ().inventar [i] != null; i++)
		{
			//print ("Length: "+ inventarSlots.Length + ", i: " + i);
			//print ( Inventar.GetComponent<Inventar> ().number);
			//print (Inventar.GetComponent<Inventar> ().inventar [i].GetComponent<WaffenStats> ().Picture);
			inventarSlots [i] = Inventar.GetComponent<Inventar>().inventar[i].GetComponent<WaffenStats>().Picture;
			//print (pictureArray[i].gameObject.GetComponentInChildren<Image> ().gameObject);
			pictureArray[i].GetChild(0).GetComponent<Image> ().sprite = inventarSlots [i];
		}

	}
	public void OnClick()
	{
		EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Slots>().itemBeingDragged =
			EventSystem.current.currentSelectedGameObject.gameObject.transform.GetChild(0).GetComponent<DragDropScript>().itemBeingDragged;

	}

	public void Enabled(bool on)
	{
		for(int i = 0; i < Inventar.GetComponent<Inventar> ().number && Inventar.GetComponent<Inventar> ().inventar [i] != null; i++)
		{
			//print ("Length: "+ inventarSlots.Length + ", i: " + i);
			//print ( Inventar.GetComponent<Inventar> ().number);
			//print (Inventar.GetComponent<Inventar> ().inventar [i].GetComponent<WaffenStats> ().Picture);
			inventarSlots [i] = Inventar.GetComponent<Inventar>().inventar[i].GetComponent<WaffenStats>().Picture;
			//print (pictureArray[i].gameObject.GetComponentInChildren<Image> ().gameObject);
			pictureArray[i].GetChild(0).GetComponent<Image> ().sprite = inventarSlots [i];
		}
		
		for (int i = 0; i <  Inventar.GetComponent<Inventar> ().number && Inventar.GetComponent<Inventar> ().inventar [i] != null; i++) {
			print (pictureArray [i].GetChild (0).name);
			if (on) {
				if (pictureArray [i].GetChild (0) != null) {
					pictureArray [i].GetChild (0).gameObject.SetActive (true);
				}
			} else {
				if (pictureArray [i].GetChild (0) != null) {
					pictureArray [i].GetChild (0).gameObject.SetActive (false);
					//transform.root.transform.gameObject.SetActive (false);
				}
			}
		}
	}

}
