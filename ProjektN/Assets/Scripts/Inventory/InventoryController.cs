using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryController : MonoBehaviour {

	GraphicRaycaster graphicRaycaster;
	PointerEventData pointerEventData;
	List<RaycastResult> raycastResults;
	GameObject draggedItem;
	UIManager uIManager;
	Transform canvas;
	Transform parentOfDraggedItem;

	// Use this for initialization
	void Start () {
		graphicRaycaster = GameObject.Find ("UI").GetComponent<GraphicRaycaster> ();
		pointerEventData = new PointerEventData (null);
		raycastResults = new List<RaycastResult> ();

		uIManager = GameObject.Find ("UI").GetComponent<UIManager> ();
		canvas = GameObject.Find ("UI").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		DragItems ();
	}

	void DragItems(){
		//Wenn das Object berührt wird, folgt es dem Finger, wird das Item über einem anderen Slot losgelassen, wird es dort niedergelassen
		//Befinden wir uns aber nicht über einem neuen Slot oder z.b. außerhalb des Inventorys fällt das Item zurück in seinen ursprünglichen Slot
		if (Input.GetMouseButtonDown (0)) {
			pointerEventData.position = Input.mousePosition;
			graphicRaycaster.Raycast (pointerEventData, raycastResults);
			if (raycastResults.Count > 0) {
					//print (result.gameObject.name);
					if (raycastResults [0].gameObject.GetComponent<Item> ()) {
						draggedItem = raycastResults [0].gameObject;
						parentOfDraggedItem = draggedItem.transform.parent;
						draggedItem.transform.SetParent (canvas);
					}
			}
		}

		//Item follows mouse
		if (draggedItem != null) {
			draggedItem.GetComponent<RectTransform> ().localPosition = uIManager.ScreenToCanvasPoint (Input.mousePosition);
		}

		//End draggin
		if (Input.GetMouseButtonUp (0)) {
			pointerEventData.position = Input.mousePosition;
			raycastResults.Clear ();
			graphicRaycaster.Raycast (pointerEventData, raycastResults);

			draggedItem.transform.SetParent (parentOfDraggedItem);
			if (raycastResults.Count > 0) {
				foreach (var result in raycastResults) {
					//Skip the draggedItem when it is the result

					if (result.gameObject == draggedItem)
						continue;
					
					//We are dropping our item on an empty slot:
					if (result.gameObject.CompareTag ("Slot")) {
						//Set New Parent
						draggedItem.transform.SetParent (result.gameObject.transform);
						break; //finish foreach loop
					} 
					if (result.gameObject.CompareTag ("ItemIcon")) {
						//Result ist the item we are dropping our item on
						if (result.gameObject.name != draggedItem.name) {
							//Swap item
							draggedItem.transform.SetParent (result.gameObject.transform.parent);
							result.gameObject.transform.SetParent (parentOfDraggedItem);
							result.gameObject.transform.localPosition = Vector3.zero;
							break;
						} else {
							//Stack items if they are the same
							result.gameObject.GetComponent<Item> ().quantity += draggedItem.GetComponent<Item> ().quantity;
							result.gameObject.transform.Find ("QuantityText").GetComponent<Text> ().text = result.gameObject.GetComponent<Item> ().quantity.ToString();
							GameObject.Destroy (draggedItem);	

						}
					}
				}
			}
			//Reset position to zero
			if (gameObject != null) { //Wenn es nicht wegen dem Stacken schon zerstört wurde
				draggedItem.transform.localPosition = Vector3.zero;
			}
			draggedItem = null;
		}
		raycastResults.Clear ();
	}
}
