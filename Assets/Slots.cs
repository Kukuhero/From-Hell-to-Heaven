using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour {

	public GameObject item {
		get {
			if (transform.childCount > 0) {
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}
	
	public void OnDrop(PointerEventData eventData)
	{
		if(DragDropScript.itemBeingDragged != null)
		{
			if(item)
			{
				DragDropScript.itemBeingDragged.transform.SetParent (DragDropScript.ItemStartParent);
				DragDropScript.itemBeingDragged.transform.position = DragDropScript.ItemStartPosition;
			}
			else{
				DragDropScript.itemBeingDragged.transform.SetParent (transform);
			}
		}
	}
}
