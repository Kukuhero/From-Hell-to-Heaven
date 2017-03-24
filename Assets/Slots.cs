using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour {

	public GameObject item {
		get {
			if (transform.childCount > 0) {
				print ("initem");
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}
	public GameObject itemBeingDragged;
	
	public void OnDrop(PointerEventData eventData)
	{
		print ("onDrop aufgerufen");
		if(itemBeingDragged != null)
		{
			if(item)
			{
				itemBeingDragged.transform.SetParent (DragDropScript.ItemStartParent);
				itemBeingDragged.transform.position = DragDropScript.ItemStartPosition;
			}
			else{
				itemBeingDragged.transform.SetParent (transform);
			}
		}
	}
}
