using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {


	public Transform inventory;
	public Transform canvas;

	void Start () {
		//Initialize Inventory
		inventory = canvas.Find ("Inventory");
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown (KeyCode.I)) {
			ToggleInventory ();
		}*/

	}

	public void ToggleInventory(){
		inventory.gameObject.SetActive(!inventory.gameObject.activeInHierarchy);
		//if it's on we are going to turn it off, if its off, we are going to turn it on
		//Wenn wir die Methode in einer anderen Klasse aufrufen möchten:
		//UIManager.instance.ToggleInventory();
	}

	public Vector2 ScreenToCanvasPoint(Vector2 screenPosition){
		
		Vector2 viewportPoint = Camera.main.ScreenToViewportPoint (screenPosition);
		Vector2 canvasSize = canvas.GetComponent<RectTransform> ().sizeDelta;

		return (new Vector2 (viewportPoint.x * canvasSize.x, viewportPoint.y * canvasSize.y) - (canvasSize/2));

	}
}
