using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDropScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDragged;
	public static Vector3 ItemStartPosition;
	public static Transform ItemStartParent;

	public float Mousex =0;
	public float Mousey =0;
	public Vector3 Mouseposition;
	
	public void OnBeginDrag(PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		ItemStartPosition = transform.position;
		ItemStartParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;

	}

	public void OnDrag(PointerEventData eventData)
	{
		if(itemBeingDragged != null)
		{
			if (eventData.pointerCurrentRaycast.gameObject != null) 
			{
				if (eventData.pointerCurrentRaycast.gameObject.tag == "Slot") 
				{
					transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
				} else {
					Mousex = Input.mousePosition.x;
					Mousey = Input.mousePosition.y;
					Mouseposition = Camera.main.ScreenToWorldPoint (new Vector3 (Mousex, Mousey, 10));
					transform.position = Mouseposition;
				}
			}
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (itemBeingDragged != null) {
			itemBeingDragged = null;
			GetComponent<CanvasGroup> ().blocksRaycasts = true;

			if (eventData.pointerCurrentRaycast.gameObject != null) {
				if (eventData.pointerCurrentRaycast.gameObject.tag != "Slot") {
					transform.position = ItemStartPosition;
					transform.parent = ItemStartParent;
				}
			}
		}
	}
}
